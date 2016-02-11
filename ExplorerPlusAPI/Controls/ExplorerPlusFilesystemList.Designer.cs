namespace ExplorerPlus.API.Controls
{
    partial class ExplorerPlusFilesystemList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerPlusFilesystemList));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnforward = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.cbrecentpaths = new System.Windows.Forms.ComboBox();
            this.lvfs = new System.Windows.Forms.ListView();
            this.chname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chlastchange = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chtype = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chsize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnforward);
            this.panel1.Controls.Add(this.btnback);
            this.panel1.Controls.Add(this.btndelete);
            this.panel1.Controls.Add(this.btnadd);
            this.panel1.Controls.Add(this.cbrecentpaths);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 25);
            this.panel1.TabIndex = 0;
            // 
            // btnforward
            // 
            this.btnforward.FlatAppearance.BorderSize = 0;
            this.btnforward.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnforward.Image = ((System.Drawing.Image)(resources.GetObject("btnforward.Image")));
            this.btnforward.Location = new System.Drawing.Point(26, 1);
            this.btnforward.Name = "btnforward";
            this.btnforward.Size = new System.Drawing.Size(26, 23);
            this.btnforward.TabIndex = 2;
            this.btnforward.UseVisualStyleBackColor = true;
            this.btnforward.Click += new System.EventHandler(this.btnforward_Click);
            // 
            // btnback
            // 
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnback.Image = ((System.Drawing.Image)(resources.GetObject("btnback.Image")));
            this.btnback.Location = new System.Drawing.Point(3, 1);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(24, 23);
            this.btnback.TabIndex = 2;
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btndelete
            // 
            this.btndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btndelete.Image = ((System.Drawing.Image)(resources.GetObject("btndelete.Image")));
            this.btndelete.Location = new System.Drawing.Point(354, 1);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(26, 23);
            this.btndelete.TabIndex = 1;
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnadd
            // 
            this.btnadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnadd.Image = ((System.Drawing.Image)(resources.GetObject("btnadd.Image")));
            this.btnadd.Location = new System.Drawing.Point(329, 1);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(26, 23);
            this.btnadd.TabIndex = 1;
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // cbrecentpaths
            // 
            this.cbrecentpaths.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbrecentpaths.FormattingEnabled = true;
            this.cbrecentpaths.Location = new System.Drawing.Point(58, 2);
            this.cbrecentpaths.Name = "cbrecentpaths";
            this.cbrecentpaths.Size = new System.Drawing.Size(270, 21);
            this.cbrecentpaths.TabIndex = 0;
            this.cbrecentpaths.SelectedIndexChanged += new System.EventHandler(this.cbrecentpaths_SelectedIndexChanged);
            this.cbrecentpaths.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbrecentpaths_KeyDown);
            // 
            // lvfs
            // 
            this.lvfs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chname,
            this.chlastchange,
            this.chtype,
            this.chsize});
            this.lvfs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvfs.Location = new System.Drawing.Point(0, 25);
            this.lvfs.Name = "lvfs";
            this.lvfs.Size = new System.Drawing.Size(381, 467);
            this.lvfs.TabIndex = 1;
            this.lvfs.UseCompatibleStateImageBehavior = false;
            this.lvfs.View = System.Windows.Forms.View.Details;
            this.lvfs.DoubleClick += new System.EventHandler(this.lvfs_DoubleClick);
            this.lvfs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvfs_KeyDown);
            // 
            // chname
            // 
            this.chname.Text = "Name";
            // 
            // chlastchange
            // 
            this.chlastchange.Text = "Änderungsdatum";
            // 
            // chtype
            // 
            this.chtype.Text = "Typ";
            // 
            // chsize
            // 
            this.chsize.Text = "Größe";
            // 
            // ExplorerPlusFilesystemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvfs);
            this.Controls.Add(this.panel1);
            this.Name = "ExplorerPlusFilesystemList";
            this.Size = new System.Drawing.Size(381, 492);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.ComboBox cbrecentpaths;
        private System.Windows.Forms.ListView lvfs;
        private System.Windows.Forms.Button btnforward;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.ColumnHeader chname;
        private System.Windows.Forms.ColumnHeader chlastchange;
        private System.Windows.Forms.ColumnHeader chtype;
        private System.Windows.Forms.ColumnHeader chsize;
        private System.Windows.Forms.Button btndelete;
    }
}
