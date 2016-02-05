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
        public event ExplorerPlusControlsHandler StorageInfoChanged;

        public ExplorerPlusStatusDrive()
        {
            InitializeComponent();
        }

        private void storageinfotimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
