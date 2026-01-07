namespace ProjectR.Forms
{
    partial class AddNewProjectDialog
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
            btnSaveNewProject = new Button();
            groupBoxNewProjectDetails = new GroupBox();
            lblNewProjectName = new Label();
            textBoxNewProjectName = new TextBox();
            lblNewProjectCreatedAt = new Label();
            dateTimePickerNewProjectCreatedAt = new DateTimePicker();
            groupBoxNewProjectDetails.SuspendLayout();
            SuspendLayout();
            // 
            // btnSaveNewProject
            // 
            btnSaveNewProject.AccessibleDescription = "Save New Project";
            btnSaveNewProject.AccessibleName = "";
            btnSaveNewProject.BackColor = Color.LawnGreen;
            btnSaveNewProject.FlatStyle = FlatStyle.Flat;
            btnSaveNewProject.Location = new Point(12, 182);
            btnSaveNewProject.Margin = new Padding(0, 0, 8, 0);
            btnSaveNewProject.Name = "btnSaveNewProject";
            btnSaveNewProject.Size = new Size(389, 29);
            btnSaveNewProject.TabIndex = 27;
            btnSaveNewProject.Text = "Save";
            btnSaveNewProject.UseVisualStyleBackColor = false;
            btnSaveNewProject.Click += btnSaveNewProject_Click;
            // 
            // groupBoxNewProjectDetails
            // 
            groupBoxNewProjectDetails.Controls.Add(dateTimePickerNewProjectCreatedAt);
            groupBoxNewProjectDetails.Controls.Add(lblNewProjectCreatedAt);
            groupBoxNewProjectDetails.Controls.Add(lblNewProjectName);
            groupBoxNewProjectDetails.Controls.Add(textBoxNewProjectName);
            groupBoxNewProjectDetails.Location = new Point(12, 11);
            groupBoxNewProjectDetails.Name = "groupBoxNewProjectDetails";
            groupBoxNewProjectDetails.Size = new Size(389, 159);
            groupBoxNewProjectDetails.TabIndex = 26;
            groupBoxNewProjectDetails.TabStop = false;
            groupBoxNewProjectDetails.Text = "New Project Details";
            // 
            // lblNewProjectName
            // 
            lblNewProjectName.AutoSize = true;
            lblNewProjectName.Location = new Point(6, 35);
            lblNewProjectName.Name = "lblNewProjectName";
            lblNewProjectName.Size = new Size(99, 20);
            lblNewProjectName.TabIndex = 0;
            lblNewProjectName.Text = "Project Name";
            // 
            // textBoxNewProjectName
            // 
            textBoxNewProjectName.Location = new Point(6, 58);
            textBoxNewProjectName.Name = "textBoxNewProjectName";
            textBoxNewProjectName.Size = new Size(376, 27);
            textBoxNewProjectName.TabIndex = 1;
            // 
            // lblNewProjectCreatedAt
            // 
            lblNewProjectCreatedAt.AutoSize = true;
            lblNewProjectCreatedAt.Location = new Point(6, 97);
            lblNewProjectCreatedAt.Name = "lblNewProjectCreatedAt";
            lblNewProjectCreatedAt.Size = new Size(80, 20);
            lblNewProjectCreatedAt.TabIndex = 2;
            lblNewProjectCreatedAt.Text = "Created At";
            // 
            // dateTimePickerNewProjectCreatedAt
            // 
            dateTimePickerNewProjectCreatedAt.AccessibleDescription = "Enter the date for the projects creation";
            dateTimePickerNewProjectCreatedAt.Format = DateTimePickerFormat.Short;
            dateTimePickerNewProjectCreatedAt.Location = new Point(6, 120);
            dateTimePickerNewProjectCreatedAt.Name = "dateTimePickerNewProjectCreatedAt";
            dateTimePickerNewProjectCreatedAt.Size = new Size(376, 27);
            dateTimePickerNewProjectCreatedAt.TabIndex = 3;
            // 
            // AddNewProjectDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 222);
            Controls.Add(btnSaveNewProject);
            Controls.Add(groupBoxNewProjectDetails);
            Name = "AddNewProjectDialog";
            Text = "Add New Project";
            groupBoxNewProjectDetails.ResumeLayout(false);
            groupBoxNewProjectDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSaveNewProject;
        private GroupBox groupBoxNewProjectDetails;
        private Label lblNewProjectName;
        private TextBox textBoxNewProjectName;
        private DateTimePicker dateTimePickerNewProjectCreatedAt;
        private Label lblNewProjectCreatedAt;
    }
}