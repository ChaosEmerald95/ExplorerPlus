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
    public partial class ExplorerPlusMenuBar : UserControl
    {
        //Events
        public event ExplorerPlusControlsMenuHandler MenuUndoButtonClicked;
        public event ExplorerPlusControlsMenuHandler MenuRedoButtonClicked;
        public event ExplorerPlusControlsMenuHandler MenuReloadButtonClicked;
        public event ExplorerPlusControlsMenuHandler MenuFolderupButtonClicked;
        public event ExplorerPlusFilesystemHandler MenuSelectpathChanged;

        public ExplorerPlusMenuBar()
        {
            InitializeComponent();
        }

        public bool EnableBackBtn
        {
            set { btnback.Enabled = value; }
        }

        public bool EnableForwardBtn
        {
            set { btnforward.Enabled = value; }
        }

        public string MenuBarURLText
        {
            set { cbfolderbar.Text = value; }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            if (MenuUndoButtonClicked != null)
                MenuUndoButtonClicked();
        }

        private void btnforward_Click(object sender, EventArgs e)
        {
            if (MenuRedoButtonClicked != null)
                MenuRedoButtonClicked(); 
        }

        private void btnoverfolder_Click(object sender, EventArgs e)
        {
            if (MenuFolderupButtonClicked != null)
                MenuFolderupButtonClicked();
        }

        private void cbfolderbar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //Wenn Enter gedrückt wurde
            {
                //Prüfen, ob es die Eingabe schon in der ComboBox gibt
                if (cbfolderbar.Items.Count > 0)
                {
                    bool found = false; 

                    for (int i = 0; i < cbfolderbar.Items.Count; i++)
                    {
                        if (cbfolderbar.Items[i].ToString() == cbfolderbar.Text)
                        {
                            found = true;
                            break;
                        } 
                    }

                    if (found == false)
                        cbfolderbar.Items.Add(cbfolderbar.Text);
                }
                else
                {
                    cbfolderbar.Items.Add(cbfolderbar.Text);
                }

                //Event auslösen.
                if (MenuSelectpathChanged != null)
                    MenuSelectpathChanged(cbfolderbar.Text);
            }
        }

        private void btnreload_Click(object sender, EventArgs e)
        {
            if (MenuReloadButtonClicked != null)
                MenuReloadButtonClicked();
        }
    }
}
