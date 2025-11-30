namespace ProjectR
{
    partial class App
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelMainView = new Panel();
            panelNavBar = new Panel();
            lblApplicationTitle = new Label();
            pictureBox1 = new PictureBox();
            btnNavbarProjects = new Button();
            imageListNavbarIconsControl = new ImageList(components);
            btnNavbarDashboard = new Button();
            panelNavBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelMainView
            // 
            panelMainView.Location = new Point(267, 87);
            panelMainView.Margin = new Padding(8);
            panelMainView.Name = "panelMainView";
            panelMainView.Size = new Size(1138, 718);
            panelMainView.TabIndex = 0;
            // 
            // panelNavBar
            // 
            panelNavBar.BackColor = Color.FromArgb(40, 40, 40);
            panelNavBar.Controls.Add(lblApplicationTitle);
            panelNavBar.Controls.Add(pictureBox1);
            panelNavBar.Controls.Add(btnNavbarProjects);
            panelNavBar.Controls.Add(btnNavbarDashboard);
            panelNavBar.Dock = DockStyle.Left;
            panelNavBar.Location = new Point(0, 0);
            panelNavBar.Name = "panelNavBar";
            panelNavBar.Size = new Size(250, 822);
            panelNavBar.TabIndex = 1;
            // 
            // lblApplicationTitle
            // 
            lblApplicationTitle.AutoSize = true;
            lblApplicationTitle.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblApplicationTitle.ForeColor = Color.FromArgb(222, 182, 96);
            lblApplicationTitle.Location = new Point(50, 13);
            lblApplicationTitle.Name = "lblApplicationTitle";
            lblApplicationTitle.Size = new Size(101, 31);
            lblApplicationTitle.TabIndex = 2;
            lblApplicationTitle.Text = "ProjectR";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.projectRLogoDark;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // btnNavbarProjects
            // 
            btnNavbarProjects.BackColor = Color.Transparent;
            btnNavbarProjects.FlatAppearance.BorderSize = 0;
            btnNavbarProjects.FlatStyle = FlatStyle.Flat;
            btnNavbarProjects.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNavbarProjects.ForeColor = Color.FromArgb(222, 182, 96);
            btnNavbarProjects.FlatAppearance.MouseOverBackColor = Color.FromArgb(204, 87, 87, 87);
            btnNavbarProjects.FlatAppearance.MouseDownBackColor = Color.FromArgb(204, 18, 18, 18);
            btnNavbarProjects.ImageAlign = ContentAlignment.MiddleLeft;
            btnNavbarProjects.ImageList = imageListNavbarIconsControl;
            btnNavbarProjects.Location = new Point(3, 152);
            btnNavbarProjects.Name = "btnNavbarProjects";
            btnNavbarProjects.Size = new Size(244, 59);
            btnNavbarProjects.TabIndex = 1;
            btnNavbarProjects.Text = "Projects";
            btnNavbarProjects.TextAlign = ContentAlignment.MiddleLeft;
            btnNavbarProjects.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNavbarProjects.UseVisualStyleBackColor = false;
            btnNavbarProjects.Click += btnNavbarProjects_Click;
            // 
            // imageListNavbarIconsControl
            // 
            imageListNavbarIconsControl.ColorDepth = ColorDepth.Depth32Bit;
            imageListNavbarIconsControl.ImageSize = new Size(32, 32);
            imageListNavbarIconsControl.TransparentColor = Color.Transparent;
            // 
            // btnNavbarDashboard
            // 
            btnNavbarDashboard.BackColor = Color.Transparent;
            btnNavbarDashboard.FlatAppearance.BorderSize = 0;
            btnNavbarDashboard.FlatStyle = FlatStyle.Flat;
            btnNavbarDashboard.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNavbarDashboard.ForeColor = Color.FromArgb(222, 182, 96);
            btnNavbarDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(204, 87, 87, 87);
            btnNavbarDashboard.FlatAppearance.MouseDownBackColor = Color.FromArgb(204, 18, 18, 18);
            btnNavbarDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnNavbarDashboard.ImageList = imageListNavbarIconsControl;
            btnNavbarDashboard.Location = new Point(3, 87);
            btnNavbarDashboard.Name = "btnNavbarDashboard";
            btnNavbarDashboard.Size = new Size(244, 59);
            btnNavbarDashboard.TabIndex = 0;
            btnNavbarDashboard.Text = "Dashboard";
            btnNavbarDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnNavbarDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNavbarDashboard.UseVisualStyleBackColor = false;
            btnNavbarDashboard.Click += btnNavbarDashboard_Click;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(1422, 822);
            Controls.Add(panelNavBar);
            Controls.Add(panelMainView);
            Margin = new Padding(3, 4, 3, 4);
            Name = "App";
            Text = "ProjectR";
            Load += App_Load;
            panelNavBar.ResumeLayout(false);
            panelNavBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMainView;
        private Panel panelNavBar;
        private Button btnNavbarDashboard;
        private ImageList imageListNavbarIconsControl;
        private Button btnNavbarProjects;
        private PictureBox pictureBox1;
        private Label lblApplicationTitle;
    }
}
