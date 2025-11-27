namespace ProjectR.Controls
{
    partial class ProjectCard
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
            lblProjCardTitle = new Label();
            lblProjOpenIssues = new Label();
            lblProjCritIssues = new Label();
            lblProjThisWeek = new Label();
            separator = new Label();
            lblProjLastActive = new Label();
            SuspendLayout();
            // 
            // lblProjCardTitle
            // 
            lblProjCardTitle.AutoSize = true;
            lblProjCardTitle.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProjCardTitle.Location = new Point(16, 20);
            lblProjCardTitle.Margin = new Padding(0, 0, 3, 0);
            lblProjCardTitle.Name = "lblProjCardTitle";
            lblProjCardTitle.Size = new Size(165, 29);
            lblProjCardTitle.TabIndex = 0;
            lblProjCardTitle.Text = "ProjectName";
            // 
            // lblProjOpenIssues
            // 
            lblProjOpenIssues.AutoSize = true;
            lblProjOpenIssues.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProjOpenIssues.Location = new Point(16, 82);
            lblProjOpenIssues.Margin = new Padding(0, 0, 3, 0);
            lblProjOpenIssues.Name = "lblProjOpenIssues";
            lblProjOpenIssues.Size = new Size(140, 20);
            lblProjOpenIssues.TabIndex = 0;
            lblProjOpenIssues.Text = "Open Issues: 111";
            // 
            // lblProjCritIssues
            // 
            lblProjCritIssues.AutoSize = true;
            lblProjCritIssues.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProjCritIssues.Location = new Point(205, 82);
            lblProjCritIssues.Margin = new Padding(3, 0, 0, 0);
            lblProjCritIssues.Name = "lblProjCritIssues";
            lblProjCritIssues.Size = new Size(99, 20);
            lblProjCritIssues.TabIndex = 0;
            lblProjCritIssues.Text = "Critical: 111";
            // 
            // lblProjThisWeek
            // 
            lblProjThisWeek.AutoSize = true;
            lblProjThisWeek.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProjThisWeek.Location = new Point(16, 142);
            lblProjThisWeek.Margin = new Padding(0, 0, 3, 0);
            lblProjThisWeek.Name = "lblProjThisWeek";
            lblProjThisWeek.Size = new Size(125, 20);
            lblProjThisWeek.TabIndex = 1;
            lblProjThisWeek.Text = "This Week: 111";
            // 
            // separator
            // 
            separator.BackColor = SystemColors.ControlDark;
            separator.BorderStyle = BorderStyle.FixedSingle;
            separator.Location = new Point(16, 188);
            separator.Margin = new Padding(0, 20, 0, 20);
            separator.Name = "separator";
            separator.Size = new Size(288, 2);
            separator.TabIndex = 2;
            // 
            // lblProjLastActive
            // 
            lblProjLastActive.AutoSize = true;
            lblProjLastActive.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProjLastActive.Location = new Point(16, 205);
            lblProjLastActive.Margin = new Padding(0, 0, 3, 0);
            lblProjLastActive.Name = "lblProjLastActive";
            lblProjLastActive.Size = new Size(148, 20);
            lblProjLastActive.TabIndex = 3;
            lblProjLastActive.Text = "Last Active: Today";
            // 
            // ProjectCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(lblProjLastActive);
            Controls.Add(separator);
            Controls.Add(lblProjThisWeek);
            Controls.Add(lblProjCritIssues);
            Controls.Add(lblProjOpenIssues);
            Controls.Add(lblProjCardTitle);
            Margin = new Padding(8, 10, 8, 10);
            Name = "ProjectCard";
            Padding = new Padding(16, 20, 16, 20);
            Size = new Size(320, 250);
            Click += ProjectCard_Click;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label lblProjCardTitle;
        private Label lblProjOpenIssues;
        private Label lblProjCritIssues;
        private Label lblProjThisWeek;
        private Label separator;
        private Label lblProjLastActive;
    }
}
