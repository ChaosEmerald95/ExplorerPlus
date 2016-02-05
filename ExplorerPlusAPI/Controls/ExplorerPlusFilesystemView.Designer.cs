namespace ExplorerPlus.API.Controls
{
    partial class ExplorerPlusFilesystemView
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tvfilesystem = new System.Windows.Forms.TreeView();
            this.imglist = new System.Windows.Forms.ImageList(this.components);
            this.drvchktimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tvfilesystem
            // 
            this.tvfilesystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvfilesystem.ImageIndex = 0;
            this.tvfilesystem.ImageList = this.imglist;
            this.tvfilesystem.Location = new System.Drawing.Point(0, 0);
            this.tvfilesystem.Name = "tvfilesystem";
            this.tvfilesystem.SelectedImageIndex = 0;
            this.tvfilesystem.Size = new System.Drawing.Size(150, 150);
            this.tvfilesystem.TabIndex = 0;
            this.tvfilesystem.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvfilesystem_BeforeExpand);
            this.tvfilesystem.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvfilesystem_AfterSelect);
            // 
            // imglist
            // 
            this.imglist.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imglist.ImageSize = new System.Drawing.Size(16, 16);
            this.imglist.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // drvchktimer
            // 
            this.drvchktimer.Interval = 1000;
            this.drvchktimer.Tick += new System.EventHandler(this.drvchktimer_Tick);
            // 
            // ExplorerPlusFilesystemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvfilesystem);
            this.Name = "ExplorerPlusFilesystemView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvfilesystem;
        private System.Windows.Forms.ImageList imglist;
        private System.Windows.Forms.Timer drvchktimer;
    }
}
