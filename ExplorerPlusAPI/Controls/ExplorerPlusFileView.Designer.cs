namespace ExplorerPlus.API.Controls
{
    partial class ExplorerPlusFileView
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
            this.lvfiles = new System.Windows.Forms.ListView();
            this.chname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chlastchange = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chtype = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chsize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvfiles
            // 
            this.lvfiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chname,
            this.chlastchange,
            this.chtype,
            this.chsize});
            this.lvfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvfiles.Location = new System.Drawing.Point(0, 0);
            this.lvfiles.Name = "lvfiles";
            this.lvfiles.Size = new System.Drawing.Size(387, 313);
            this.lvfiles.TabIndex = 0;
            this.lvfiles.UseCompatibleStateImageBehavior = false;
            this.lvfiles.View = System.Windows.Forms.View.Details;
            this.lvfiles.Click += new System.EventHandler(this.lvfiles_Click);
            this.lvfiles.DoubleClick += new System.EventHandler(this.lvfiles_DoubleClick);
            // 
            // chname
            // 
            this.chname.Text = "Name";
            this.chname.Width = 87;
            // 
            // chlastchange
            // 
            this.chlastchange.Text = "Änderungsdatum";
            this.chlastchange.Width = 102;
            // 
            // chtype
            // 
            this.chtype.Text = "Typ";
            this.chtype.Width = 81;
            // 
            // chsize
            // 
            this.chsize.Text = "Größe";
            this.chsize.Width = 86;
            // 
            // ExplorerPlusFileView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvfiles);
            this.Name = "ExplorerPlusFileView";
            this.Size = new System.Drawing.Size(387, 313);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvfiles;
        private System.Windows.Forms.ColumnHeader chname;
        private System.Windows.Forms.ColumnHeader chlastchange;
        private System.Windows.Forms.ColumnHeader chtype;
        private System.Windows.Forms.ColumnHeader chsize;
    }
}
