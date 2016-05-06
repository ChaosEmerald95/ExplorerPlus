using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ExplorerPlus.API.Controls
{
    public partial class ExplorerPlusNetworkFilesystem : UserControl
    {
        private const string TREENODE_DIRSUB = ".dirsub";
        private string _selectedpath;
        List<string> pclist = new List<string>();
        private delegate void NetworkTreeViewAddElement(TreeNode ip);
        private delegate void NetworkTreeViewClear();
        private PingClass pingcl;

        //Events
        public event ExplorerPlusFilesystemHandler SelectedPathChanged;

        private void TreeViewAddPCElement(TreeNode ip)
        {
            tvnfs.Nodes[0].Nodes.Add(ip);
        }

        private void TreeViewClear()
        {   //Alle leeren ausräumen
            for (int i = tvnfs.Nodes[0].Nodes.Count - 1; i >= 0; i--)
            {
                if (tvnfs.Nodes[0].Nodes[i].Text == "")
                    tvnfs.Nodes[0].Nodes.RemoveAt(i);
            }
        }

        public ExplorerPlusNetworkFilesystem()
        {
            InitializeComponent();

            //3 Standard-Images reinladen
            imglist.Images.Add(FilesystemIcons.ICON_NETWORK_16x);
            imglist.Images.Add(FilesystemIcons.ICON_COMPUTER_16x);
            imglist.Images.Add(FilesystemIcons.ICON_NETWORKFOLDER_16x);

            //Level 0 Node generieren
            TreeNode n = new TreeNode("Network");
            n.ImageIndex = 0;
            n.SelectedImageIndex = 0;
            tvnfs.Nodes.Add(n);
        }

        public void Start()
        {
            //PingClass-Objekt erstellen
            pingcl = new PingClass();
            pingcl.PingListCompleted += Pingcl_PingListCompleted;

            pingcl.Ping_all();
        }

        private void Pingcl_PingListCompleted(List<string> iplist)
        {
            System.Diagnostics.Debug.Print("IP-Liste erhalten");
            pclist = iplist; //Für die Shared Folders vom Vorteil
            foreach(string ip in iplist)
            {
                try
                {
                    TreeNode n = new TreeNode(LocalNetworkFunctions.GetHostName(ip).ToUpper());
                    n.ImageIndex = 1;
                    n.SelectedImageIndex = 1;
                    tvnfs.Invoke(new NetworkTreeViewAddElement(TreeViewAddPCElement), n);
                }
                catch { }
            }
            tvnfs.Invoke(new NetworkTreeViewClear(TreeViewClear));

            //Im Anschluss soll gleich die nächste Methode aufgerufen
            //werden. Diese soll die Netzwerkordner angeben für
            //jede einzelnen PC
            Invoke(new NetworkTreeViewClear(ShowSharedFolders)); //Invoken, damit es im Main-Thread läuft
        }

        private void ShowSharedFolders()
        {
            for (int i = 0; i < tvnfs.Nodes[0].Nodes.Count; i++)
            {
                List<string> networkfolders = LocalNetworkFunctions.GetListOfSharedFolders(LocalNetworkFunctions.GetIPAdressFromMachineName(tvnfs.Nodes[0].Nodes[i].Text));
                foreach (string entry in networkfolders )
                {
                    if (entry.Contains("ERROR") == false)
                    {
                        try
                        {
                            TreeNode n = new TreeNode(entry);
                            n.ImageIndex = 2;
                            n.SelectedImageIndex = 2;
                            tvnfs.Nodes[0].Nodes[i].Nodes.Add(n);
                        }
                        catch { }
                    }
                    else
                    {
                        System.Diagnostics.Debug.Print("Fehler beim Zugriff auf Netzwerk-Ordner");
                        System.Diagnostics.Debug.Print("IP: " + LocalNetworkFunctions.GetIPAdressFromMachineName(tvnfs.Nodes[0].Nodes[i].Text));
                        System.Diagnostics.Debug.Print("PC-Name: " + tvnfs.Nodes[0].Nodes[i].Text);
                        System.Diagnostics.Debug.Print("Error-Code: "+entry.Substring(entry.IndexOf("=") + 1));
                        //Anhand der Message den Fehler anzeigen
                        if (entry.Substring(entry.IndexOf("=") + 1) == "5")
                            System.Diagnostics.Debug.Print("Fehler: Access Denied");
                        else if (entry.Substring(entry.IndexOf("=") + 1) == "53")
                            System.Diagnostics.Debug.Print("Fehler: Bad Network Path");
                    }
                }

                //Der nächste Schritt ist zu scannen, welche Freigaben noch Unterordner hat, auf die zugegriffen werden kann.
                //wenn dies der Fall ist, soll ein Temp-Node angelegt werden
                if (tvnfs.Nodes[0].Nodes[i].Nodes.Count > 0)
                {
                    for (int j = 0; j < tvnfs.Nodes[0].Nodes[i].Nodes.Count; j++)
                    {
                        //Der Netzwerkpfad
                        string p = @"\\" + LocalNetworkFunctions.GetIPAdressFromMachineName(tvnfs.Nodes[0].Nodes[i].Text) + @"\" + tvnfs.Nodes[0].Nodes[i].Nodes[j].Text;
                        if (DirectoryFunctions.HasSubDirectories(p))
                        {
                            tvnfs.Nodes[0].Nodes[i].Nodes[j].Nodes.Add(TREENODE_DIRSUB);
                        }
                    }
                }
            }
        }

        private void tvnfs_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Level >= 2) //Alle Expand-Aktionen ab Level 2
            {
                TreeNode temp = e.Node;
                string _path = GetPath(ref temp);
                GenerateSubNodes(ref temp,_path, false);
            }
        }

        private string GetPath(ref TreeNode treenode)
        {
            TreeNode nextnode = treenode;
            //Node wird in nextnode geschrieben
            string text = "";
            //Falls es ein Drive ist
            if (nextnode.Level == 1) //0 darf nicht gehen
            {
                text = @"\\" + treenode.Text;
                return text;
            }
            else {
                text = treenode.Text + @"\";
            }
            while (nextnode.Level >= 1)
            {
                nextnode = nextnode.Parent;
                if (nextnode.Level == 1)
                {
                    text = @"\\" + LocalNetworkFunctions.GetIPAdressFromMachineName(nextnode.Text) + @"\" + text;
                    break;
                }
                else
                {
                    text = nextnode.Text + @"\" + text;
                }
            }
            return text;
        }

        public void GenerateSubNodes(ref TreeNode tn, string pfad, bool hidesystemfolders)
        {
            //Erst kommen die Prüfungen. Damit neue Nodes generiert werden, darf
            //NUR der TreeNode .dirsub da sein. Ansonsten wird nichts geladen (Caching)
            if (tn.Nodes.Count == 1 && tn.Nodes[0].Text == TREENODE_DIRSUB)
            {
                //Dieser Vorgang sollte in einer Try-Catch ausgeführt werden, um eventuelle Fehler zu vermeiden
                try
                {
                    //Ein DirectoryInfo-Objekt muss verwendet werden
                    DirectoryInfo dirinfo = new DirectoryInfo(pfad);

                    //Wenn Directories in dem Ordner existieren, dann sollen diese geladen werden
                    if (dirinfo.GetDirectories().Length > 0)
                    {
                        foreach (DirectoryInfo d in dirinfo.EnumerateDirectories())
                        {
                            //Jetzt werden die einzelnen Ordner hinzugefügt
                            TreeNode n1 = new TreeNode(d.Name);
                            //Nun wird das Icon geladen und dem Node hinzugefügt. Wenn 
                            //aber ein Fehler bei der Methode 'GetSmallIcon" passiert,
                            //wird das Standardicon für Ordner geladen
                            try
                            {
                                imglist.Images.Add(FilesystemIcons.GetSmallIcon(d.FullName));
                                n1.ImageIndex = imglist.Images.Count - 1;
                                n1.SelectedImageIndex = imglist.Images.Count - 1;
                            }
                            catch
                            {
                                n1.ImageIndex = 0;
                                n1.SelectedImageIndex = 0;
                            }

                            //Edit 05.01: Nun prüfen, ob dieser Ordner weitere Unterordner hat
                            try
                            {
                                DirectoryInfo dtemp = new DirectoryInfo(d.FullName);
                                if (dtemp.GetDirectories().Length > 0)
                                {
                                    n1.Nodes.Add(TREENODE_DIRSUB);
                                }
                            }
                            catch { }

                            tn.Nodes.Add(n1);
                        }

                        //Am Ende muss der Node .dirsub gelöscht werden
                        tn.Nodes.RemoveAt(0);
                    }
                    else
                    {
                        //Wenn der Ordner keine Unterordner hat, dann kann der TreeNode .dirsub sofort gelöscht werden
                        tn.Nodes.RemoveAt(0);
                    }

                    //Nun müssen noch alle Ausnahmen entfernt werden. Es fängt bei den versteckten Ordnern an

                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Auf das Verzeichnis " + tn.Text + " kann nicht zugegriffen werden" + Environment.NewLine + Environment.NewLine + "Zugriff verweigert!", "Zugriffsfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ein Fehler ist beim Laden der Unterordner aufgetreten" + Environment.NewLine + Environment.NewLine + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tvnfs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level >= 2)
            {
                TreeNode temp = e.Node;
                _selectedpath = GetPath(ref temp);
                if (SelectedPathChanged != null) SelectedPathChanged(_selectedpath); //event auslösen
            }
        }
    }
}