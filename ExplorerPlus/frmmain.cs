using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Weitere Namespaces
using ExplorerPlus.API;
using ExplorerPlus.API.Controls;

namespace ExplorerPlus
{
    public partial class frmmain : Form
    {
        public frmmain()
        {
            InitializeComponent();
            //explorerplusnfs.Start();
        }

        private void explorerplusfstv_SelectedPathChanged(string path)
        {
            //Den Pfad an ExplorerPlusFileView übergeben, damit die Anzeige für den Pfad geladen werden kann
            explorerplusfv.SelectedPath = path;
            explorerplusmenubar.MenuBarURLText = path;
            if (explorerplusmenubar.MenuBarURLText.Length > 0 && explorerplusmenubar.MenuBarURLText.Substring(explorerplusmenubar.MenuBarURLText.Length - 1,1) != @"\") //Wenn das \ noch fehlt, soll dies hinzugefügt werden
                explorerplusmenubar.MenuBarURLText += @"\";
        }

        private void explorerplusfv_FileListLoaded(string path)
        {
            //Jetzt die Anzahl der Elemente in der FileList in die Statusleiste einfügen
            if (explorerplusfv.FileListCount == 1)
                tslbelementcount.Text = "1 Element";
            else
                tslbelementcount.Text = explorerplusfv.FileListCount + " Elemente";

            explorerplusmenubar.MenuBarURLText = path;
            if (explorerplusmenubar.MenuBarURLText.Length > 0 && explorerplusmenubar.MenuBarURLText.Substring(explorerplusmenubar.MenuBarURLText.Length - 1, 1) != @"\") //Wenn das \ noch fehlt, soll dies hinzugefügt werden
                explorerplusmenubar.MenuBarURLText += @"\";
        }

        private void explorerplusnfs_SelectedPathChanged(string path)
        {
            //Den Pfad an ExplorerPlusFileView übergeben, damit die Anzeige für den Pfad geladen werden kann
            explorerplusfv.SelectedPath = path;
            explorerplusmenubar.MenuBarURLText = path;
            if (explorerplusmenubar.MenuBarURLText.Length > 0 && explorerplusmenubar.MenuBarURLText.Substring(explorerplusmenubar.MenuBarURLText.Length - 1, 1) != @"\") //Wenn das \ noch fehlt, soll dies hinzugefügt werden
                explorerplusmenubar.MenuBarURLText += @"\";
        }

        private void explorerplusfv_SelectedFileClick(string path, ENTRY_TYPE type)
        {
            //Anhand des Paths, der zurückgegeben wird, soll 
            switch (type)
            {
                case ENTRY_TYPE.Drive:
                    ExplorerPlusStatusDrive sdr = new ExplorerPlusStatusDrive(Convert.ToChar(path.Substring(0, 1)));
                    sdr.Dock = DockStyle.Fill;
                    statuspanel.Controls.Clear();
                    statuspanel.Controls.Add(sdr);
                    break;
                case ENTRY_TYPE.Directory:
                    ExplorerPlusStatusDirectory sd = new ExplorerPlusStatusDirectory(path);
                    sd.Dock = DockStyle.Fill;
                    statuspanel.Controls.Clear();
                    statuspanel.Controls.Add(sd);
                    break;
            }
        }

        private void explorerplusmenubar_MenuSelectpathChanged(string path)
        {
            if (explorerplusmenubar.MenuBarURLText.Length > 0 && explorerplusmenubar.MenuBarURLText.Substring(explorerplusmenubar.MenuBarURLText.Length - 1, 1) != @"\") //Wenn das \ noch fehlt, soll dies hinzugefügt werden
                explorerplusmenubar.MenuBarURLText += @"\";
            explorerplusfv.SelectedPath = explorerplusmenubar.MenuBarURLText;
        }
    }
}
