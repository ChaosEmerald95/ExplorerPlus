namespace ExplorerPlus.API.Controls
{
    partial class ExplorerPlusMenuBar
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
            this.btnback = new System.Windows.Forms.Button();
            this.btnforward = new System.Windows.Forms.Button();
            this.btnoverfolder = new System.Windows.Forms.Button();
            this.cbfolderbar = new System.Windows.Forms.ComboBox();
            this.btnreload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnback
            // 
            this.btnback.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnback.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnback.FlatAppearance.BorderSize = 0;
            this.btnback.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnback.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnback.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnback.Location = new System.Drawing.Point(3, 1);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(25, 23);
            this.btnback.TabIndex = 0;
            this.btnback.Text = "ß";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btnforward
            // 
            this.btnforward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnforward.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnforward.FlatAppearance.BorderSize = 0;
            this.btnforward.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnforward.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnforward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnforward.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnforward.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnforward.Location = new System.Drawing.Point(34, 1);
            this.btnforward.Name = "btnforward";
            this.btnforward.Size = new System.Drawing.Size(25, 23);
            this.btnforward.TabIndex = 0;
            this.btnforward.Text = "à\r\n";
            this.btnforward.UseVisualStyleBackColor = false;
            this.btnforward.Click += new System.EventHandler(this.btnforward_Click);
            // 
            // btnoverfolder
            // 
            this.btnoverfolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnoverfolder.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnoverfolder.FlatAppearance.BorderSize = 0;
            this.btnoverfolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnoverfolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnoverfolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnoverfolder.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnoverfolder.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnoverfolder.Location = new System.Drawing.Point(76, 1);
            this.btnoverfolder.Name = "btnoverfolder";
            this.btnoverfolder.Size = new System.Drawing.Size(25, 23);
            this.btnoverfolder.TabIndex = 0;
            this.btnoverfolder.Text = "á";
            this.btnoverfolder.UseVisualStyleBackColor = false;
            this.btnoverfolder.Click += new System.EventHandler(this.btnoverfolder_Click);
            // 
            // cbfolderbar
            // 
            this.cbfolderbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbfolderbar.FormattingEnabled = true;
            this.cbfolderbar.Location = new System.Drawing.Point(107, 3);
            this.cbfolderbar.Name = "cbfolderbar";
            this.cbfolderbar.Size = new System.Drawing.Size(804, 21);
            this.cbfolderbar.TabIndex = 1;
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
            this.btnreload.Location = new System.Drawing.Point(908, 3);
            this.btnreload.Name = "btnreload";
            this.btnreload.Size = new System.Drawing.Size(25, 21);
            this.btnreload.TabIndex = 0;
            this.btnreload.Text = "C";
            this.btnreload.UseVisualStyleBackColor = false;
            this.btnreload.Click += new System.EventHandler(this.btnreload_Click);
            // 
            // ExplorerPlusMenuBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cbfolderbar);
            this.Controls.Add(this.btnreload);
            this.Controls.Add(this.btnoverfolder);
            this.Controls.Add(this.btnforward);
            this.Controls.Add(this.btnback);
            this.Name = "ExplorerPlusMenuBar";
            this.Size = new System.Drawing.Size(936, 27);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnforward;
        private System.Windows.Forms.Button btnoverfolder;
        private System.Windows.Forms.ComboBox cbfolderbar;
        private System.Windows.Forms.Button btnreload;
    }
}
