namespace JXTMemberTransfer
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
            this.lbSubject = new System.Windows.Forms.Label();
            this.tbComplete = new System.Windows.Forms.TextBox();
            this.lbFrom = new System.Windows.Forms.Label();
            this.lbTo = new System.Windows.Forms.Label();
            this.cbTo = new System.Windows.Forms.ComboBox();
            this.lbToID = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lbComplete = new System.Windows.Forms.Label();
            this.pbTransfer = new System.Windows.Forms.ProgressBar();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lbFilePath = new System.Windows.Forms.Label();
            this.tbError = new System.Windows.Forms.TextBox();
            this.lbError = new System.Windows.Forms.Label();
            this.lbPreview = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbFromEmail = new System.Windows.Forms.Label();
            this.lbFromID = new System.Windows.Forms.Label();
            this.tbFromEmail = new System.Windows.Forms.TextBox();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.188841F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.44206F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.261803F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.669111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.66644F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66445F));
            this.tableLayoutPanel1.Controls.Add(this.lbSubject, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbComplete, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbFrom, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbTo, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbTo, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbToID, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStart, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbComplete, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.pbTransfer, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnBrowse, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbFilePath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbError, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbError, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbPreview, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.listView1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbStatus, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbFromEmail, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbFromID, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbFromEmail, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbSubject, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(932, 615);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lbSubject
            // 
            this.lbSubject.AutoSize = true;
            this.lbSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSubject.Location = new System.Drawing.Point(391, 30);
            this.lbSubject.Name = "lbSubject";
            this.lbSubject.Size = new System.Drawing.Size(71, 27);
            this.lbSubject.TabIndex = 18;
            this.lbSubject.Text = "Subject:";
            this.lbSubject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbComplete
            // 
            this.tbComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.tbComplete, 2);
            this.tbComplete.ForeColor = System.Drawing.Color.LimeGreen;
            this.tbComplete.Location = new System.Drawing.Point(70, 344);
            this.tbComplete.Multiline = true;
            this.tbComplete.Name = "tbComplete";
            this.tbComplete.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbComplete.Size = new System.Drawing.Size(392, 238);
            this.tbComplete.TabIndex = 13;
            // 
            // lbFrom
            // 
            this.lbFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFrom.AutoSize = true;
            this.lbFrom.Location = new System.Drawing.Point(38, 0);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(26, 30);
            this.lbFrom.TabIndex = 0;
            this.lbFrom.Text = "File:";
            this.lbFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTo
            // 
            this.lbTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTo.AutoSize = true;
            this.lbTo.Location = new System.Drawing.Point(501, 0);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(23, 30);
            this.lbTo.TabIndex = 1;
            this.lbTo.Text = "To:";
            this.lbTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbTo
            // 
            this.cbTo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTo.FormattingEnabled = true;
            this.cbTo.Location = new System.Drawing.Point(530, 3);
            this.cbTo.Name = "cbTo";
            this.cbTo.Size = new System.Drawing.Size(242, 21);
            this.cbTo.TabIndex = 3;
            // 
            // lbToID
            // 
            this.lbToID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbToID.AutoSize = true;
            this.lbToID.Location = new System.Drawing.Point(778, 0);
            this.lbToID.Name = "lbToID";
            this.lbToID.Size = new System.Drawing.Size(0, 30);
            this.lbToID.TabIndex = 5;
            this.lbToID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(778, 33);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(119, 21);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start Import";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbComplete
            // 
            this.lbComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbComplete.AutoSize = true;
            this.lbComplete.Location = new System.Drawing.Point(10, 341);
            this.lbComplete.Name = "lbComplete";
            this.lbComplete.Size = new System.Drawing.Size(54, 13);
            this.lbComplete.TabIndex = 10;
            this.lbComplete.Text = "Complete:";
            // 
            // pbTransfer
            // 
            this.pbTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.pbTransfer, 2);
            this.pbTransfer.Location = new System.Drawing.Point(70, 588);
            this.pbTransfer.Name = "pbTransfer";
            this.pbTransfer.Size = new System.Drawing.Size(392, 24);
            this.pbTransfer.TabIndex = 14;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBrowse.Location = new System.Drawing.Point(391, 3);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(71, 24);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lbFilePath
            // 
            this.lbFilePath.AutoSize = true;
            this.lbFilePath.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbFilePath.Location = new System.Drawing.Point(70, 0);
            this.lbFilePath.Name = "lbFilePath";
            this.lbFilePath.Size = new System.Drawing.Size(0, 30);
            this.lbFilePath.TabIndex = 2;
            this.lbFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbError
            // 
            this.tbError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.tbError, 2);
            this.tbError.ForeColor = System.Drawing.Color.Red;
            this.tbError.Location = new System.Drawing.Point(530, 344);
            this.tbError.Multiline = true;
            this.tbError.Name = "tbError";
            this.tbError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbError.Size = new System.Drawing.Size(399, 238);
            this.tbError.TabIndex = 11;
            // 
            // lbError
            // 
            this.lbError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbError.AutoSize = true;
            this.lbError.Location = new System.Drawing.Point(492, 341);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(32, 13);
            this.lbError.TabIndex = 8;
            this.lbError.Text = "Error:";
            // 
            // lbPreview
            // 
            this.lbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPreview.AutoSize = true;
            this.lbPreview.Location = new System.Drawing.Point(16, 97);
            this.lbPreview.Name = "lbPreview";
            this.lbPreview.Size = new System.Drawing.Size(48, 13);
            this.lbPreview.TabIndex = 9;
            this.lbPreview.Text = "Preview:";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.tableLayoutPanel1.SetColumnSpan(this.listView1, 4);
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(70, 100);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(702, 238);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "First Name";
            this.columnHeader1.Width = 136;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Last Name";
            this.columnHeader2.Width = 136;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Email";
            this.columnHeader3.Width = 136;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Phone";
            this.columnHeader4.Width = 136;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "State";
            this.columnHeader5.Width = 136;
            // 
            // lbStatus
            // 
            this.lbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStatus.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbStatus, 4);
            this.lbStatus.Location = new System.Drawing.Point(70, 57);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(702, 40);
            this.lbStatus.TabIndex = 7;
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFromEmail
            // 
            this.lbFromEmail.AutoSize = true;
            this.lbFromEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFromEmail.Location = new System.Drawing.Point(3, 30);
            this.lbFromEmail.Name = "lbFromEmail";
            this.lbFromEmail.Size = new System.Drawing.Size(61, 27);
            this.lbFromEmail.TabIndex = 20;
            this.lbFromEmail.Text = "From Email:";
            this.lbFromEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbFromID
            // 
            this.lbFromID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFromID.AutoSize = true;
            this.lbFromID.Location = new System.Drawing.Point(778, 57);
            this.lbFromID.Name = "lbFromID";
            this.lbFromID.Size = new System.Drawing.Size(0, 40);
            this.lbFromID.TabIndex = 4;
            this.lbFromID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbFromEmail
            // 
            this.tbFromEmail.Location = new System.Drawing.Point(70, 33);
            this.tbFromEmail.Name = "tbFromEmail";
            this.tbFromEmail.Size = new System.Drawing.Size(315, 20);
            this.tbFromEmail.TabIndex = 17;
            this.tbFromEmail.TextChanged += new System.EventHandler(this.tbSubject_TextChanged);
            // 
            // tbSubject
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tbSubject, 2);
            this.tbSubject.Location = new System.Drawing.Point(468, 33);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(304, 20);
            this.tbSubject.TabIndex = 19;
            this.tbSubject.Text = "Hi {FIRSTNAME} {LASTNAME}";
            this.tbSubject.TextChanged += new System.EventHandler(this.tbSubject_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 639);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Mini Member Transfer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbComplete;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.ComboBox cbTo;
        private System.Windows.Forms.Label lbFromID;
        private System.Windows.Forms.Label lbToID;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Label lbPreview;
        private System.Windows.Forms.Label lbComplete;
        private System.Windows.Forms.TextBox tbError;
        private System.Windows.Forms.ProgressBar pbTransfer;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lbFilePath;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label lbSubject;
        private System.Windows.Forms.TextBox tbFromEmail;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbFromEmail;

    }
}

