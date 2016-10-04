namespace JXTJobsXMLGenerator
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbJobRefPrefix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAdvertiser = new System.Windows.Forms.TextBox();
            this.cbExportAsSOAP = new System.Windows.Forms.CheckBox();
            this.lbUsername = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cbArchiveMissingJobs = new System.Windows.Forms.CheckBox();
            this.lbMessage = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.04255F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.95744F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbJobRefPrefix, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbNumber, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbAdvertiser, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbExportAsSOAP, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbUsername, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbPassword, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbPassword, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbUsername, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnGenerate, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbArchiveMissingJobs, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbMessage, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 189F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(570, 292);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Job Ref Prefix";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbJobRefPrefix
            // 
            this.tbJobRefPrefix.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbJobRefPrefix.Location = new System.Drawing.Point(85, 3);
            this.tbJobRefPrefix.Name = "tbJobRefPrefix";
            this.tbJobRefPrefix.Size = new System.Drawing.Size(153, 20);
            this.tbJobRefPrefix.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "No. of Jobs";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbNumber
            // 
            this.tbNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNumber.Location = new System.Drawing.Point(85, 29);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(153, 20);
            this.tbNumber.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(244, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Advertiser ID";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbAdvertiser
            // 
            this.tbAdvertiser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAdvertiser.Location = new System.Drawing.Point(344, 3);
            this.tbAdvertiser.Name = "tbAdvertiser";
            this.tbAdvertiser.Size = new System.Drawing.Size(133, 20);
            this.tbAdvertiser.TabIndex = 2;
            // 
            // cbExportAsSOAP
            // 
            this.cbExportAsSOAP.AutoSize = true;
            this.cbExportAsSOAP.Location = new System.Drawing.Point(344, 29);
            this.cbExportAsSOAP.Name = "cbExportAsSOAP";
            this.cbExportAsSOAP.Size = new System.Drawing.Size(102, 17);
            this.cbExportAsSOAP.TabIndex = 4;
            this.cbExportAsSOAP.Text = "Export as SOAP";
            this.cbExportAsSOAP.UseVisualStyleBackColor = true;
            this.cbExportAsSOAP.CheckedChanged += new System.EventHandler(this.cbExportAsSOAP_CheckedChanged);
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUsername.Location = new System.Drawing.Point(3, 52);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(76, 28);
            this.lbUsername.TabIndex = 9;
            this.lbUsername.Text = "Username";
            this.lbUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPassword.Location = new System.Drawing.Point(244, 52);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(94, 28);
            this.lbPassword.TabIndex = 10;
            this.lbPassword.Text = "Password";
            this.lbPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPassword
            // 
            this.tbPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPassword.Location = new System.Drawing.Point(344, 55);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(133, 20);
            this.tbPassword.TabIndex = 6;
            // 
            // tbUsername
            // 
            this.tbUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbUsername.Location = new System.Drawing.Point(85, 55);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(153, 20);
            this.tbUsername.TabIndex = 5;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(483, 106);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(84, 22);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cbArchiveMissingJobs
            // 
            this.cbArchiveMissingJobs.AutoSize = true;
            this.cbArchiveMissingJobs.Location = new System.Drawing.Point(85, 83);
            this.cbArchiveMissingJobs.Name = "cbArchiveMissingJobs";
            this.cbArchiveMissingJobs.Size = new System.Drawing.Size(120, 17);
            this.cbArchiveMissingJobs.TabIndex = 7;
            this.cbArchiveMissingJobs.Text = "Archive Missing Job";
            this.cbArchiveMissingJobs.UseVisualStyleBackColor = true;
            // 
            // lbMessage
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lbMessage, 2);
            this.lbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMessage.Location = new System.Drawing.Point(85, 106);
            this.lbMessage.Multiline = true;
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.ReadOnly = true;
            this.lbMessage.Size = new System.Drawing.Size(253, 183);
            this.lbMessage.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 292);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "JXT Jobs XML Generator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbJobRefPrefix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAdvertiser;
        private System.Windows.Forms.CheckBox cbExportAsSOAP;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.CheckBox cbArchiveMissingJobs;
        private System.Windows.Forms.TextBox lbMessage;
    }
}

