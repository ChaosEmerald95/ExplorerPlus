namespace ExplorerPlus
{
    partial class frmmain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslbelementcount = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.explorerplusfstv = new ExplorerPlus.API.Controls.ExplorerPlusFilesystemView();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.explorerplusnfs = new ExplorerPlus.API.Controls.ExplorerPlusNetworkFilesystem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.formpanel = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.statuspanel = new System.Windows.Forms.Panel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.explorerplusfv = new ExplorerPlus.API.Controls.ExplorerPlusFileView();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1117, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbelementcount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 542);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1117, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslbelementcount
            // 
            this.tslbelementcount.ForeColor = System.Drawing.Color.MediumBlue;
            this.tslbelementcount.Name = "tslbelementcount";
            this.tslbelementcount.Size = new System.Drawing.Size(0, 17);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.explorerplusfstv);
            this.panel1.Controls.Add(this.splitter4);
            this.panel1.Controls.Add(this.explorerplusnfs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 518);
            this.panel1.TabIndex = 6;
            // 
            // explorerplusfstv
            // 
            this.explorerplusfstv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.explorerplusfstv.Location = new System.Drawing.Point(0, 0);
            this.explorerplusfstv.Name = "explorerplusfstv";
            this.explorerplusfstv.Size = new System.Drawing.Size(200, 338);
            this.explorerplusfstv.TabIndex = 2;
            this.explorerplusfstv.SelectedPathChanged += new ExplorerPlus.API.Controls.ExplorerPlusControlsHandler(this.explorerplusfstv_SelectedPathChanged);
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter4.Location = new System.Drawing.Point(0, 338);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(200, 3);
            this.splitter4.TabIndex = 1;
            this.splitter4.TabStop = false;
            // 
            // explorerplusnfs
            // 
            this.explorerplusnfs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.explorerplusnfs.Location = new System.Drawing.Point(0, 341);
            this.explorerplusnfs.Name = "explorerplusnfs";
            this.explorerplusnfs.Size = new System.Drawing.Size(200, 177);
            this.explorerplusnfs.TabIndex = 0;
            this.explorerplusnfs.SelectedPathChanged += new ExplorerPlus.API.Controls.ExplorerPlusControlsHandler(this.explorerplusnfs_SelectedPathChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(200, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 518);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // formpanel
            // 
            this.formpanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.formpanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.formpanel.Location = new System.Drawing.Point(943, 24);
            this.formpanel.Name = "formpanel";
            this.formpanel.Size = new System.Drawing.Size(174, 518);
            this.formpanel.TabIndex = 8;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(940, 24);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 518);
            this.splitter2.TabIndex = 9;
            this.splitter2.TabStop = false;
            // 
            // statuspanel
            // 
            this.statuspanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statuspanel.Location = new System.Drawing.Point(203, 405);
            this.statuspanel.Name = "statuspanel";
            this.statuspanel.Size = new System.Drawing.Size(737, 137);
            this.statuspanel.TabIndex = 10;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter3.Location = new System.Drawing.Point(203, 402);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(737, 3);
            this.splitter3.TabIndex = 11;
            this.splitter3.TabStop = false;
            // 
            // explorerplusfv
            // 
            this.explorerplusfv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.explorerplusfv.Location = new System.Drawing.Point(203, 24);
            this.explorerplusfv.Name = "explorerplusfv";
            this.explorerplusfv.SelectedPath = "";
            this.explorerplusfv.Size = new System.Drawing.Size(737, 378);
            this.explorerplusfv.TabIndex = 12;
            this.explorerplusfv.FileListLoaded += new ExplorerPlus.API.Controls.ExplorerPlusControlsHandler(this.explorerplusfv_FileListLoaded);
            // 
            // frmmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1117, 564);
            this.Controls.Add(this.explorerplusfv);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.statuspanel);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.formpanel);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmmain";
            this.Text = "ExplorerPlus";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslbelementcount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel formpanel;
        private API.Controls.ExplorerPlusNetworkFilesystem explorerplusnfs;
        private System.Windows.Forms.Panel statuspanel;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Splitter splitter2;
        private API.Controls.ExplorerPlusFileView explorerplusfv;
        private System.Windows.Forms.Splitter splitter4;
        private API.Controls.ExplorerPlusFilesystemView explorerplusfstv;
    }
}

