namespace ExplorerPlus.API.Controls
{
    partial class ExplorerPlusStatusDrive
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
            this.lbpartindex = new System.Windows.Forms.Label();
            this.lbdiskindex = new System.Windows.Forms.Label();
            this.lbmodel = new System.Windows.Forms.Label();
            this.lbdrivename = new System.Windows.Forms.Label();
            this.picimage = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbsizeges = new System.Windows.Forms.Label();
            this.lbsizegesbyte = new System.Windows.Forms.Label();
            this.lbsizefree = new System.Windows.Forms.Label();
            this.lbsizefreebyte = new System.Windows.Forms.Label();
            this.lbsizefilled = new System.Windows.Forms.Label();
            this.lbsizefilledbyte = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbstorageinfo = new System.Windows.Forms.Label();
            this.picstoragebar = new System.Windows.Forms.PictureBox();
            this.storageinfotimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picimage)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picstoragebar)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(517, 246);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbpartindex);
            this.tabPage1.Controls.Add(this.lbdiskindex);
            this.tabPage1.Controls.Add(this.lbmodel);
            this.tabPage1.Controls.Add(this.lbdrivename);
            this.tabPage1.Controls.Add(this.picimage);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(509, 220);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Allgemein";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbpartindex
            // 
            this.lbpartindex.AutoSize = true;
            this.lbpartindex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpartindex.Location = new System.Drawing.Point(85, 111);
            this.lbpartindex.Name = "lbpartindex";
            this.lbpartindex.Size = new System.Drawing.Size(74, 16);
            this.lbpartindex.TabIndex = 1;
            this.lbpartindex.Text = "lbpartindex";
            // 
            // lbdiskindex
            // 
            this.lbdiskindex.AutoSize = true;
            this.lbdiskindex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdiskindex.Location = new System.Drawing.Point(85, 80);
            this.lbdiskindex.Name = "lbdiskindex";
            this.lbdiskindex.Size = new System.Drawing.Size(76, 16);
            this.lbdiskindex.TabIndex = 1;
            this.lbdiskindex.Text = "lbdiskindex";
            // 
            // lbmodel
            // 
            this.lbmodel.AutoSize = true;
            this.lbmodel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmodel.Location = new System.Drawing.Point(85, 50);
            this.lbmodel.Name = "lbmodel";
            this.lbmodel.Size = new System.Drawing.Size(57, 16);
            this.lbmodel.TabIndex = 1;
            this.lbmodel.Text = "lbmodel";
            // 
            // lbdrivename
            // 
            this.lbdrivename.AutoSize = true;
            this.lbdrivename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdrivename.Location = new System.Drawing.Point(85, 23);
            this.lbdrivename.Name = "lbdrivename";
            this.lbdrivename.Size = new System.Drawing.Size(83, 16);
            this.lbdrivename.TabIndex = 1;
            this.lbdrivename.Text = "lbdrivename";
            // 
            // picimage
            // 
            this.picimage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picimage.Location = new System.Drawing.Point(21, 18);
            this.picimage.Name = "picimage";
            this.picimage.Size = new System.Drawing.Size(48, 48);
            this.picimage.TabIndex = 0;
            this.picimage.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbsizeges);
            this.tabPage2.Controls.Add(this.lbsizegesbyte);
            this.tabPage2.Controls.Add(this.lbsizefree);
            this.tabPage2.Controls.Add(this.lbsizefreebyte);
            this.tabPage2.Controls.Add(this.lbsizefilled);
            this.tabPage2.Controls.Add(this.lbsizefilledbyte);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.lbstorageinfo);
            this.tabPage2.Controls.Add(this.picstoragebar);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(509, 220);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Speichernutzung";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbsizeges
            // 
            this.lbsizeges.AutoSize = true;
            this.lbsizeges.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsizeges.Location = new System.Drawing.Point(419, 181);
            this.lbsizeges.Name = "lbsizeges";
            this.lbsizeges.Size = new System.Drawing.Size(66, 16);
            this.lbsizeges.TabIndex = 3;
            this.lbsizeges.Text = "lbsizeges";
            this.lbsizeges.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbsizegesbyte
            // 
            this.lbsizegesbyte.AutoSize = true;
            this.lbsizegesbyte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsizegesbyte.Location = new System.Drawing.Point(272, 181);
            this.lbsizegesbyte.Name = "lbsizegesbyte";
            this.lbsizegesbyte.Size = new System.Drawing.Size(92, 16);
            this.lbsizegesbyte.TabIndex = 3;
            this.lbsizegesbyte.Text = "lbsizegesbyte";
            this.lbsizegesbyte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbsizefree
            // 
            this.lbsizefree.AutoSize = true;
            this.lbsizefree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsizefree.Location = new System.Drawing.Point(419, 124);
            this.lbsizefree.Name = "lbsizefree";
            this.lbsizefree.Size = new System.Drawing.Size(66, 16);
            this.lbsizefree.TabIndex = 3;
            this.lbsizefree.Text = "lbsizefree";
            this.lbsizefree.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbsizefreebyte
            // 
            this.lbsizefreebyte.AutoSize = true;
            this.lbsizefreebyte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsizefreebyte.Location = new System.Drawing.Point(272, 124);
            this.lbsizefreebyte.Name = "lbsizefreebyte";
            this.lbsizefreebyte.Size = new System.Drawing.Size(92, 16);
            this.lbsizefreebyte.TabIndex = 3;
            this.lbsizefreebyte.Text = "lbsizefreebyte";
            this.lbsizefreebyte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbsizefilled
            // 
            this.lbsizefilled.AutoSize = true;
            this.lbsizefilled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsizefilled.Location = new System.Drawing.Point(419, 88);
            this.lbsizefilled.Name = "lbsizefilled";
            this.lbsizefilled.Size = new System.Drawing.Size(71, 16);
            this.lbsizefilled.TabIndex = 3;
            this.lbsizefilled.Text = "lbsizefilled";
            this.lbsizefilled.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbsizefilledbyte
            // 
            this.lbsizefilledbyte.AutoSize = true;
            this.lbsizefilledbyte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsizefilledbyte.Location = new System.Drawing.Point(272, 88);
            this.lbsizefilledbyte.Name = "lbsizefilledbyte";
            this.lbsizefilledbyte.Size = new System.Drawing.Size(97, 16);
            this.lbsizefilledbyte.TabIndex = 3;
            this.lbsizefilledbyte.Text = "lbsizefilledbyte";
            this.lbsizefilledbyte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(61, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Speicherkapazität";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Freier Speicher";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Belegter Speicher";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(21, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(32, 32);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Aqua;
            this.panel1.Location = new System.Drawing.Point(21, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(32, 32);
            this.panel1.TabIndex = 2;
            // 
            // lbstorageinfo
            // 
            this.lbstorageinfo.AutoSize = true;
            this.lbstorageinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbstorageinfo.ForeColor = System.Drawing.Color.Gray;
            this.lbstorageinfo.Location = new System.Drawing.Point(18, 46);
            this.lbstorageinfo.Name = "lbstorageinfo";
            this.lbstorageinfo.Size = new System.Drawing.Size(143, 16);
            this.lbstorageinfo.TabIndex = 1;
            this.lbstorageinfo.Text = "836 GB frei von 931 GB";
            // 
            // picstoragebar
            // 
            this.picstoragebar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picstoragebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picstoragebar.Location = new System.Drawing.Point(17, 17);
            this.picstoragebar.Name = "picstoragebar";
            this.picstoragebar.Size = new System.Drawing.Size(478, 24);
            this.picstoragebar.TabIndex = 0;
            this.picstoragebar.TabStop = false;
            // 
            // storageinfotimer
            // 
            this.storageinfotimer.Interval = 1000;
            this.storageinfotimer.Tick += new System.EventHandler(this.storageinfotimer_Tick);
            // 
            // ExplorerPlusStatusDrive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ExplorerPlusStatusDrive";
            this.Size = new System.Drawing.Size(517, 246);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picimage)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picstoragebar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lbsizeges;
        private System.Windows.Forms.Label lbsizegesbyte;
        private System.Windows.Forms.Label lbsizefree;
        private System.Windows.Forms.Label lbsizefreebyte;
        private System.Windows.Forms.Label lbsizefilled;
        private System.Windows.Forms.Label lbsizefilledbyte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbstorageinfo;
        private System.Windows.Forms.PictureBox picstoragebar;
        private System.Windows.Forms.Timer storageinfotimer;
        private System.Windows.Forms.PictureBox picimage;
        private System.Windows.Forms.Label lbpartindex;
        private System.Windows.Forms.Label lbdiskindex;
        private System.Windows.Forms.Label lbmodel;
        private System.Windows.Forms.Label lbdrivename;
    }
}
