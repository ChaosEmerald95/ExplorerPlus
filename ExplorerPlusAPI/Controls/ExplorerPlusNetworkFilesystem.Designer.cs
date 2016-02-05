namespace ExplorerPlus.API.Controls
{
    partial class ExplorerPlusNetworkFilesystem
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
            this.tvnfs = new System.Windows.Forms.TreeView();
            this.imglist = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // tvnfs
            // 
            this.tvnfs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvnfs.ImageIndex = 0;
            this.tvnfs.ImageList = this.imglist;
            this.tvnfs.Location = new System.Drawing.Point(0, 0);
            this.tvnfs.Name = "tvnfs";
            this.tvnfs.SelectedImageIndex = 0;
            this.tvnfs.Size = new System.Drawing.Size(150, 150);
            this.tvnfs.TabIndex = 0;
            this.tvnfs.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvnfs_BeforeExpand);
            this.tvnfs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvnfs_AfterSelect);
            // 
            // imglist
            // 
            this.imglist.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imglist.ImageSize = new System.Drawing.Size(16, 16);
            this.imglist.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ExplorerPlusNetworkFilesystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvnfs);
            this.Name = "ExplorerPlusNetworkFilesystem";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvnfs;
        private System.Windows.Forms.ImageList imglist;
    }
}
