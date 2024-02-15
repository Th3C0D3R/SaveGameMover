namespace SaveGameMoverUI
{
    partial class FrmSaver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSaver));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbSource = new System.Windows.Forms.TextBox();
            this.txbDestination = new System.Windows.Forms.TextBox();
            this.btnSourceOFD = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDestOFD = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbProfile = new System.Windows.Forms.ComboBox();
            this.btnCreateProfil = new System.Windows.Forms.Button();
            this.cbSwitchMode = new System.Windows.Forms.Button();
            this.lblCurrentMode = new System.Windows.Forms.Label();
            this.lbOutput = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbCreateBackup = new System.Windows.Forms.CheckBox();
            this.cbGenerateLog = new System.Windows.Forms.CheckBox();
            this.cbDeleteDest = new System.Windows.Forms.CheckBox();
            this.cbDryRun = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 119);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(498, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destination:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbSource
            // 
            this.txbSource.BackColor = System.Drawing.SystemColors.Control;
            this.txbSource.Location = new System.Drawing.Point(15, 327);
            this.txbSource.Name = "txbSource";
            this.txbSource.Size = new System.Drawing.Size(435, 20);
            this.txbSource.TabIndex = 2;
            // 
            // txbDestination
            // 
            this.txbDestination.BackColor = System.Drawing.SystemColors.Control;
            this.txbDestination.Location = new System.Drawing.Point(12, 385);
            this.txbDestination.Name = "txbDestination";
            this.txbDestination.Size = new System.Drawing.Size(438, 20);
            this.txbDestination.TabIndex = 3;
            // 
            // btnSourceOFD
            // 
            this.btnSourceOFD.Location = new System.Drawing.Point(456, 327);
            this.btnSourceOFD.Name = "btnSourceOFD";
            this.btnSourceOFD.Size = new System.Drawing.Size(34, 25);
            this.btnSourceOFD.TabIndex = 4;
            this.btnSourceOFD.Text = "...";
            this.btnSourceOFD.UseVisualStyleBackColor = true;
            this.btnSourceOFD.Click += new System.EventHandler(this.BtnSourceOFD_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(497, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 20);
            this.button1.TabIndex = 4;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnDestOFD
            // 
            this.btnDestOFD.Location = new System.Drawing.Point(456, 385);
            this.btnDestOFD.Name = "btnDestOFD";
            this.btnDestOFD.Size = new System.Drawing.Size(34, 25);
            this.btnDestOFD.TabIndex = 5;
            this.btnDestOFD.Text = "...";
            this.btnDestOFD.UseVisualStyleBackColor = true;
            this.btnDestOFD.Click += new System.EventHandler(this.BtnDestOFD_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.52301F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.58159F));
            this.tableLayoutPanel1.Controls.Add(this.cbProfile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCreateProfil, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbSwitchMode, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCurrentMode, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 191);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(478, 100);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // cbProfile
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbProfile, 2);
            this.cbProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfile.FormattingEnabled = true;
            this.cbProfile.Location = new System.Drawing.Point(3, 3);
            this.cbProfile.Name = "cbProfile";
            this.cbProfile.Size = new System.Drawing.Size(234, 21);
            this.cbProfile.TabIndex = 2;
            this.cbProfile.SelectionChangeCommitted += new System.EventHandler(this.CbProfile_SelectionChangeCommitted);
            // 
            // btnCreateProfil
            // 
            this.btnCreateProfil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreateProfil.Location = new System.Drawing.Point(243, 3);
            this.btnCreateProfil.Name = "btnCreateProfil";
            this.btnCreateProfil.Size = new System.Drawing.Size(232, 24);
            this.btnCreateProfil.TabIndex = 3;
            this.btnCreateProfil.Text = "Create Profile";
            this.btnCreateProfil.UseVisualStyleBackColor = true;
            this.btnCreateProfil.Click += new System.EventHandler(this.BtnCreateProfil_Click);
            // 
            // cbSwitchMode
            // 
            this.cbSwitchMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSwitchMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.cbSwitchMode.Location = new System.Drawing.Point(243, 41);
            this.cbSwitchMode.Name = "cbSwitchMode";
            this.cbSwitchMode.Size = new System.Drawing.Size(232, 56);
            this.cbSwitchMode.TabIndex = 4;
            this.cbSwitchMode.Tag = "Switch to \"#Mode#\"";
            this.cbSwitchMode.Text = "Switch to \"-\"";
            this.cbSwitchMode.UseVisualStyleBackColor = true;
            this.cbSwitchMode.Click += new System.EventHandler(this.SwitchMode);
            // 
            // lblCurrentMode
            // 
            this.lblCurrentMode.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.SetColumnSpan(this.lblCurrentMode, 2);
            this.lblCurrentMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentMode.Location = new System.Drawing.Point(3, 38);
            this.lblCurrentMode.Name = "lblCurrentMode";
            this.lblCurrentMode.Size = new System.Drawing.Size(234, 62);
            this.lblCurrentMode.TabIndex = 1;
            this.lblCurrentMode.Tag = "Current Mode: #Mode#";
            this.lblCurrentMode.Text = "Current Mode: -";
            this.lblCurrentMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbOutput
            // 
            this.lbOutput.BackColor = System.Drawing.SystemColors.Control;
            this.lbOutput.FormattingEnabled = true;
            this.lbOutput.HorizontalScrollbar = true;
            this.lbOutput.Location = new System.Drawing.Point(12, 470);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.Size = new System.Drawing.Size(471, 186);
            this.lbOutput.TabIndex = 7;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(15, 441);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(403, 441);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // cbCreateBackup
            // 
            this.cbCreateBackup.AutoSize = true;
            this.cbCreateBackup.Location = new System.Drawing.Point(96, 422);
            this.cbCreateBackup.Name = "cbCreateBackup";
            this.cbCreateBackup.Size = new System.Drawing.Size(97, 17);
            this.cbCreateBackup.TabIndex = 10;
            this.cbCreateBackup.Text = "Create Backup";
            this.cbCreateBackup.UseVisualStyleBackColor = true;
            this.cbCreateBackup.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            this.cbCreateBackup.Paint += new System.Windows.Forms.PaintEventHandler(this.Checkbox_Paint);
            // 
            // cbGenerateLog
            // 
            this.cbGenerateLog.AutoSize = true;
            this.cbGenerateLog.Location = new System.Drawing.Point(96, 445);
            this.cbGenerateLog.Name = "cbGenerateLog";
            this.cbGenerateLog.Size = new System.Drawing.Size(91, 17);
            this.cbGenerateLog.TabIndex = 11;
            this.cbGenerateLog.Text = "Generate Log";
            this.cbGenerateLog.UseVisualStyleBackColor = true;
            this.cbGenerateLog.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            this.cbGenerateLog.Paint += new System.Windows.Forms.PaintEventHandler(this.Checkbox_Paint);
            // 
            // cbDeleteDest
            // 
            this.cbDeleteDest.AutoSize = true;
            this.cbDeleteDest.Location = new System.Drawing.Point(204, 445);
            this.cbDeleteDest.Name = "cbDeleteDest";
            this.cbDeleteDest.Size = new System.Drawing.Size(154, 17);
            this.cbDeleteDest.TabIndex = 12;
            this.cbDeleteDest.Text = "Delete instead of Overwrite";
            this.cbDeleteDest.UseVisualStyleBackColor = true;
            this.cbDeleteDest.CheckedChanged += new System.EventHandler(this.CbDeleteDest_CheckedChanged);
            this.cbDeleteDest.Paint += new System.Windows.Forms.PaintEventHandler(this.Checkbox_Paint);
            // 
            // cbDryRun
            // 
            this.cbDryRun.AutoSize = true;
            this.cbDryRun.Location = new System.Drawing.Point(204, 422);
            this.cbDryRun.Name = "cbDryRun";
            this.cbDryRun.Size = new System.Drawing.Size(65, 17);
            this.cbDryRun.TabIndex = 13;
            this.cbDryRun.Text = "Dry Run";
            this.cbDryRun.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(93, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 32);
            this.label3.TabIndex = 14;
            this.label3.Text = "Savegame Mover";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(93, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 24);
            this.label4.TabIndex = 15;
            this.label4.Text = "by TH3C0D3R\r\n";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmSaver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::SaveGameMover.Properties.Resources.PalHoch1000x1500;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(502, 668);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbDryRun);
            this.Controls.Add(this.cbDeleteDest);
            this.Controls.Add(this.cbGenerateLog);
            this.Controls.Add(this.cbCreateBackup);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lbOutput);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnDestOFD);
            this.Controls.Add(this.btnSourceOFD);
            this.Controls.Add(this.txbDestination);
            this.Controls.Add(this.txbSource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSaver";
            this.Text = "Savegame Mover";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSaver_FormClosing);
            this.Load += new System.EventHandler(this.FrmSaver_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbSource;
        private System.Windows.Forms.TextBox txbDestination;
        private System.Windows.Forms.Button btnSourceOFD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDestOFD;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label lblCurrentMode;
        private System.Windows.Forms.ComboBox cbProfile;
        private System.Windows.Forms.Button btnCreateProfil;
		private System.Windows.Forms.ListBox lbOutput;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.CheckBox cbCreateBackup;
		private System.Windows.Forms.CheckBox cbGenerateLog;
		private System.Windows.Forms.CheckBox cbDeleteDest;
        private System.Windows.Forms.Button cbSwitchMode;
        private System.Windows.Forms.CheckBox cbDryRun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

