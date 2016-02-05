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
    public partial class ExplorerPlusFileView : UserControl
    {
        private string _selectedpath = "";

        //Events
        public event ExplorerPlusControlsHandler SelectedFileClick;
        public event ExplorerPlusControlsHandler SelectedFileDoubleClick;
        public event ExplorerPlusControlsHandler FileListLoaded;

        public ExplorerPlusFileView()
        {
            InitializeComponent();
        }

        public string SelectedPath
        {
            get { return _selectedpath; }
            set
            {
                _selectedpath = value;
                LoadFileList();
            }
        }

        public int FileListCount
        {
            get { return lvfiles.Items.Count; }
        }

        public void LoadFileList()
        {
            //Diese Methode wird automatisch ausgeführt, wenn der selectedpath geändert wird
            //Wenn _selectedpath leer ist, Methode sofort abbrechen
            if (_selectedpath == "")
                return;
            //Prüfen, ob der Pfad auch wirklich existiert
            if (Directory.Exists(_selectedpath) == false)
            {
                MessageBox.Show("Fehler beim Laden der Dateien aus dem Verzeichnis " + _selectedpath + "!", "Ladefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Alles clearen
            lvfiles.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(_selectedpath);

            //ImageListen vorbereiten. Es werden jeweils 2 erstellt, einmal für die SmallIcons und
            //einmal für die LargeIcons
            ImageList sil = new ImageList();
            ImageList lil = new ImageList();
            sil.ColorDepth = ColorDepth.Depth32Bit;
            sil.ImageSize = new Size(16, 16);
            lil.ColorDepth = ColorDepth.Depth32Bit;
            lil.ImageSize = new Size(48, 48);
            sil.Images.Add(FilesystemIcons.ICON_FILE_16x);
            lil.Images.Add(FilesystemIcons.ICON_FILE_32x);

            //ImageListen zuweisen
            lvfiles.SmallImageList = sil;
            lvfiles.LargeImageList = lil;

            //Nun wird die Liste gefüllt
            foreach (FileInfo file in dir.GetFiles())
            {
                //Anhand der Erweiterung schauen, ob es eine Verknüpfung ist oder nicht
                try
                {
                    if (file.Extension == ".lnk")
                    {
                        sil.Images.Add(FilesystemIcons.GetSmallIcon(FileFunctions.GetShortcutPath(file.FullName)));
                        lil.Images.Add(FilesystemIcons.GetLargeIcon(FileFunctions.GetShortcutPath(file.FullName)));
                    }
                    else
                    {
                        try
                        {
                            sil.Images.Add(FilesystemIcons.GetSmallIcon(file.FullName));
                            lil.Images.Add(FilesystemIcons.GetLargeIcon(file.FullName));
                        }
                        catch
                        {             
                            sil.Images.Add(FilesystemIcons.GetIconByExtension_x16(file.Extension));
                            lil.Images.Add(FilesystemIcons.GetIconByExtension_x32(file.Extension));
                        }
                    }
                    ListViewItem lvi = new ListViewItem(file.Name, lvfiles.SmallImageList.Images.Count - 1);
                    lvi.SubItems.Add(file.LastWriteTime.ToString());
                    lvi.SubItems.Add(FileFunctions.GetFileTypeDescription(file.Extension));

                    //Wenn die dateigröße unter 1024 Bytes ist, soll stattdessen 1 KB ausgegeben werden
                    System.Diagnostics.Debug.Print("Byte: " + file.Length.ToString());
                    if (file.Length < 1024)
                    {
                        lvi.SubItems.Add("1 KB");
                    }
                    else
                    {
                        lvi.SubItems.Add(ExtraFunctions.GetFileSizeKB(Convert.ToDouble(file.Length)));
                    }
                    lvfiles.Items.Add(lvi);
                }
                catch (UnauthorizedAccessException )
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
                    lvfiles.Items.Add(lvi);
                }
            }

            //Event auslösen
            if (FileListLoaded != null)
                FileListLoaded(_selectedpath);
        }

        private void lvfiles_Click(object sender, EventArgs e)
        {
            string p = _selectedpath + @"\" + lvfiles.SelectedItems[0].Text; //Pfad zur Exe erhalten
            if (SelectedFileClick != null)
                SelectedFileClick(p);
        }

        private void lvfiles_DoubleClick(object sender, EventArgs e)
        {
            string p = _selectedpath + @"\" + lvfiles.SelectedItems[0].Text; //Pfad zur Exe erhalten
            if (SelectedFileDoubleClick != null)
                SelectedFileDoubleClick(p);
        }
    }
}
