using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Threading;

namespace ExplorerPlus.API.Dialogs
{
    public partial class FileTransferDialog : Form
    {
        private const int TRANSFER_BYTE_BLOCK_SIZE = 2048; //So viele Bytes sollen pro Schreiben transferiert werden. Garantiert beste Bewertung der Transfergeschwindigkeit

        private bool m_ispaused = false; //Ob der Vorgang pausiert ist
        private int m_filecount = 0, m_fileakt = 0; //Dateiangaben
        private double m_gesbytetransfer = 0, m_bytespersec = 0, m_bytestransfered = 0; //Byteangaben
        private Thread m_thrtransfer; //Der Thread für den Transfer
        private string m_aktfilepath = ""; //Die aktuelle Datei, die transferiert wird
        private string m_destination = "";
        private List<string> m_filelist; //Eine Liste aller Dateien. Deren Größe wird erst beim Konstruktor festgelegt
        private TransferMode trans;

        public enum TransferMode
        {
            Copy,
            Cut
        }

        private enum ProgressBarColor
        {
            Green = 1,
            Red = 2,
            Yellow = 3
        }

        public FileTransferDialog(string file, string destinationdir, TransferMode mode)
        {
            InitializeComponent();
            m_filelist = new List<string>(1);
            m_filelist.Add(file);
            m_filecount = 1;
            m_destination = destinationdir;
            trans = mode;
            GetMaxBytesForTransfer();           
            m_thrtransfer = new Thread(new ThreadStart(ThreadTransfer));
        }

        public FileTransferDialog(string[] files, string destinationdir, TransferMode mode)
        {
            InitializeComponent();
            m_filelist = new List<string>(files.Length);
            foreach (string f in files)
                m_filelist.Add(f);
            m_filecount = files.Length;
            m_destination = destinationdir;
            trans = mode;
            GetMaxBytesForTransfer();           
            m_thrtransfer = new Thread(new ThreadStart(ThreadTransfer));           
        }

        private void ShowTextInForm()
        {
            if (m_ispaused == false) //Wenn der Vorgang noch läuft
            {
                //1. lbtransferinfo. Dazu muss festgestellt werden, wie viele Dateien transferiert werden müssen
                if (m_filecount == 1)
                    lbtransferinfo.Text = "Kopieren von 1 Datei (" + ExtraFunctions.UnitChange(m_gesbytetransfer) + ")";
                else
                    lbtransferinfo.Text = "Kopieren von " + m_filecount.ToString() + " Dateien (" + ExtraFunctions.UnitChange(m_gesbytetransfer) + ")";

                //2. lbtransferplace. Dort wird der Pfad eingetragen, der auch das Ziel ist
                lbtransferplace.Text = "Nach " + ExtraFunctions.ShortText(m_destination, 70, true); //Soll am Anfang gekürzt werden

                //3. progresstransfer und Form
                double progresspercent = Math.Round(Math.Floor(m_bytestransfered * 100 / m_gesbytetransfer), 0); //Prozent ermitteln, die bereits transferiert wurden
                progresstransfer.Value = (int)progresspercent; //Value übergeben. Kann als Integer gecastet werden
                Text = progresspercent.ToString() + "% abgeschlossen";

                //4. lbname
                lbname.Text = "Name: " + Path.GetFileName(m_aktfilepath);

                //5. lbspeed
                lbspeed.Text = "Speed: " + ExtraFunctions.UnitChange(m_bytespersec) + "/s"; //Einfache Ausgabe des Wertes

                //6. lbresttime
                if (m_bytespersec > 0) //Damit es berechnet werden kann, muss m_bytespersec IMMER größer als 0 sein
                {
                    int restsec = (int)Math.Floor((m_gesbytetransfer - m_bytestransfered) / m_bytespersec); //Restsekunden ermitteln
                    lbresttime.Text = "Restzeit: " + ExtraFunctions.TimeConverter(restsec);
                }
                else
                    lbresttime.Text = "Restzeit: Unbekannt";

                //7. lbrestbyte
                if (m_filecount - m_fileakt == 1)
                    lbrestbyte.Text = "Noch 1 Element (" + ExtraFunctions.UnitChange(m_gesbytetransfer - m_bytestransfered) + ")";
                else
                    lbrestbyte.Text = "Noch " + (m_filecount - m_fileakt).ToString() + " Elemente (" + ExtraFunctions.UnitChange(m_gesbytetransfer - m_bytestransfered) + ")";
            }
            else //Wenn der Vorgang pausiert ist
            {
                //1. lbtransferinfo. Dazu muss festgestellt werden, wie viele Dateien transferiert werden müssen
                if (m_filecount == 1)
                    lbtransferinfo.Text = "Kopieren von 1 Datei (" + ExtraFunctions.UnitChange(m_gesbytetransfer) + ")";
                else
                    lbtransferinfo.Text = "Kopieren von " + m_filecount.ToString() + " Dateien (" + ExtraFunctions.UnitChange(m_gesbytetransfer) + ")";

                //2. lbtransferplace. Dort wird der Pfad eingetragen, der auch das Ziel ist
                lbtransferplace.Text = "Nach " + ExtraFunctions.ShortText(m_destination, 70, true); //Soll am Anfang gekürzt werden

                //3. progresstransfer und Form
                double progresspercent = Math.Round(Math.Floor(m_bytestransfered * 100 / m_gesbytetransfer), 0); //Prozent ermitteln, die bereits transferiert wurden
                progresstransfer.Value = (int)progresspercent; //Value übergeben. Kann als Integer gecastet werden
                Text = progresspercent.ToString() + "% abgeschlossen - Angehalten";

                //4. lbname
                lbname.Text = "Name: " + Path.GetFileName(m_aktfilepath);

                //5. lbspeed
                lbspeed.Text = "Speed: 0 B/s"; //Einfache Ausgabe des Wertes

                //6. lbresttime
                lbresttime.Text = "Restzeit: Angehalten";

                //7. lbrestbyte
                if (m_filecount - m_fileakt == 1)
                    lbrestbyte.Text = "Noch 1 Element (" + ExtraFunctions.UnitChange(m_gesbytetransfer - m_bytestransfered) + ")";
                else
                    lbrestbyte.Text = "Noch " + (m_filecount - m_fileakt).ToString() + " Elemente (" + ExtraFunctions.UnitChange(m_gesbytetransfer - m_bytestransfered) + ")";
            }
        }

        private void progresstimer_Tick(object sender, EventArgs e)
        {
            m_bytestransfered += m_bytespersec;
            ShowTextInForm();
            m_bytespersec = 0; //Bytes per Second zurücksetzen
            if (m_thrtransfer.IsAlive == false) //Wenn der Thread nicht mehr existiert
            {
                progresstimer.Stop();
                Close();
            }
        }

        private void btnpause_Click(object sender, EventArgs e)
        {
            //Text bei dem Button "btnpause": Für Pause: Font = Arial, Text = "I I"; Für Resume: Font = Windings 3, Text = "U"
            if (m_ispaused) //Wenn der Vorgang pausiert ist
            {
                m_thrtransfer.Resume(); //TODO: Da die Methode veraltet ist, neue Lösung finden
                m_ispaused = false;
                btnpause.Font = new Font("Arial", 8);
                btnpause.Text = "I I";
                SetState(progresstransfer, ProgressBarColor.Green);
            }
            else
            {
                m_thrtransfer.Suspend();//TODO: Da die Methode veraltet ist, neue Lösung finden
                m_ispaused = true;
                btnpause.Font = new Font("Windings 3", 8);
                btnpause.Text = "U";
                SetState(progresstransfer, ProgressBarColor.Yellow);
            }
        }

        private void btnabort_Click(object sender, EventArgs e)
        {
            //Wenn auf den Button geklickt wurde, soll der ganze Vorgang abgebrochen werden
            m_thrtransfer.Abort();
            Close();
        }

        private void GetMaxBytesForTransfer()
        {
            //Da kommt FileInfo ins Spiel
            foreach (string f in m_filelist)
                m_gesbytetransfer += new FileInfo(f).Length; //Byte-Größe zu m_gesbytestransfer addieren 
        }

        private void FileTransferDialog_Load(object sender, EventArgs e)
        {
            ShowTextInForm();
            m_thrtransfer.Start();
            progresstimer.Start(); //Timer starten
        }

        /// <summary>
        /// Die Transfermethode für die Dateien. Die Größe des Byte-Arrays kann in TRANSFER_BYTE_BLOCK_SIZE festgelegt werden
        /// </summary>
        /// <param name="originfile"></param>
        /// <param name="destfile"></param>
        private void CopyAndPasteFile(string originfile, string destfile)
        {
            //TODO: Nachfragen bei Overriden der Datei
            Stream dest = new FileStream(destfile, FileMode.Create, FileAccess.Write);
            using (Stream source = File.OpenRead(originfile))
            {
                byte[] buffer = new byte[TRANSFER_BYTE_BLOCK_SIZE]; 
                int bytesRead;
                while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    dest.Write(buffer, 0, bytesRead);
                    m_bytespersec += bytesRead; //Bytes dazu addieren
                }
                source.Close();
            }
            dest.Close();
        }
        
        /// <summary>
        /// Der Transfer-Thread
        /// </summary>
        private void ThreadTransfer()
        {
            foreach (string f in m_filelist) //Jede Datei durchgehen
            {
                m_aktfilepath = f; //f speichern
                CopyAndPasteFile(f, m_destination + Path.GetFileName(f)); //Transfer
                if (trans == TransferMode.Cut) //Wenn das ganze ein CutPaste-Vorgang ist
                    File.Delete(f); //Da mit der Methode CopyAndPaste nur kopiert wird, muss das Original gelöscht werden
            }
        }

        private void SetState(ProgressBar pBar, ProgressBarColor color)
        {
            WinAPI.SendMessage(pBar.Handle, 1040, (IntPtr)color, IntPtr.Zero); //Funktion aus der statischen Klasse "WinAPI" verwenden
        }
    }
}
