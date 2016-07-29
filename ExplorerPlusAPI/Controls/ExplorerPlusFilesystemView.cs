using System;
using System.IO;
using System.Windows.Forms;

namespace ExplorerPlus.API.Controls
{
    public partial class ExplorerPlusFilesystemView : UserControl
    {
        //Konstanten
        private const string DS = @"\";
        private const string TREENODE_DIRSUB = ".dirsub";

        //Events
        public event ExplorerPlusFilesystemHandler SelectedPathChanged;    

        private string _selectedpath = "";
        //private bool _showhiddendir = false;
        private string[] direxceptions = new string[] { "$Recycle.Bin", "Recovery", "System Volume Information" };

        public ExplorerPlusFilesystemView()
        {
            InitializeComponent();
            LoadDrives();
            drvchktimer.Start();
        }

        /// <summary>
        /// Gibt den aktuellen Pfad auf der
        /// </summary>
        public string SelectedPath
        {
            get { return _selectedpath; }
        }

        public void LoadDrives()
        {
            //Erstmal müssen alle Nodes aus der TreeView entfernt werden, bevor die Drives angezeigt werden können
            tvfilesystem.Nodes.Clear();
            tvfilesystem.ImageList.Images.Clear();

            //Die Standardicons aus der Klasse 'FilesystemIcons' einfügen, damit diese nicht ständig nachgeladen werden müssen
            imglist.Images.Add(FilesystemIcons.ICON_DIRECTORY_16x); //Index 0

            //Nun werden alle Drives geladen und angezeigt
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                //Jetzt muss geschaut werden, ob der Drive aktiv ist oder nicht und danach entschieden werden
                if (drive.IsReady)
                {
                    //Icon ermitteln
                    imglist.Images.Add(FilesystemIcons.GetSmallIcon(string.Concat(drive.Name.Substring(0, 2) + DS)));

                    //TreeNode erstellen und hinzufügen
                    TreeNode n = new TreeNode(string.Concat(drive.Name.Substring(0, 2), " ", DriveFunctions.GetVolumeLabel(Convert.ToChar(drive.Name.Substring(0,1)))));
                    n.ImageIndex = tvfilesystem.ImageList.Images.Count - 1;
                    n.SelectedImageIndex = tvfilesystem.ImageList.Images.Count - 1;
                    tvfilesystem.Nodes.Add(n);

                    //Prüfen, ob das Drive über Ordner verfügt
                    if (DirectoryFunctions.HasSubDirectories(drive.Name.Substring(0,2) + DS))
                    {
                        //Wenn es über Ordner verfügt, soll der tenporäre TreeNode geadded werden
                        //Das ist dann für das generieren der Subnodes notwendig
                        tvfilesystem.Nodes[tvfilesystem.Nodes.Count - 1].Nodes.Add(TREENODE_DIRSUB);
                    }
                }
                else
                {
                    //TreeNode erstellen und hinzufügen
                    imglist.Images.Add(FilesystemIcons.GetSmallIcon(string.Concat(drive.Name.Substring(0, 2) + DS)));
                    TreeNode n = new TreeNode(string.Concat(drive.Name.Substring(0, 2), DS));
                    n.ImageIndex = tvfilesystem.ImageList.Images.Count - 1;
                    n.SelectedImageIndex = tvfilesystem.ImageList.Images.Count - 1;
                    tvfilesystem.Nodes.Add(n);
                }
            }
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
                        foreach(DirectoryInfo d in dirinfo.EnumerateDirectories())
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
                            //Edit 28.04: Code optimiert
                            try
                            {
                                if (d.GetDirectories().Length > 0)
                                    n1.Nodes.Add(TREENODE_DIRSUB);
                            }
                            catch { }

                            tn.Nodes.Add(n1);
                        }
                    }
                    //Wenn der Ordner keine Unterordner hat, dann kann der TreeNode .dirsub sofort gelöscht werden
                    tn.Nodes.RemoveAt(0);

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

        private string GetPath(ref TreeNode treenode)
        {
            TreeNode nextnode = treenode;
            //Node wird in nextnode geschrieben
            string text = "";
            //Falls es ein Drive ist
            if (nextnode.Level == 0)
               return treenode.Text.Substring(0, 2) + DS;
            else
                text = treenode.Text + DS;

            while (nextnode.Parent != null)
            {
                nextnode = nextnode.Parent;
                if (nextnode.Level == 0)
                {
                    text = nextnode.Text.Substring(0, 2) + DS + text;
                    break;
                }
                else
                    text = nextnode.Text + DS + text;

            }
            return text;
        }

        private void tvfilesystem_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //Es werden erst, wenn möglich, die Subnodes generiert
            TreeNode temp = e.Node; 
            string _path = GetPath(ref temp);
            GenerateSubNodes(ref temp, _path, true);
        }

        private void tvfilesystem_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode temp = e.Node;
            _selectedpath = GetPath(ref temp);
            if (SelectedPathChanged != null) SelectedPathChanged(_selectedpath); //event auslösen
        }

        /// <summary>
        /// Prüft, ob die Drives noch vorhanden sind. Wenn nicht, sollen diese vernichtet werden
        /// </summary>
        private void Thread_CheckDrives()
        {
            //Liste mit allen Drives laden
            string[] driveold = new string[tvfilesystem.Nodes.Count];
            for (int i = 0; i < tvfilesystem.Nodes.Count; i++)
                driveold[i] = tvfilesystem.Nodes[i].Text;

            //Alle Drives jetzt prüfen
            bool isfound = false;
            foreach(DriveInfo drvinfo in DriveInfo.GetDrives())
            {
                isfound = false;
                //jetzt wird überprüft, ob der Eintrag gefunden wurde
                for (int i = 0; i < driveold.Length; i++)
                {
                    //Wenn das Laufwerk gefunden wurde
                    if (driveold[i] != "")
                    {
                        if (driveold[i].Substring(0, 1) == drvinfo.Name.Substring(0, 1))
                        {
                            driveold[i] = "";
                            isfound = true;
                            break; //For-Schleife kann verlassen werden
                        }
                    }
                }

                if (isfound == false) //wenn das Laufwerk nicht gefunden wurde, dann soll es hinzugefügt werden
                {
                    //Jetzt muss geschaut werden, ob der Drive aktiv ist oder nicht und danach entschieden werden
                    if (drvinfo.IsReady)
                    {
                        //Icon ermitteln
                        imglist.Images.Add(FilesystemIcons.GetSmallIcon(string.Concat(drvinfo.Name.Substring(0, 2) + DS)));

                        //TreeNode erstellen und hinzufügen
                        TreeNode n = new TreeNode(string.Concat(drvinfo.Name.Substring(0, 2), " ", DriveFunctions.GetVolumeLabel(Convert.ToChar(drvinfo.Name.Substring(0, 1)))));
                        n.ImageIndex = tvfilesystem.ImageList.Images.Count - 1;
                        n.SelectedImageIndex = tvfilesystem.ImageList.Images.Count - 1;
                        tvfilesystem.Nodes.Add(n);

                        //Prüfen, ob das Drive über Ordner verfügt
                        if (DirectoryFunctions.HasSubDirectories(drvinfo.Name.Substring(0, 2) + DS))
                        {
                            //Wenn es über Ordner verfügt, soll der tenporäre TreeNode geadded werden
                            //Das ist dann für das generieren der Subnodes notwendig
                            tvfilesystem.Nodes[tvfilesystem.Nodes.Count - 1].Nodes.Add(TREENODE_DIRSUB);
                        }
                    }
                    else
                    {
                        //TreeNode erstellen und hinzufügen
                        imglist.Images.Add(FilesystemIcons.GetSmallIcon(string.Concat(drvinfo.Name.Substring(0, 2) + DS)));
                        TreeNode n = new TreeNode(string.Concat(drvinfo.Name.Substring(0, 2), DS));
                        n.ImageIndex = tvfilesystem.ImageList.Images.Count - 1;
                        n.SelectedImageIndex = tvfilesystem.ImageList.Images.Count - 1;
                        tvfilesystem.Nodes.Add(n);
                    }
                }
            }

            //Prüfen, ob noch Einträge in dem Array nicht geleert wurden. Wenn welche gefunden wurden, müssen diese vernichtet werden
            for (int i = driveold.Length; i > 0 ; i--)
            {
                if (driveold[i - 1] != "") //Wenn das laufwerk in der Liste noch da ist, aber nicht mehr da ist, wird es gelöscht
                {
                    tvfilesystem.Nodes.RemoveAt(i - 1);
                }
            }
        }

        private void drvchktimer_Tick(object sender, EventArgs e)
        {
            Thread_CheckDrives();
        }
    }
}
