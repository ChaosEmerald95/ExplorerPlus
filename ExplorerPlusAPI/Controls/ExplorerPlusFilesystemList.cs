using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//weitere Namespaces
using System.IO;
using System.Threading; 

namespace ExplorerPlus.API.Controls
{
    public partial class ExplorerPlusFilesystemList : UserControl
    {
        public event ExplorerPlusControlsHandler FilesystementySelected;

        private string _aktpfad = ""; //Wenn dieser leer ist, sollen die Drives angezeigt werden, bei Ordnern muss IMMER der Backslash am Ende sein
        private List<string> recentpaths; //Liste mit den zuletzt ausgewählten Pfaden
        private List<string> undolist = null;
        private ImageList smlist = new ImageList();
        //private bool ShowComputer = true; //Ob aktuell die Drives angezeigt werden
        private int undopos = 0;

        public ExplorerPlusFilesystemList()
        {
            InitializeComponent();

            //ImageLists einrichten
            smlist.ImageSize = new Size(16, 16);
            smlist.ColorDepth = ColorDepth.Depth32Bit;
            lvfs.SmallImageList = smlist;

            //Erster Eintrag in Liste eintragen
            recentpaths = new List<string>(10);
            recentpaths.Add("");
        }

        public string AktuellerPfad
        {
            get { return _aktpfad; }
            set
            {
                _aktpfad = value;
                ShowPathContent();
            }
        }

        private void ShowPathContent()
        {
            //ListView leeren
            lvfs.Items.Clear();

            //Wenn der Pfad leer ist, sollen die Drives angezeigt werden. Wenn aber ein Pfad enthalten ist
            //soll der Inhalt des Pfades (Ordner) angezeigt werden
            if (_aktpfad == "")
            {
                smlist.Images.Clear();

                //Nun werden alle Drives geladen und angezeigt
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    //Icon ermitteln
                    smlist.Images.Add(FilesystemIcons.GetSmallIcon(string.Concat(drive.Name.Substring(0, 2) + @"\")));
                    //Jetzt muss geschaut werden, ob der Drive aktiv ist oder nicht und danach entschieden werden
                    if (drive.IsReady)
                    {
                        ListViewItem lvi = new ListViewItem(string.Concat(drive.Name.Substring(0, 2), " ", DriveFunctions.GetVolumeLabel(Convert.ToChar(drive.Name.Substring(0, 1)))),smlist.Images.Count - 1);
                        lvi.SubItems.Add(""); //Dummy
                        //Der Typ wird anhand des DriveType angegeben. Bei Size kommt der maximale Speicherplatz
                        if (drive.DriveType == DriveType.Fixed)
                            lvi.SubItems.Add(DriveFunctions.DRIVE_VOLUMELABEL_STD_HDD);
                        else if (drive.DriveType == DriveType.CDRom)
                            lvi.SubItems.Add(DriveFunctions.DRIVE_VOLUMELABEL_STD_OPT);
                        else if (drive.DriveType == DriveType.Removable)
                            lvi.SubItems.Add(DriveFunctions.DRIVE_VOLUMELABEL_STD_EXT);
                        else if (drive.DriveType == DriveType.Network)
                            lvi.SubItems.Add(DriveFunctions.DRIVE_VOLUMELABEL_STD_NET);
                        else
                            lvi.SubItems.Add("Unbekannter Laufwerkstyp");

                        lvi.SubItems.Add(drive.TotalSize.ToString());
                        lvfs.Items.Add(lvi);
                    }
                    else
                    {
                        ListViewItem lvi = new ListViewItem(string.Concat(drive.Name.Substring(0, 2),@"\"), smlist.Images.Count - 1);
                        lvi.SubItems.Add(""); //Dummy
                        //Der Typ wird anhand des DriveType angegeben. Bei Size kommt der maximale Speicherplatz
                        if (drive.DriveType == DriveType.Fixed)
                            lvi.SubItems.Add(DriveFunctions.DRIVE_VOLUMELABEL_STD_HDD);
                        else if (drive.DriveType == DriveType.CDRom)
                            lvi.SubItems.Add(DriveFunctions.DRIVE_VOLUMELABEL_STD_OPT);
                        else if (drive.DriveType == DriveType.Removable)
                            lvi.SubItems.Add(DriveFunctions.DRIVE_VOLUMELABEL_STD_EXT);
                        else if (drive.DriveType == DriveType.Network)
                            lvi.SubItems.Add(DriveFunctions.DRIVE_VOLUMELABEL_STD_NET);
                        else
                            lvi.SubItems.Add("Unbekannter Laufwerkstyp");
                        lvfs.Items.Add(lvi);
                    }
                }
            }
            else
            {
                DirectoryInfo dirinfo = new DirectoryInfo(_aktpfad);
                smlist.Images.Clear();
                smlist.Images.Add(FilesystemIcons.ICON_FILE_16x);
                
                //Zuerst kommen die Directories
                foreach (DirectoryInfo d in dirinfo.GetDirectories())
                {
                    try
                    {
                        smlist.Images.Add(FilesystemIcons.GetSmallIcon(d.FullName));
                    }
                    catch //Wenn das Icon über GetSmallIcon nicht genommen wird
                    {
                        smlist.Images.Add(FilesystemIcons.ICON_DIRECTORY_16x); //Ersatzicon
                    }
                    ListViewItem lvi = new ListViewItem(d.Name, smlist.Images.Count - 1);
                    lvi.SubItems.Add(d.LastWriteTime.ToString());
                    lvi.SubItems.Add(Extra.StringResource.GetStringResourceFromFile("@shell32.dll,-10152").ToString());
                    lvfs.Items.Add(lvi);
                }

                //Jetzt kommen die Files. Hier kann man denselben Code wie in ExplorerPlusFileView verwenden
                //Nun wird die Liste gefüllt
                foreach (FileInfo file in dirinfo.GetFiles())
                {
                    //Anhand der Erweiterung schauen, ob es eine Verknüpfung ist oder nicht
                    try
                    {
                        try
                        {
                            if (file.Extension == ".lnk")
                            {
                                smlist.Images.Add(FilesystemIcons.GetSmallIcon(FileFunctions.GetShortcutPath(file.FullName)));
                            }
                            else
                            {
                                smlist.Images.Add(FilesystemIcons.GetSmallIcon(file.FullName));
                            }
                        }
                        catch
                        {
                            smlist.Images.Add(FilesystemIcons.GetIconByExtension_x16(file.Extension));
                        }
                        ListViewItem lvi = new ListViewItem(file.Name, smlist.Images.Count - 1);
                        lvi.SubItems.Add(file.LastWriteTime.ToString());
                        lvi.SubItems.Add(FileFunctions.GetFileTypeDescription(file.Extension));

                        //Wenn die dateigröße unter 1024 Bytes ist, soll stattdessen 1 KB ausgegeben werden
                        if (file.Length < 1024)
                        {
                            lvi.SubItems.Add("1 KB");
                        }
                        else
                        {
                            lvi.SubItems.Add(ExtraFunctions.GetFileSizeKB(Convert.ToDouble(file.Length)));
                        }
                        lvfs.Items.Add(lvi);
                    }
                    catch (UnauthorizedAccessException)
                    { //Geht nicht, da kein Zugriff
                    }
                    catch
                    {
                        ListViewItem lvi = new ListViewItem(file.Name, 0);
                        lvi.SubItems.Add(file.LastWriteTime.ToString());
                        lvi.SubItems.Add(FileFunctions.GetFileTypeDescription(file.Extension));

                        //Wenn die dateigröße unter 1024 Bytes ist, soll stattdessen 1 KB ausgegeben werden
                        if (file.Length < 1024)
                        {
                            lvi.SubItems.Add("1 KB");
                        }
                        else
                        {
                            lvi.SubItems.Add(ExtraFunctions.GetFileSizeKB(Convert.ToDouble(file.Length)));
                        }
                        lvfs.Items.Add(lvi);
                    }
                }
            }
            cbrecentpaths.Text = _aktpfad; 
        }

        private void lvfs_DoubleClick(object sender, EventArgs e)
        {
            undopos = 0;
            undolist = null;
            btnback.Enabled = true;
            btnforward.Enabled = false;

            //Das Event, was beim Doppelklick aufgeführt wird, wird danach entschieden, ob es ein Ordner ist oder eine Exe. Wenn man bei "" war, wird sofort der Root-Directory geöffnet
            if (_aktpfad == "")
            {
                _aktpfad = lvfs.SelectedItems[0].Text.Substring(0, 2) + @"\"; //Pfad für Root einfügen
                AddRecentPath(_aktpfad);
                ShowPathContent();
            }
            else
            {
                if (lvfs.SelectedItems[0].SubItems[2].Text == Extra.StringResource.GetStringResourceFromFile("@shell32.dll,-10152")) //Wenn es ein ordner ist, soll im Ordner hochgegangen werden
                {
                    _aktpfad += lvfs.SelectedItems[0].Text + @"\"; //Pfad um Ordner erweitern
                    AddRecentPath(_aktpfad);
                    ShowPathContent();
                }
                else
                {
                    //Die Datei soll jetzt als Paramter über das Event übergeben werden
                    if (FilesystementySelected != null)
                        FilesystementySelected(_aktpfad + lvfs.SelectedItems[0].Text);
                }
            }
        }

        private void AddRecentPath(string recentpath)
        {
            //Bei diesem Verfahren werden alle Einträge nach hinten geschoben. Wenn der 10. Undo durchgeführt wurde
            //wird dieser blockiert
            if (recentpaths.Count == 10)
                recentpaths.RemoveAt(9); //letzten entfernen

            recentpaths.Insert(0, recentpath);
        }

        //private void UpdateComboList()
        //{
        //    //Die Daten aus der Liste in die ComboBox übertragen
        //    cbrecentpaths.Items.Clear();

        //    for (int i = 0; i < 10; i++)
        //    {
        //        cbrecentpaths.Items.Add(recentpaths[i]);
        //    }
        //}

        private void cbrecentpaths_SelectedIndexChanged(object sender, EventArgs e)
        {
            undopos = 0;

            //Dann soll auf den Pfad gewechselt werden und der Inhalt angezeigt werden
            AddRecentPath(_aktpfad);
            _aktpfad = cbrecentpaths.SelectedText; //Pfad um Ordner erweitern
            ShowPathContent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            //Jedes Mal, wenn der Button gedrückt wird, wird undopos um 1 erhöht (bis er auf 9 ist)
            //Eine zweite Liste läuft mit und wenn ein Ordner in der Liste ausgewählt wird oder ein Pfad eingegeben wird, dann soll die Liste
            //gecleart werden. Bei jedem Sprung wird auch die Recentpaths-Liste weiter geführt
            if (undopos == 0 && undolist == null)
            {
                undolist = new List<string>(10);
                //Liste kopieren
                for (int i = 0; i < recentpaths.Count; i++)
                    undolist.Add(recentpaths[i]);

                undopos++;
                _aktpfad = undolist[undopos];
                AddRecentPath(_aktpfad);
                ShowPathContent();
                btnforward.Enabled = true;
            }
            else
            {
                if (undopos == 8)
                    btnback.Enabled = false;

                undopos++;
                _aktpfad = undolist[undopos];
                AddRecentPath(_aktpfad);
                ShowPathContent();
                btnforward.Enabled = true;
            }
        }

        private void btnforward_Click(object sender, EventArgs e)
        {
            if (undopos == 1)
                btnforward.Enabled = false;

            undopos--;
            _aktpfad = undolist[undopos];
            AddRecentPath(_aktpfad);
            ShowPathContent();
            btnback.Enabled = true;
        }

        private void cbrecentpaths_KeyDown(object sender, KeyEventArgs e)
        {
            //Wenn Enter gedrückt wurde, soll der Pfad überprüft werden. Wenn dieser in Ordnung ist, darf dieser aufgerufen werden
            if (e.KeyCode == Keys.Enter )
            {
                e.SuppressKeyPress = true;
                if (Directory.Exists(cbrecentpaths.Text ))
                {
                    if (cbrecentpaths.Text.Substring(cbrecentpaths.Text.Length - 1, 1) != @"\")
                        cbrecentpaths.Text += @"\";
                    undopos = 0;
                    undolist = null;
                    btnback.Enabled = true;
                    btnforward.Enabled = false;
                    _aktpfad = cbrecentpaths.Text;
                    AddRecentPath(_aktpfad);
                    ShowPathContent();
                }
                else
                {
                    MessageBox.Show("Der Pfad " + cbrecentpaths.Text + " ist nicht verfügbar oder der Zugriff wurde verweigert", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbrecentpaths.Text = _aktpfad; 
                    return;
                }
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            //Ein neuer Ordner wird erstellt
            //In einer InputBox muss der Name des Ordners angegeben werden
            string foldername = Microsoft.VisualBasic.Interaction.InputBox("Ordnername", "Neuen Ordner erstellen", "Neuer Ordner");

            //Ein DirectoryInfo-Objekt erstellen, damit der Ordner erstellt werden kann
            DirectoryInfo info = new DirectoryInfo(_aktpfad);
            info.CreateSubdirectory(foldername); //Ordner erstellen
            ShowPathContent();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvfs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Wählen Sie Elemente aus, die gelöscht werden sollen");
                return;
            }
            else
            {
                if (lvfs.SelectedItems.Count == 1)
                {
                    if (MessageBox.Show("Soll das 1 Element wirklich gelöscht werden?", "Warnung", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                    if (MessageBox.Show("Sollen die " + lvfs.SelectedItems.Count.ToString() + " Elemente wirklich gelöscht werden?", "Warnung", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
            }

            //Löschvorgang beginnt.
            for (int i = 0; i < lvfs.SelectedItems.Count; i++)
            {
                try //Manche Dateien verweigern ggf. einen Löschvorgang
                {
                    if (lvfs.SelectedItems[i].SubItems[2].Text == Extra.StringResource.GetStringResourceFromFile("@shell32.dll,-10152"))
                        Directory.Delete(_aktpfad + lvfs.SelectedItems[i].Text);
                    else
                        File.Delete(_aktpfad + lvfs.SelectedItems[i].Text);
                    lvfs.SelectedItems[i].Remove(); //Nachladen verhindern
                }
                catch
                {

                }
            }   
        }

        private void lvfs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btndelete_Click(btndelete, null); //Die selbe Methode verwenden
            }
        }
    }
}
