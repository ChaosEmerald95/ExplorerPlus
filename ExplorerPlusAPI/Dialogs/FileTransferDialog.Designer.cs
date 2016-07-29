namespace ExplorerPlus.API.Dialogs
{
    partial class FileTransferDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbtransferinfo = new System.Windows.Forms.Label();
            this.lbtransferplace = new System.Windows.Forms.Label();
            this.progresstransfer = new System.Windows.Forms.ProgressBar();
            this.lbname = new System.Windows.Forms.Label();
            this.lbspeed = new System.Windows.Forms.Label();
            this.lbresttime = new System.Windows.Forms.Label();
            this.lbrestbyte = new System.Windows.Forms.Label();
            this.progresstimer = new System.Windows.Forms.Timer(this.components);
            this.btnabort = new System.Windows.Forms.Button();
            this.btnpause = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbtransferinfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 52);
            this.panel1.TabIndex = 0;
            // 
            // lbtransferinfo
            // 
            this.lbtransferinfo.AutoSize = true;
            this.lbtransferinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtransferinfo.Location = new System.Drawing.Point(12, 13);
            this.lbtransferinfo.Name = "lbtransferinfo";
            this.lbtransferinfo.Size = new System.Drawing.Size(116, 24);
            this.lbtransferinfo.TabIndex = 0;
            this.lbtransferinfo.Text = "lbtransferinfo";
            // 
            // lbtransferplace
            // 
            this.lbtransferplace.AutoSize = true;
            this.lbtransferplace.Location = new System.Drawing.Point(13, 65);
            this.lbtransferplace.Name = "lbtransferplace";
            this.lbtransferplace.Size = new System.Drawing.Size(76, 13);
            this.lbtransferplace.TabIndex = 1;
            this.lbtransferplace.Text = "lbtransferplace";
            // 
            // progresstransfer
            // 
            this.progresstransfer.Location = new System.Drawing.Point(12, 102);
            this.progresstransfer.Name = "progresstransfer";
            this.progresstransfer.Size = new System.Drawing.Size(453, 40);
            this.progresstransfer.Step = 1;
            this.progresstransfer.TabIndex = 2;
            // 
            // lbname
            // 
            this.lbname.AutoSize = true;
            this.lbname.Location = new System.Drawing.Point(12, 157);
            this.lbname.Name = "lbname";
            this.lbname.Size = new System.Drawing.Size(41, 13);
            this.lbname.TabIndex = 3;
            this.lbname.Text = "lbname";
            // 
            // lbspeed
            // 
            this.lbspeed.AutoSize = true;
            this.lbspeed.Location = new System.Drawing.Point(12, 179);
            this.lbspeed.Name = "lbspeed";
            this.lbspeed.Size = new System.Drawing.Size(44, 13);
            this.lbspeed.TabIndex = 3;
            this.lbspeed.Text = "lbspeed";
            // 
            // lbresttime
            // 
            this.lbresttime.AutoSize = true;
            this.lbresttime.Location = new System.Drawing.Point(12, 202);
            this.lbresttime.Name = "lbresttime";
            this.lbresttime.Size = new System.Drawing.Size(51, 13);
            this.lbresttime.TabIndex = 3;
            this.lbresttime.Text = "lbresttime";
            // 
            // lbrestbyte
            // 
            this.lbrestbyte.AutoSize = true;
            this.lbrestbyte.Location = new System.Drawing.Point(12, 225);
            this.lbrestbyte.Name = "lbrestbyte";
            this.lbrestbyte.Size = new System.Drawing.Size(52, 13);
            this.lbrestbyte.TabIndex = 3;
            this.lbrestbyte.Text = "lbrestbyte";
            // 
            // progresstimer
            // 
            this.progresstimer.Interval = 1000;
            this.progresstimer.Tick += new System.EventHandler(this.progresstimer_Tick);
            // 
            // btnabort
            // 
            this.btnabort.FlatAppearance.BorderSize = 0;
            this.btnabort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnabort.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnabort.Location = new System.Drawing.Point(440, 152);
            this.btnabort.Name = "btnabort";
            this.btnabort.Size = new System.Drawing.Size(25, 23);
            this.btnabort.TabIndex = 4;
            this.btnabort.Text = "x";
            this.btnabort.UseVisualStyleBackColor = true;
            this.btnabort.Click += new System.EventHandler(this.btnabort_Click);
            // 
            // btnpause
            // 
            this.btnpause.FlatAppearance.BorderSize = 0;
            this.btnpause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpause.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpause.Location = new System.Drawing.Point(409, 152);
            this.btnpause.Name = "btnpause";
            this.btnpause.Size = new System.Drawing.Size(25, 23);
            this.btnpause.TabIndex = 4;
            this.btnpause.Text = "I I";
            this.btnpause.UseVisualStyleBackColor = true;
            this.btnpause.Click += new System.EventHandler(this.btnpause_Click);
            // 
            // FileTransferDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(477, 251);
            this.Controls.Add(this.btnpause);
            this.Controls.Add(this.btnabort);
            this.Controls.Add(this.lbrestbyte);
            this.Controls.Add(this.lbresttime);
            this.Controls.Add(this.lbspeed);
            this.Controls.Add(this.lbname);
            this.Controls.Add(this.progresstransfer);
            this.Controls.Add(this.lbtransferplace);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileTransferDialog";
            this.ShowIcon = false;
            this.Text = "FileTransferDialog";
            this.Load += new System.EventHandler(this.FileTransferDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbtransferinfo;
        private System.Windows.Forms.Label lbtransferplace;
        private System.Windows.Forms.ProgressBar progresstransfer;
        private System.Windows.Forms.Label lbname;
        private System.Windows.Forms.Label lbspeed;
        private System.Windows.Forms.Label lbresttime;
        private System.Windows.Forms.Label lbrestbyte;
        private System.Windows.Forms.Timer progresstimer;
        private System.Windows.Forms.Button btnabort;
        private System.Windows.Forms.Button btnpause;
    }
}