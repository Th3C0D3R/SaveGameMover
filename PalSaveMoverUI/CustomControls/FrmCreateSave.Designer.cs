namespace SaveGameMover.CustomControls
{
    partial class FrmCreateSave
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
            this.btnDestOFD = new System.Windows.Forms.Button();
            this.btnSourceOFD = new System.Windows.Forms.Button();
            this.txbDestination = new System.Windows.Forms.TextBox();
            this.txbSource = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbGamename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDestOFD
            // 
            this.btnDestOFD.Location = new System.Drawing.Point(538, 81);
            this.btnDestOFD.Name = "btnDestOFD";
            this.btnDestOFD.Size = new System.Drawing.Size(34, 25);
            this.btnDestOFD.TabIndex = 5;
            this.btnDestOFD.Text = "...";
            this.btnDestOFD.UseVisualStyleBackColor = true;
            this.btnDestOFD.Click += new System.EventHandler(this.BtnDestOFD_Click);
            // 
            // btnSourceOFD
            // 
            this.btnSourceOFD.Location = new System.Drawing.Point(538, 51);
            this.btnSourceOFD.Name = "btnSourceOFD";
            this.btnSourceOFD.Size = new System.Drawing.Size(34, 25);
            this.btnSourceOFD.TabIndex = 3;
            this.btnSourceOFD.Text = "...";
            this.btnSourceOFD.UseVisualStyleBackColor = true;
            this.btnSourceOFD.Click += new System.EventHandler(this.BtnSourceOFD_Click);
            // 
            // txbDestination
            // 
            this.txbDestination.BackColor = System.Drawing.Color.White;
            this.txbDestination.Location = new System.Drawing.Point(94, 84);
            this.txbDestination.Name = "txbDestination";
            this.txbDestination.Size = new System.Drawing.Size(438, 20);
            this.txbDestination.TabIndex = 4;
            // 
            // txbSource
            // 
            this.txbSource.BackColor = System.Drawing.Color.White;
            this.txbSource.Location = new System.Drawing.Point(94, 54);
            this.txbSource.Name = "txbSource";
            this.txbSource.Size = new System.Drawing.Size(438, 20);
            this.txbSource.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 30);
            this.label2.TabIndex = 14;
            this.label2.Text = "Destination:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 30);
            this.label1.TabIndex = 13;
            this.label1.Text = "Source:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbGamename
            // 
            this.txbGamename.BackColor = System.Drawing.Color.White;
            this.txbGamename.Location = new System.Drawing.Point(94, 12);
            this.txbGamename.Name = "txbGamename";
            this.txbGamename.Size = new System.Drawing.Size(438, 20);
            this.txbGamename.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 30);
            this.label3.TabIndex = 12;
            this.label3.Text = "Gamename:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(490, 119);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(9, 119);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // FrmCreateSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 154);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txbGamename);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDestOFD);
            this.Controls.Add(this.btnSourceOFD);
            this.Controls.Add(this.txbDestination);
            this.Controls.Add(this.txbSource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(593, 193);
            this.MinimumSize = new System.Drawing.Size(593, 193);
            this.Name = "FrmCreateSave";
            this.Text = "Create Savegame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDestOFD;
        private System.Windows.Forms.Button btnSourceOFD;
        private System.Windows.Forms.TextBox txbDestination;
        private System.Windows.Forms.TextBox txbSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbGamename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}