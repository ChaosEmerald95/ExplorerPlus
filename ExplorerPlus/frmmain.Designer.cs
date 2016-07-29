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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslbelementcount = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.statuspanel = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.formpanel = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.explorerplusfstv = new ExplorerPlus.API.Controls.ExplorerPlusFilesystemView();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.explorerplusnfs = new ExplorerPlus.API.Controls.ExplorerPlusNetworkFilesystem();
            this.explorerplusfv = new ExplorerPlus.API.Controls.ExplorerPlusFileView();
            this.explorerplusmenubar = new ExplorerPlus.API.Controls.ExplorerPlusMenuBarExtend();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbelementcount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 649);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1293, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslbelementcount
            // 
            this.tslbelementcount.ForeColor = System.Drawing.Color.MediumBlue;
            this.tslbelementcount.Name = "tslbelementcount";
            this.tslbelementcount.Size = new System.Drawing.Size(0, 17);
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter3.Location = new System.Drawing.Point(203, 469);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(893, 3);
            this.splitter3.TabIndex = 18;
            this.splitter3.TabStop = false;
            // 
            // statuspanel
            // 
            this.statuspanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statuspanel.Location = new System.Drawing.Point(203, 472);
            this.statuspanel.Name = "statuspanel";
            this.statuspanel.Size = new System.Drawing.Size(893, 177);
            this.statuspanel.TabIndex = 17;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(1096, 32);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 617);
            this.splitter2.TabIndex = 16;
            this.splitter2.TabStop = false;
            // 
            // formpanel
            // 
            this.formpanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.formpanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.formpanel.Location = new System.Drawing.Point(1099, 32);
            this.formpanel.Name = "formpanel";
            this.formpanel.Size = new System.Drawing.Size(194, 617);
            this.formpanel.TabIndex = 15;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(200, 32);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 617);
            this.splitter1.TabIndex = 14;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.explorerplusfstv);
            this.panel1.Controls.Add(this.splitter4);
            this.panel1.Controls.Add(this.explorerplusnfs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 617);
            this.panel1.TabIndex = 13;
            // 
            // explorerplusfstv
            // 
            this.explorerplusfstv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.explorerplusfstv.Location = new System.Drawing.Point(0, 0);
            this.explorerplusfstv.Name = "explorerplusfstv";
            this.explorerplusfstv.Size = new System.Drawing.Size(200, 437);
            this.explorerplusfstv.TabIndex = 2;
            this.explorerplusfstv.SelectedPathChanged += new ExplorerPlus.API.ExplorerPlusFilesystemHandler(this.explorerplusfstv_SelectedPathChanged);
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter4.Location = new System.Drawing.Point(0, 437);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(200, 3);
            this.splitter4.TabIndex = 1;
            this.splitter4.TabStop = false;
            // 
            // explorerplusnfs
            // 
            this.explorerplusnfs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.explorerplusnfs.Location = new System.Drawing.Point(0, 440);
            this.explorerplusnfs.Name = "explorerplusnfs";
            this.explorerplusnfs.Size = new System.Drawing.Size(200, 177);
            this.explorerplusnfs.TabIndex = 0;
            this.explorerplusnfs.SelectedPathChanged += new ExplorerPlus.API.ExplorerPlusFilesystemHandler(this.explorerplusnfs_SelectedPathChanged);
            // 
            // explorerplusfv
            // 
            this.explorerplusfv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.explorerplusfv.Location = new System.Drawing.Point(203, 32);
            this.explorerplusfv.Name = "explorerplusfv";
            this.explorerplusfv.SelectedPath = "";
            this.explorerplusfv.Size = new System.Drawing.Size(893, 437);
            this.explorerplusfv.TabIndex = 19;
            this.explorerplusfv.LoadedPath += new ExplorerPlus.API.ExplorerPlusFilesystemHandler(this.explorerplusfv_FileListLoaded);
            // 
            // explorerplusmenubar
            // 
            this.explorerplusmenubar.BackColor = System.Drawing.Color.White;
            this.explorerplusmenubar.Dock = System.Windows.Forms.DockStyle.Top;
            this.explorerplusmenubar.Location = new System.Drawing.Point(0, 0);
            this.explorerplusmenubar.MenuBarURLText = "";
            this.explorerplusmenubar.Name = "explorerplusmenubar";
            this.explorerplusmenubar.Size = new System.Drawing.Size(1293, 32);
            this.explorerplusmenubar.TabIndex = 2;
            this.explorerplusmenubar.MenuSelectpathChanged += new ExplorerPlus.API.ExplorerPlusFilesystemHandler(this.explorerplusmenubar_MenuSelectpathChanged);
            // 
            // frmmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1293, 671);
            this.Controls.Add(this.explorerplusfv);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.statuspanel);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.formpanel);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.explorerplusmenubar);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmmain";
            this.Text = "ExplorerPlus";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslbelementcount;
        private API.Controls.ExplorerPlusMenuBarExtend explorerplusmenubar;
        private API.Controls.ExplorerPlusFileView explorerplusfv;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel statuspanel;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel formpanel;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private API.Controls.ExplorerPlusFilesystemView explorerplusfstv;
        private System.Windows.Forms.Splitter splitter4;
        private API.Controls.ExplorerPlusNetworkFilesystem explorerplusnfs;
    }
}

