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
            this.lblProjCardTitle = new System.Windows.Forms.Label();
            this.lblProjOpenIssues = new System.Windows.Forms.Label();
            this.lblProjCritIssues = new System.Windows.Forms.Label();
            this.lblProjThisWeek = new System.Windows.Forms.Label();
            this.separator = new System.Windows.Forms.Label();
            this.lblProjLastActive = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblProjCardTitle
            // 
            this.lblProjCardTitle.AutoSize = true;
            this.lblProjCardTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjCardTitle.Location = new System.Drawing.Point(16, 16);
            this.lblProjCardTitle.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblProjCardTitle.Name = "lblProjCardTitle";
            this.lblProjCardTitle.Size = new System.Drawing.Size(165, 29);
            this.lblProjCardTitle.TabIndex = 0;
            this.lblProjCardTitle.Text = "ProjectName";
            // 
            // lblProjOpenIssues
            // 
            this.lblProjOpenIssues.AutoSize = true;
            this.lblProjOpenIssues.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjOpenIssues.Location = new System.Drawing.Point(16, 66);
            this.lblProjOpenIssues.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblProjOpenIssues.Name = "lblProjOpenIssues";
            this.lblProjOpenIssues.Size = new System.Drawing.Size(140, 20);
            this.lblProjOpenIssues.TabIndex = 0;
            this.lblProjOpenIssues.Text = "Open Issues: 111";
            // 
            // lblProjCritIssues
            // 
            this.lblProjCritIssues.AutoSize = true;
            this.lblProjCritIssues.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjCritIssues.Location = new System.Drawing.Point(205, 66);
            this.lblProjCritIssues.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblProjCritIssues.Name = "lblProjCritIssues";
            this.lblProjCritIssues.Size = new System.Drawing.Size(99, 20);
            this.lblProjCritIssues.TabIndex = 0;
            this.lblProjCritIssues.Text = "Critical: 111";
            // 
            // lblProjThisWeek
            // 
            this.lblProjThisWeek.AutoSize = true;
            this.lblProjThisWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjThisWeek.Location = new System.Drawing.Point(16, 114);
            this.lblProjThisWeek.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblProjThisWeek.Name = "lblProjThisWeek";
            this.lblProjThisWeek.Size = new System.Drawing.Size(125, 20);
            this.lblProjThisWeek.TabIndex = 1;
            this.lblProjThisWeek.Text = "This Week: 111";
            // 
            // separator
            // 
            this.separator.BackColor = System.Drawing.SystemColors.ControlDark;
            this.separator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.separator.Location = new System.Drawing.Point(16, 150);
            this.separator.Margin = new System.Windows.Forms.Padding(0, 16, 0, 16);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(288, 2);
            this.separator.TabIndex = 2;
            // 
            // lblProjLastActive
            // 
            this.lblProjLastActive.AutoSize = true;
            this.lblProjLastActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjLastActive.Location = new System.Drawing.Point(16, 164);
            this.lblProjLastActive.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblProjLastActive.Name = "lblProjLastActive";
            this.lblProjLastActive.Size = new System.Drawing.Size(148, 20);
            this.lblProjLastActive.TabIndex = 3;
            this.lblProjLastActive.Text = "Last Active: Today";
            // 
            // ProjectCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.lblProjLastActive);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.lblProjThisWeek);
            this.Controls.Add(this.lblProjCritIssues);
            this.Controls.Add(this.lblProjOpenIssues);
            this.Controls.Add(this.lblProjCardTitle);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "ProjectCard";
            this.Padding = new System.Windows.Forms.Padding(16);
            this.Size = new System.Drawing.Size(320, 200);
            this.Click += new System.EventHandler(this.ProjectCard_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProjCardTitle;
        private System.Windows.Forms.Label lblProjOpenIssues;
        private System.Windows.Forms.Label lblProjCritIssues;
        private System.Windows.Forms.Label lblProjThisWeek;
        private System.Windows.Forms.Label separator;
        private System.Windows.Forms.Label lblProjLastActive;
    }
}
