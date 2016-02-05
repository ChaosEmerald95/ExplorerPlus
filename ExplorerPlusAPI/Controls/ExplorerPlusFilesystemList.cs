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
        private List<string> recentpaths = new List<string>(10); //Liste mit den zuletzt ausgewählten Pfaden
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
            recentpaths[0] = "";
        }

        public string AktuellerPfad
        {
            get { return _aktpfad; }
        }

        private void ShowPathContent()
        {
            //ListView leeren
            lvfs.Clear();

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

                        lvi.SubItems.Add(drive.TotalSize.ToString());
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
                //FriendlyTypeName vom Ordner unter: @shell32.dll,-10152
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
                    lvi.SubItems.Add(FileFunctions.GetStringResourceFromFile("@shell32.dll,-10152"));
                    lvfs.Items.Add(lvi);
                }

                //Jetzt kommen die Files. Hier kann man denselben Code wie in ExplorerPlusFileView verwenden
                //Nun wird die Liste gefüllt
                foreach (FileInfo file in dirinfo.GetFiles())
                {
                    //Anhand der Erweiterung schauen, ob es eine Verknüpfung ist oder nicht
                    try
                    {
                        if (file.Extension == ".lnk")
                        {
                            smlist.Images.Add(FilesystemIcons.GetSmallIcon(FileFunctions.GetShortcutPath(file.FullName)));
                        }
                        else
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

            //Das Event, was beim Doppelklick aufgeführt wird, wird danach entschieden, ob es ein Ordner ist oder eine Exe. Wenn man bei "" war, wird sofort der Root-Directory geöffnet
            if (_aktpfad == "")
            {
                AddRecentPath(_aktpfad);
                _aktpfad = lvfs.SelectedItems[0].Text.Substring(0, 2) + @"\"; //Pfad für Root einfügen
                ShowPathContent();
            }
            else
            {
                if (lvfs.SelectedItems[0].SubItems[1].Text == FileFunctions.GetStringResourceFromFile("@shell32.dll,-10152")) //Wenn es ein ordner ist, soll im Ordner hochgegangen werden
                {
                    AddRecentPath(_aktpfad);
                    _aktpfad += lvfs.SelectedItems[0].Text + @"\"; //Pfad um Ordner erweitern
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
            for (int i = 9; i > 0; i--)
            {
                recentpaths[i] = recentpaths[i - 1];
            }
            recentpaths[0] = recentpath; 
        }

        private void UpdateComboList()
        {
            //Die Daten aus der Liste in die ComboBox übertragen
            cbrecentpaths.Items.Clear();

            for (int i = 0; i < 10; i++)
            {
                cbrecentpaths.Items.Add(recentpaths[i]);
            }
        }

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

        }
    }
}
