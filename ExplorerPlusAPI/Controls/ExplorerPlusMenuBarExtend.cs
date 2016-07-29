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
    public partial class ExplorerPlusMenuBarExtend : UserControl
    {
        //Events
        public event ExplorerPlusControlsMenuHandler MenuUndoButtonClicked;
        public event ExplorerPlusControlsMenuHandler MenuRedoButtonClicked;
        public event ExplorerPlusControlsMenuHandler MenuReloadButtonClicked;
        public event ExplorerPlusControlsMenuHandler MenuFolderupButtonClicked;
        public event ExplorerPlusFilesystemHandler MenuSelectpathChanged;
        public event ExplorerPlusControlsMenuHandler MenuDeleteFileButtonClicked;
        public event ExplorerPlusControlsMenuHandler MenuNewFolderButtonClicked;
        public event ExplorerPlusFilesystemHandler MenuSearchButtonClicked;

        public ExplorerPlusMenuBarExtend()
        {
            InitializeComponent();
        }

        public bool EnableBackBtn
        {
            set { button3.Enabled = value; }
        }

        public bool EnableForwardBtn
        {
            set { button2.Enabled = value; }
        }

        public string MenuBarURLText
        {
            get { return cbfolderbar.Text; }
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MenuDeleteFileButtonClicked != null)
                MenuDeleteFileButtonClicked();
        }

        private void btnnewfolder_Click(object sender, EventArgs e)
        {
            if (MenuNewFolderButtonClicked != null)
                MenuNewFolderButtonClicked();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtsearchtext.TextLength > 0)
            {
                if (MenuSearchButtonClicked != null)
                    MenuSearchButtonClicked(txtsearchtext.Text);
            }
        }

        private void txtsearchtext_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtsearchtext.TextLength > 0) //Wenn Enter gedrückt wurde
            {
                if (MenuSearchButtonClicked != null)
                    MenuSearchButtonClicked(txtsearchtext.Text);
            }
        }
    }
}
