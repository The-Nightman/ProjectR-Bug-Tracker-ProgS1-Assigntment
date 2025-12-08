namespace ProjectR.Controls
{
    partial class BugTile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblBugTitle = new Label();
            lblBugChanges = new Label();
            lblBugStatusTitle = new Label();
            lblBugStatus = new Label();
            lblBugSeverityTitle = new Label();
            lblBugCreatedAt = new Label();
            lblBugLastUpdatedAt = new Label();
            SuspendLayout();
            // 
            // lblBugTitle
            // 
            lblBugTitle.AutoSize = true;
            lblBugTitle.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblBugTitle.Location = new Point(19, 16);
            lblBugTitle.Name = "lblBugTitle";
            lblBugTitle.Size = new Size(76, 20);
            lblBugTitle.TabIndex = 0;
            lblBugTitle.Text = "Bug Title";
            // 
            // lblBugChanges
            // 
            lblBugChanges.AutoSize = true;
            lblBugChanges.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblBugChanges.Location = new Point(163, 16);
            lblBugChanges.Name = "lblBugChanges";
            lblBugChanges.Size = new Size(94, 20);
            lblBugChanges.TabIndex = 1;
            lblBugChanges.Text = "Changes: n";
            // 
            // lblBugStatusTitle
            // 
            lblBugStatusTitle.AutoSize = true;
            lblBugStatusTitle.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblBugStatusTitle.Location = new Point(300, 16);
            lblBugStatusTitle.Name = "lblBugStatusTitle";
            lblBugStatusTitle.Size = new Size(62, 20);
            lblBugStatusTitle.TabIndex = 2;
            lblBugStatusTitle.Text = "Status:";
            // 
            // lblBugStatus
            // 
            lblBugStatus.AutoSize = true;
            lblBugStatus.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblBugStatus.Location = new Point(368, 16);
            lblBugStatus.Name = "lblBugStatus";
            lblBugStatus.Size = new Size(119, 20);
            lblBugStatus.TabIndex = 3;
            lblBugStatus.Text = "statusIndicator";
            // 
            // lblBugSeverityTitle
            // 
            lblBugSeverityTitle.AutoSize = true;
            lblBugSeverityTitle.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblBugSeverityTitle.Location = new Point(518, 16);
            lblBugSeverityTitle.Name = "lblBugSeverityTitle";
            lblBugSeverityTitle.Size = new Size(74, 20);
            lblBugSeverityTitle.TabIndex = 4;
            lblBugSeverityTitle.Text = "Severity:";
            // 
            // lblBugCreatedAt
            // 
            lblBugCreatedAt.AutoSize = true;
            lblBugCreatedAt.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblBugCreatedAt.Location = new Point(875, 16);
            lblBugCreatedAt.Name = "lblBugCreatedAt";
            lblBugCreatedAt.Size = new Size(201, 20);
            lblBugCreatedAt.TabIndex = 5;
            lblBugCreatedAt.Text = "Date Created: nn/nn/nnnn";
            // 
            // lblBugLastUpdatedAt
            // 
            lblBugLastUpdatedAt.AutoSize = true;
            lblBugLastUpdatedAt.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblBugLastUpdatedAt.Location = new Point(657, 16);
            lblBugLastUpdatedAt.Name = "lblBugLastUpdatedAt";
            lblBugLastUpdatedAt.Size = new Size(192, 20);
            lblBugLastUpdatedAt.TabIndex = 6;
            lblBugLastUpdatedAt.Text = "Last Update: nn/nn/nnnn";
            // 
            // BugTile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblBugLastUpdatedAt);
            Controls.Add(lblBugCreatedAt);
            Controls.Add(lblBugSeverityTitle);
            Controls.Add(lblBugStatus);
            Controls.Add(lblBugStatusTitle);
            Controls.Add(lblBugChanges);
            Controls.Add(lblBugTitle);
            Margin = new Padding(0);
            Name = "BugTile";
            Padding = new Padding(16);
            Size = new Size(1095, 60);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBugTitle;
        private Label lblBugChanges;
        private Label lblBugStatusTitle;
        private Label lblBugStatus;
        private Label lblBugSeverityTitle;
        private Label lblBugCreatedAt;
        private Label lblBugLastUpdatedAt;
    }
}
