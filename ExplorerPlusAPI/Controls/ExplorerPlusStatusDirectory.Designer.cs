namespace ExplorerPlus.API.Controls
{
    partial class ExplorerPlusStatusDirectory
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbsize = new System.Windows.Forms.Label();
            this.lblasteditdate = new System.Windows.Forms.Label();
            this.lbcreatedata = new System.Windows.Forms.Label();
            this.lbfoldername = new System.Windows.Forms.Label();
            this.picimage = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvinhalt = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.thrtimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picimage)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(543, 251);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbsize);
            this.tabPage1.Controls.Add(this.lblasteditdate);
            this.tabPage1.Controls.Add(this.lbcreatedata);
            this.tabPage1.Controls.Add(this.lbfoldername);
            this.tabPage1.Controls.Add(this.picimage);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(535, 225);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Allgemein";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbsize
            // 
            this.lbsize.AutoSize = true;
            this.lbsize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsize.Location = new System.Drawing.Point(83, 101);
            this.lbsize.Name = "lbsize";
            this.lbsize.Size = new System.Drawing.Size(43, 16);
            this.lbsize.TabIndex = 3;
            this.lbsize.Text = "lbsize";
            // 
            // lblasteditdate
            // 
            this.lblasteditdate.AutoSize = true;
            this.lblasteditdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblasteditdate.Location = new System.Drawing.Point(83, 75);
            this.lblasteditdate.Name = "lblasteditdate";
            this.lblasteditdate.Size = new System.Drawing.Size(89, 16);
            this.lblasteditdate.TabIndex = 3;
            this.lblasteditdate.Text = "lblasteditdate";
            // 
            // lbcreatedata
            // 
            this.lbcreatedata.AutoSize = true;
            this.lbcreatedata.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcreatedata.Location = new System.Drawing.Point(83, 48);
            this.lbcreatedata.Name = "lbcreatedata";
            this.lbcreatedata.Size = new System.Drawing.Size(84, 16);
            this.lbcreatedata.TabIndex = 4;
            this.lbcreatedata.Text = "lbcreatedate";
            // 
            // lbfoldername
            // 
            this.lbfoldername.AutoSize = true;
            this.lbfoldername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfoldername.Location = new System.Drawing.Point(83, 21);
            this.lbfoldername.Name = "lbfoldername";
            this.lbfoldername.Size = new System.Drawing.Size(87, 16);
            this.lbfoldername.TabIndex = 5;
            this.lbfoldername.Text = "lbfoldername";
            // 
            // picimage
            // 
            this.picimage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picimage.Location = new System.Drawing.Point(19, 16);
            this.picimage.Name = "picimage";
            this.picimage.Size = new System.Drawing.Size(48, 48);
            this.picimage.TabIndex = 2;
            this.picimage.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvinhalt);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(535, 225);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Inhalt";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvinhalt
            // 
            this.lvinhalt.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvinhalt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvinhalt.Location = new System.Drawing.Point(3, 3);
            this.lvinhalt.Name = "lvinhalt";
            this.lvinhalt.Size = new System.Drawing.Size(529, 219);
            this.lvinhalt.TabIndex = 1;
            this.lvinhalt.UseCompatibleStateImageBehavior = false;
            this.lvinhalt.View = System.Windows.Forms.View.Details;
            this.lvinhalt.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Dateiname";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Änderungsdatum";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Größe";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Anteil";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(529, 219);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wird geladen...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // thrtimer
            // 
            this.thrtimer.Interval = 1000;
            this.thrtimer.Tick += new System.EventHandler(this.thrtimer_Tick);
            // 
            // ExplorerPlusStatusDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ExplorerPlusStatusDirectory";
            this.Size = new System.Drawing.Size(543, 251);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picimage)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lbsize;
        private System.Windows.Forms.Label lblasteditdate;
        private System.Windows.Forms.Label lbcreatedata;
        private System.Windows.Forms.Label lbfoldername;
        private System.Windows.Forms.PictureBox picimage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvinhalt;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Timer thrtimer;
    }
}
