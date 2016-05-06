using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExplorerPlus.API.Controls
{
    public partial class ExplorerPlusStatusDrive : UserControl
    {
        //Events
        public event ExplorerPlusFilesystemHandler StorageInfoChanged;

        private char driveletter;

        public ExplorerPlusStatusDrive(char driveletter)
        {
            InitializeComponent();
            this.driveletter = driveletter;
            LoadStorageInfo();
            storageinfotimer.Start();
        }

        private void LoadStorageInfo()
        {
            System.IO.DriveInfo drvinfo = new System.IO.DriveInfo(driveletter.ToString());
            picimage.BackgroundImage = FilesystemIcons.GetLargeIcon(drvinfo.Name.Substring(0, 2) + @"\").ToBitmap();

            //Daten eintragen
            lbdrivename.Text = DriveFunctions.GetVolumeLabel(driveletter) + " (" + driveletter.ToString().ToUpper() + ":)";
            lbmodel.Text = DriveFunctions.GetDriveModelName(DriveFunctions.GetPartitionData(driveletter.ToString())[0]);
            lbdiskindex.Text = "Disk-Index: " + DriveFunctions.GetPartitionData(driveletter.ToString())[0];
            lbpartindex.Text = "Partition-Index: " + DriveFunctions.GetPartitionData(driveletter.ToString())[1];
        }

        private void storageinfotimer_Tick(object sender, EventArgs e)
        {
            //Die Zahlen zur aktuellen Partition erhalten
            ulong[] values = DriveFunctions.GetPartitionSizeData(driveletter);

            //Die Zahlen in die Felder eintragen
            lbsizefilledbyte.Text = ExtraFunctions.GetNumberWithPoints(Convert.ToDouble(values[2]));
            lbsizefreebyte.Text = ExtraFunctions.GetNumberWithPoints(Convert.ToDouble(values[1]));
            lbsizegesbyte.Text = ExtraFunctions.GetNumberWithPoints(Convert.ToDouble(values[0]));

            lbsizefilled.Text = ExtraFunctions.UnitChange(Convert.ToDouble(values[2]));
            lbsizefree.Text = ExtraFunctions.UnitChange(Convert.ToDouble(values[1]));
            lbsizeges.Text = ExtraFunctions.UnitChange(Convert.ToDouble(values[0]));

            //Jetzt muss der Balken gezeichnet werden. Die Farbe ist AquaMarine
            Graphics g = picstoragebar.CreateGraphics();
            g.Clear(Color.LightGray);
            Color fillcolor = Color.Aqua;
            Brush brush = new SolidBrush(fillcolor);

            //Die Werte müssen gezeichnet werden. Da die Größe des Balkens sich verändern kann, muss es
            //dynamisch berechnet werden können
            double percentfilled = values[2] * 100 / values[0];
            double lenbar = picstoragebar.Size.Width / 100 * percentfilled;

            //Die Bar wird jetzt gezeichnet
            g.FillRectangle(brush, 0, 0, Convert.ToSingle(lenbar), picstoragebar.Size.Height);

            //Die Objekte disposen (da die viel RAM verbrauchen)
            g.Dispose();
            brush.Dispose();

            //Das Textlabel mit den Speicher auch aktualisieren
            lbstorageinfo.Text = ExtraFunctions.UnitChange(Convert.ToDouble(values[1])) + " frei von " + ExtraFunctions.UnitChange(Convert.ToDouble(values[0]));
        }
    }
}
