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
using System.Threading;

namespace ExplorerPlus.API.Controls
{
    public partial class ExplorerPlusStatusDirectory : UserControl
    {
        private delegate void EntryAdding(string entry, string type, string lastchange, long size);

        private string dirpath = "";
        private Thread thr;
        private DataTable dt;

        EntryAdding ea;

        private void AddEntry(string entry, string type, string lastchange, long size)
        {
            DataRow r = dt.NewRow();
            r[0] = entry;
            r[1] = type;
            r[2] = lastchange; 
            r[3] = size;
            dt.Rows.Add(r);
        }

        public ExplorerPlusStatusDirectory(string dirpath)
        {
            InitializeComponent();
            this.dirpath = dirpath;
            ea = new EntryAdding(AddEntry);
            PrepareDt();
            LoadDirectoryInfo(); //Grundinformationen laden
            thr = new Thread(new ThreadStart(GetFolderSizeThisFolder));
            thr.Start(); //Thread starten. Dieser wird jetzt die Daten dazu ermitteln
            thrtimer.Start(); //Der Timer wird gestartet und überprüft, ob der Thread bereits durchgelaufen ist
        }

        private void PrepareDt()
        {
            dt = new DataTable();
            dt.Columns.Add("Entry");
            dt.Columns.Add("Type");
            dt.Columns.Add("LastChanged");
            dt.Columns.Add("Size",typeof(long));
        }

        private void LoadDirectoryInfo()
        { 
            DirectoryInfo d = new DirectoryInfo(dirpath);
            lbfoldername.Text = d.Name;
            lbcreatedata.Text = d.CreationTime.ToString();
            lblasteditdate.Text = d.LastWriteTime.ToString();
            lbsize.Text = "Wird geladen";
        }

        private void LoadLastData()
        {
            //Maximale Bytezahl berechnen
            long gesbyte = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
                gesbyte += Convert.ToInt64(dt.Rows[i].ItemArray[3].ToString());

            //Einträge in der DataTable nach Size sortieren
            DataView v = dt.DefaultView; 
            v.Sort = "Size DESC";
            
            //ListView füllen
            ImageList img = new ImageList();
            img.ColorDepth = ColorDepth.Depth32Bit;
            img.ImageSize = new Size(16, 16);
            lvinhalt.SmallImageList = img;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                long size = Convert.ToInt64(v[i].Row.ItemArray[3].ToString());
                ListViewItem lvi = new ListViewItem(v[i].Row.ItemArray[0].ToString());
                lvi.SubItems.Add(v[i].Row.ItemArray[2].ToString());
                lvi.SubItems.Add(ExtraFunctions.GetFileSizeKB(Convert.ToDouble(size)));
                
                //Grafik einblenden
                if (v[i].Row.ItemArray[1].ToString() == "Folder")
                {
                    img.Images.Add(FilesystemIcons.GetSmallIcon(DirectoryFunctions.CorrectPath(dirpath)));
                }
                else
                {
                    FileInfo f = new FileInfo(DirectoryFunctions.CorrectPath(dirpath) + v[i].Row.ItemArray[0].ToString());
                    try
                    {
                        if (f.Extension == ".lnk")
                            img.Images.Add(FilesystemIcons.GetSmallIcon(FileFunctions.GetShortcutPath(f.FullName)));
                        else
                            img.Images.Add(FilesystemIcons.GetSmallIcon(f.FullName));
                    }
                    catch
                    {
                        img.Images.Add(FilesystemIcons.GetIconByExtension_x16(f.Extension));
                    }
                }
                lvi.ImageIndex = img.Images.Count - 1;
                lvi.SubItems.Add(Math.Round(Convert.ToDouble(size * 100 / gesbyte), 2).ToString() + "%");

                lvinhalt.Items.Add(lvi);                
            }

            lbsize.Text = ExtraFunctions.UnitChange(Convert.ToDouble(gesbyte));
            tabPage2.Controls.RemoveAt(0);
        }

        /// <summary>
        /// Gibt die Größendaten zurück
        /// !In einem zusätzlichen Thread ausführen, um das Programm nicht zu behindern
        /// </summary>
        private void GetFolderSizeThisFolder()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(dirpath); //Es ist eine DirectoryInfo notwendig
                for (int i = 0; i < dir.GetDirectories().Length; i++)
                {
                    try
                    {
                        DirectoryInfo d = dir.GetDirectories()[i];
                        ea.Invoke(d.Name, "Folder", d.LastWriteTime.ToString(), DirectoryFunctions.GetFolderSize(d.FullName));
                    }
                    catch { }
                }

                for (int i = 0; i < dir.GetFiles().Length; i++)
                {
                    try
                    {
                        FileInfo f = dir.GetFiles()[i];
                        ea.Invoke(f.Name, "File", f.LastWriteTime.ToString(), f.Length);
                    }
                    catch { }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                System.Diagnostics.Debug.Print("Der Zugriff auf den Ordner '" + dirpath + "' ist wegen fehlender Berechtigungen verweigert");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Ein unbekannter Fehler ist beim Zugriff auf '" + dirpath + "' aufgetreten");
            }
        }

        private void thrtimer_Tick(object sender, EventArgs e)
        {
            if (thr.IsAlive == false)
            {
                thrtimer.Stop();
            }
        }
    }
}
