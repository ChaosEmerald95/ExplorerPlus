namespace ExplorerPlus.API.Controls
{
    partial class ExplorerPlusMenuBarExtend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerPlusMenuBarExtend));
            this.cbfolderbar = new System.Windows.Forms.ComboBox();
            this.btnreload = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnnewfolder = new System.Windows.Forms.Button();
            this.txtsearchtext = new System.Windows.Forms.TextBox();
            this.btnsearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbfolderbar
            // 
            this.cbfolderbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbfolderbar.FormattingEnabled = true;
            this.cbfolderbar.Location = new System.Drawing.Point(107, 5);
            this.cbfolderbar.Name = "cbfolderbar";
            this.cbfolderbar.Size = new System.Drawing.Size(342, 21);
            this.cbfolderbar.TabIndex = 6;
            this.cbfolderbar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbfolderbar_KeyDown);
            // 
            // btnreload
            // 
            this.btnreload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnreload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnreload.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnreload.FlatAppearance.BorderSize = 0;
            this.btnreload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnreload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnreload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnreload.Font = new System.Drawing.Font("MS Outlook", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnreload.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnreload.Location = new System.Drawing.Point(446, 5);
            this.btnreload.Name = "btnreload";
            this.btnreload.Size = new System.Drawing.Size(25, 21);
            this.btnreload.TabIndex = 2;
            this.btnreload.Text = "C";
            this.btnreload.UseVisualStyleBackColor = false;
            this.btnreload.Click += new System.EventHandler(this.btnreload_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.Location = new System.Drawing.Point(76, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "á";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnoverfolder_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button2.Location = new System.Drawing.Point(34, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "à\r\n";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnforward_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "ß";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btndelete
            // 
            this.btndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btndelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btndelete.FlatAppearance.BorderSize = 0;
            this.btndelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btndelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.Font = new System.Drawing.Font("MS Outlook", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btndelete.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btndelete.Image = ((System.Drawing.Image)(resources.GetObject("btndelete.Image")));
            this.btndelete.Location = new System.Drawing.Point(477, 5);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(25, 21);
            this.btndelete.TabIndex = 2;
            this.btndelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnnewfolder
            // 
            this.btnnewfolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnnewfolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnnewfolder.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnnewfolder.FlatAppearance.BorderSize = 0;
            this.btnnewfolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnnewfolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnnewfolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnewfolder.Font = new System.Drawing.Font("MS Outlook", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnnewfolder.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnnewfolder.Image = ((System.Drawing.Image)(resources.GetObject("btnnewfolder.Image")));
            this.btnnewfolder.Location = new System.Drawing.Point(508, 5);
            this.btnnewfolder.Name = "btnnewfolder";
            this.btnnewfolder.Size = new System.Drawing.Size(25, 21);
            this.btnnewfolder.TabIndex = 2;
            this.btnnewfolder.UseVisualStyleBackColor = false;
            this.btnnewfolder.Click += new System.EventHandler(this.btnnewfolder_Click);
            // 
            // txtsearchtext
            // 
            this.txtsearchtext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsearchtext.Location = new System.Drawing.Point(538, 5);
            this.txtsearchtext.Name = "txtsearchtext";
            this.txtsearchtext.Size = new System.Drawing.Size(186, 20);
            this.txtsearchtext.TabIndex = 10;
            this.txtsearchtext.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsearchtext_KeyDown);
            // 
            // btnsearch
            // 
            this.btnsearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnsearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnsearch.FlatAppearance.BorderSize = 0;
            this.btnsearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnsearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnsearch.Font = new System.Drawing.Font("MS Outlook", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnsearch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnsearch.Image = ((System.Drawing.Image)(resources.GetObject("btnsearch.Image")));
            this.btnsearch.Location = new System.Drawing.Point(723, 5);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(25, 20);
            this.btnsearch.TabIndex = 2;
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // ExplorerPlusMenuBarExtend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtsearchtext);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cbfolderbar);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.btnnewfolder);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnreload);
            this.Name = "ExplorerPlusMenuBarExtend";
            this.Size = new System.Drawing.Size(757, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbfolderbar;
        private System.Windows.Forms.Button btnreload;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnnewfolder;
        private System.Windows.Forms.TextBox txtsearchtext;
        private System.Windows.Forms.Button btnsearch;
    }
}
