﻿namespace SaveGameMover
{
    partial class SGM2
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoadSave = new System.Windows.Forms.Button();
            this.btnCreateSave = new System.Windows.Forms.Button();
            this.cbSave = new System.Windows.Forms.ComboBox();
            this.tvFiles = new System.Windows.Forms.TreeView();
            this.btnCopy = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCurrentDirection = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.pbCurrentFileIndex = new SaveGameMover.CustomControls.CustomProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.7619F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.23809F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tvFiles, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCopy, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(525, 453);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnLoadSave);
            this.panel1.Controls.Add(this.btnCreateSave);
            this.panel1.Controls.Add(this.cbSave);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.MinimumSize = new System.Drawing.Size(525, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 35);
            this.panel1.TabIndex = 0;
            // 
            // btnLoadSave
            // 
            this.btnLoadSave.Enabled = false;
            this.btnLoadSave.Location = new System.Drawing.Point(307, 3);
            this.btnLoadSave.Name = "btnLoadSave";
            this.btnLoadSave.Size = new System.Drawing.Size(86, 23);
            this.btnLoadSave.TabIndex = 2;
            this.btnLoadSave.Text = "Load Save";
            this.btnLoadSave.UseVisualStyleBackColor = true;
            this.btnLoadSave.Click += new System.EventHandler(this.BtnLoadSave_Click);
            // 
            // btnCreateSave
            // 
            this.btnCreateSave.Location = new System.Drawing.Point(399, 3);
            this.btnCreateSave.Name = "btnCreateSave";
            this.btnCreateSave.Size = new System.Drawing.Size(116, 23);
            this.btnCreateSave.TabIndex = 1;
            this.btnCreateSave.Text = "Create Save";
            this.btnCreateSave.UseVisualStyleBackColor = true;
            this.btnCreateSave.Click += new System.EventHandler(this.BtnCreateSave_Click);
            // 
            // cbSave
            // 
            this.cbSave.FormattingEnabled = true;
            this.cbSave.Location = new System.Drawing.Point(3, 5);
            this.cbSave.Name = "cbSave";
            this.cbSave.Size = new System.Drawing.Size(298, 21);
            this.cbSave.TabIndex = 0;
            this.cbSave.SelectedIndexChanged += new System.EventHandler(this.CbSave_SelectedIndexChanged);
            // 
            // tvFiles
            // 
            this.tvFiles.CheckBoxes = true;
            this.tableLayoutPanel1.SetColumnSpan(this.tvFiles, 2);
            this.tvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFiles.Location = new System.Drawing.Point(3, 73);
            this.tvFiles.Name = "tvFiles";
            this.tvFiles.Size = new System.Drawing.Size(519, 342);
            this.tvFiles.TabIndex = 1;
            this.tvFiles.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TvFiles_AfterCheck);
            // 
            // btnCopy
            // 
            this.btnCopy.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(415, 421);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(107, 29);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "Copy Save";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.lblCurrentDirection);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 35);
            this.panel2.TabIndex = 4;
            // 
            // lblCurrentDirection
            // 
            this.lblCurrentDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentDirection.Location = new System.Drawing.Point(0, 0);
            this.lblCurrentDirection.Name = "lblCurrentDirection";
            this.lblCurrentDirection.Size = new System.Drawing.Size(525, 35);
            this.lblCurrentDirection.TabIndex = 0;
            this.lblCurrentDirection.Tag = "Source:";
            this.lblCurrentDirection.Text = "Source: ---";
            this.lblCurrentDirection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pbCurrentFileIndex);
            this.panel3.Controls.Add(this.btnSwitch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 418);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(403, 35);
            this.panel3.TabIndex = 5;
            // 
            // btnSwitch
            // 
            this.btnSwitch.Enabled = false;
            this.btnSwitch.Location = new System.Drawing.Point(3, 3);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(130, 29);
            this.btnSwitch.TabIndex = 4;
            this.btnSwitch.Text = "Switch Save Direction";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.BtnSwitch_Click);
            // 
            // pbCurrentFileIndex
            // 
            this.pbCurrentFileIndex.CustomText = null;
            this.pbCurrentFileIndex.DisplayStyle = SaveGameMover.CustomControls.ProgressBarDisplayText.Percentage;
            this.pbCurrentFileIndex.Location = new System.Drawing.Point(139, 0);
            this.pbCurrentFileIndex.Name = "pbCurrentFileIndex";
            this.pbCurrentFileIndex.Size = new System.Drawing.Size(264, 32);
            this.pbCurrentFileIndex.TabIndex = 5;
            // 
            // SGM2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 453);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(541, 490);
            this.Name = "SGM2";
            this.Text = "SGM2";
            this.Load += new System.EventHandler(this.SGM2_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbSave;
        private System.Windows.Forms.Button btnLoadSave;
        private System.Windows.Forms.Button btnCreateSave;
        private System.Windows.Forms.TreeView tvFiles;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCurrentDirection;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btnSwitch;
		private CustomControls.CustomProgressBar pbCurrentFileIndex;
	}
}