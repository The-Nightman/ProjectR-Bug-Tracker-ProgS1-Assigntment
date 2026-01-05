namespace ProjectR.Forms
{
    partial class AddNewIssueDialog
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
            lblNewIssueTitle = new Label();
            textBoxNewIssueTitle = new TextBox();
            lblNewIssueDesc = new Label();
            richTextBoxNewIssueDesc = new RichTextBox();
            lblNewIssueSeverity = new Label();
            comboBoxNewIssueSeverity = new ComboBox();
            lblNewIssueStatus = new Label();
            lblNewIssueCreatedAt = new Label();
            dateTimePickerNewIssue = new DateTimePicker();
            groupBoxNewIssueDetails = new GroupBox();
            textBoxNewIssueStatus = new TextBox();
            btnSaveNewIssue = new Button();
            groupBoxNewIssueDetails.SuspendLayout();
            SuspendLayout();
            // 
            // lblNewIssueTitle
            // 
            lblNewIssueTitle.AutoSize = true;
            lblNewIssueTitle.Location = new Point(6, 23);
            lblNewIssueTitle.Name = "lblNewIssueTitle";
            lblNewIssueTitle.Size = new Size(74, 20);
            lblNewIssueTitle.TabIndex = 0;
            lblNewIssueTitle.Text = "Issue Title";
            // 
            // textBoxNewIssueTitle
            // 
            textBoxNewIssueTitle.Location = new Point(6, 46);
            textBoxNewIssueTitle.Name = "textBoxNewIssueTitle";
            textBoxNewIssueTitle.Size = new Size(376, 27);
            textBoxNewIssueTitle.TabIndex = 1;
            // 
            // lblNewIssueDesc
            // 
            lblNewIssueDesc.AutoSize = true;
            lblNewIssueDesc.Location = new Point(6, 76);
            lblNewIssueDesc.Name = "lblNewIssueDesc";
            lblNewIssueDesc.Size = new Size(121, 20);
            lblNewIssueDesc.TabIndex = 2;
            lblNewIssueDesc.Text = "Issue Description";
            // 
            // richTextBoxNewIssueDesc
            // 
            richTextBoxNewIssueDesc.Location = new Point(6, 99);
            richTextBoxNewIssueDesc.Name = "richTextBoxNewIssueDesc";
            richTextBoxNewIssueDesc.Size = new Size(376, 120);
            richTextBoxNewIssueDesc.TabIndex = 3;
            richTextBoxNewIssueDesc.Text = "";
            // 
            // lblNewIssueSeverity
            // 
            lblNewIssueSeverity.AutoSize = true;
            lblNewIssueSeverity.Location = new Point(6, 222);
            lblNewIssueSeverity.Name = "lblNewIssueSeverity";
            lblNewIssueSeverity.Size = new Size(61, 20);
            lblNewIssueSeverity.TabIndex = 4;
            lblNewIssueSeverity.Text = "Severity";
            // 
            // comboBoxNewIssueSeverity
            // 
            comboBoxNewIssueSeverity.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxNewIssueSeverity.FormattingEnabled = true;
            comboBoxNewIssueSeverity.Location = new Point(6, 245);
            comboBoxNewIssueSeverity.Name = "comboBoxNewIssueSeverity";
            comboBoxNewIssueSeverity.Size = new Size(376, 28);
            comboBoxNewIssueSeverity.TabIndex = 5;
            // 
            // lblNewIssueStatus
            // 
            lblNewIssueStatus.AutoSize = true;
            lblNewIssueStatus.Location = new Point(6, 276);
            lblNewIssueStatus.Name = "lblNewIssueStatus";
            lblNewIssueStatus.Size = new Size(49, 20);
            lblNewIssueStatus.TabIndex = 6;
            lblNewIssueStatus.Text = "Status";
            // 
            // lblNewIssueCreatedAt
            // 
            lblNewIssueCreatedAt.AutoSize = true;
            lblNewIssueCreatedAt.Location = new Point(6, 330);
            lblNewIssueCreatedAt.Name = "lblNewIssueCreatedAt";
            lblNewIssueCreatedAt.Size = new Size(80, 20);
            lblNewIssueCreatedAt.TabIndex = 8;
            lblNewIssueCreatedAt.Text = "Created At";
            // 
            // dateTimePickerNewIssue
            // 
            dateTimePickerNewIssue.Format = DateTimePickerFormat.Custom;
            dateTimePickerNewIssue.Location = new Point(6, 353);
            dateTimePickerNewIssue.Name = "dateTimePickerNewIssue";
            dateTimePickerNewIssue.Size = new Size(376, 27);
            dateTimePickerNewIssue.TabIndex = 9;
            // 
            // groupBoxNewIssueDetails
            // 
            groupBoxNewIssueDetails.Controls.Add(textBoxNewIssueStatus);
            groupBoxNewIssueDetails.Controls.Add(richTextBoxNewIssueDesc);
            groupBoxNewIssueDetails.Controls.Add(dateTimePickerNewIssue);
            groupBoxNewIssueDetails.Controls.Add(lblNewIssueTitle);
            groupBoxNewIssueDetails.Controls.Add(lblNewIssueCreatedAt);
            groupBoxNewIssueDetails.Controls.Add(textBoxNewIssueTitle);
            groupBoxNewIssueDetails.Controls.Add(lblNewIssueDesc);
            groupBoxNewIssueDetails.Controls.Add(lblNewIssueStatus);
            groupBoxNewIssueDetails.Controls.Add(lblNewIssueSeverity);
            groupBoxNewIssueDetails.Controls.Add(comboBoxNewIssueSeverity);
            groupBoxNewIssueDetails.Location = new Point(12, 12);
            groupBoxNewIssueDetails.Name = "groupBoxNewIssueDetails";
            groupBoxNewIssueDetails.Size = new Size(389, 390);
            groupBoxNewIssueDetails.TabIndex = 10;
            groupBoxNewIssueDetails.TabStop = false;
            groupBoxNewIssueDetails.Text = "New Issue Details";
            // 
            // textBoxNewIssueStatus
            // 
            textBoxNewIssueStatus.Location = new Point(6, 299);
            textBoxNewIssueStatus.Name = "textBoxNewIssueStatus";
            textBoxNewIssueStatus.ReadOnly = true;
            textBoxNewIssueStatus.Size = new Size(376, 27);
            textBoxNewIssueStatus.TabIndex = 10;
            // 
            // btnSaveNewIssue
            // 
            btnSaveNewIssue.AccessibleDescription = "Save New Issue";
            btnSaveNewIssue.AccessibleName = "";
            btnSaveNewIssue.BackColor = Color.LawnGreen;
            btnSaveNewIssue.FlatStyle = FlatStyle.Flat;
            btnSaveNewIssue.Location = new Point(12, 407);
            btnSaveNewIssue.Margin = new Padding(0, 0, 8, 0);
            btnSaveNewIssue.Name = "btnSaveNewIssue";
            btnSaveNewIssue.Size = new Size(389, 29);
            btnSaveNewIssue.TabIndex = 25;
            btnSaveNewIssue.Text = "Save";
            btnSaveNewIssue.UseVisualStyleBackColor = false;
            btnSaveNewIssue.Click += btnSaveNewIssue_Click;
            // 
            // AddNewIssueDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 447);
            Controls.Add(btnSaveNewIssue);
            Controls.Add(groupBoxNewIssueDetails);
            Name = "AddNewIssueDialog";
            Text = "AddNewIssueDialog";
            Load += AddNewIssueDialog_Load;
            groupBoxNewIssueDetails.ResumeLayout(false);
            groupBoxNewIssueDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblNewIssueTitle;
        private TextBox textBoxNewIssueTitle;
        private Label lblNewIssueDesc;
        private RichTextBox richTextBoxNewIssueDesc;
        private Label lblNewIssueSeverity;
        private ComboBox comboBoxNewIssueSeverity;
        private Label lblNewIssueStatus;
        private Label lblNewIssueCreatedAt;
        private DateTimePicker dateTimePickerNewIssue;
        private GroupBox groupBoxNewIssueDetails;
        private TextBox textBoxNewIssueStatus;
        private Button btnSaveNewIssue;
    }
}