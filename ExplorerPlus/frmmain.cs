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
            explorerplusnfs.Start();
        }

        private void explorerplusfstv_SelectedPathChanged(string path)
        {
            //Den Pfad an ExplorerPlusFileView übergeben, damit die Anzeige für den Pfad geladen werden kann
            explorerplusfv.SelectedPath = path;

            //Nur Testweise
            explorerPlusFilesystemList1.AktuellerPfad = path;
        }

        private void explorerplusfv_FileListLoaded(string path)
        {
            //Jetzt die Anzahl der Elemente in der FileList in die Statusleiste einfügen
            if (explorerplusfv.FileListCount == 1)
                tslbelementcount.Text = "1 Element";
            else
                tslbelementcount.Text = explorerplusfv.FileListCount + " Elemente";
        }

        private void explorerplusnfs_SelectedPathChanged(string path)
        {
            //Den Pfad an ExplorerPlusFileView übergeben, damit die Anzeige für den Pfad geladen werden kann
            explorerplusfv.SelectedPath = path;
        }
    }
}
