namespace ProjectR.Controls
{
    partial class Dashboard
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
            flowLayoutPanelProjectCards = new FlowLayoutPanel();
            lblDashboardProjectsTitle = new Label();
            separator = new Label();
            lblDashboardActivity = new Label();
            formPlotDashboardActivityWeekly = new ScottPlot.WinForms.FormsPlot();
            formPlotDashboardActivityLevels = new ScottPlot.WinForms.FormsPlot();
            lblDashboardActivityWeekly = new Label();
            lblDashboardActivityByLevels = new Label();
            lblDashboardActivityProjects = new Label();
            formPlotDashboardActivityProjects = new ScottPlot.WinForms.FormsPlot();
            SuspendLayout();
            // 
            // flowLayoutPanelProjectCards
            // 
            flowLayoutPanelProjectCards.AutoScroll = true;
            flowLayoutPanelProjectCards.Location = new Point(16, 68);
            flowLayoutPanelProjectCards.Margin = new Padding(0, 20, 0, 20);
            flowLayoutPanelProjectCards.Name = "flowLayoutPanelProjectCards";
            flowLayoutPanelProjectCards.Size = new Size(1101, 270);
            flowLayoutPanelProjectCards.TabIndex = 1;
            flowLayoutPanelProjectCards.WrapContents = false;
            // 
            // lblDashboardProjectsTitle
            // 
            lblDashboardProjectsTitle.AutoSize = true;
            lblDashboardProjectsTitle.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDashboardProjectsTitle.Location = new Point(16, 16);
            lblDashboardProjectsTitle.Margin = new Padding(0);
            lblDashboardProjectsTitle.Name = "lblDashboardProjectsTitle";
            lblDashboardProjectsTitle.Size = new Size(172, 32);
            lblDashboardProjectsTitle.TabIndex = 2;
            lblDashboardProjectsTitle.Text = "My Projects";
            // 
            // separator
            // 
            separator.BackColor = SystemColors.ControlDark;
            separator.BorderStyle = BorderStyle.FixedSingle;
            separator.Location = new Point(16, 374);
            separator.Margin = new Padding(0, 16, 0, 16);
            separator.Name = "separator";
            separator.Size = new Size(1101, 2);
            separator.TabIndex = 3;
            // 
            // lblDashboardActivity
            // 
            lblDashboardActivity.AutoSize = true;
            lblDashboardActivity.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDashboardActivity.Location = new Point(16, 392);
            lblDashboardActivity.Margin = new Padding(0, 0, 0, 16);
            lblDashboardActivity.Name = "lblDashboardActivity";
            lblDashboardActivity.Size = new Size(160, 32);
            lblDashboardActivity.TabIndex = 4;
            lblDashboardActivity.Text = "My Activity";
            // 
            // formPlotDashboardActivityWeekly
            // 
            formPlotDashboardActivityWeekly.DisplayScale = 1.25F;
            formPlotDashboardActivityWeekly.Location = new Point(19, 474);
            formPlotDashboardActivityWeekly.Name = "formPlotDashboardActivityWeekly";
            formPlotDashboardActivityWeekly.Size = new Size(364, 233);
            formPlotDashboardActivityWeekly.TabIndex = 5;
            // 
            // formPlotDashboardActivityLevels
            // 
            formPlotDashboardActivityLevels.DisplayScale = 1.25F;
            formPlotDashboardActivityLevels.Location = new Point(389, 474);
            formPlotDashboardActivityLevels.Name = "formPlotDashboardActivityLevels";
            formPlotDashboardActivityLevels.Size = new Size(300, 233);
            formPlotDashboardActivityLevels.TabIndex = 6;
            // 
            // lblDashboardActivityWeekly
            // 
            lblDashboardActivityWeekly.AutoSize = true;
            lblDashboardActivityWeekly.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboardActivityWeekly.Location = new Point(19, 440);
            lblDashboardActivityWeekly.Name = "lblDashboardActivityWeekly";
            lblDashboardActivityWeekly.Size = new Size(165, 31);
            lblDashboardActivityWeekly.TabIndex = 7;
            lblDashboardActivityWeekly.Text = "Recent Activity";
            // 
            // lblDashboardActivityByLevels
            // 
            lblDashboardActivityByLevels.AutoSize = true;
            lblDashboardActivityByLevels.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboardActivityByLevels.Location = new Point(389, 440);
            lblDashboardActivityByLevels.Name = "lblDashboardActivityByLevels";
            lblDashboardActivityByLevels.Size = new Size(188, 31);
            lblDashboardActivityByLevels.TabIndex = 8;
            lblDashboardActivityByLevels.Text = "Activity By Levels";
            // 
            // lblDashboardActivityProjects
            // 
            lblDashboardActivityProjects.AutoSize = true;
            lblDashboardActivityProjects.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboardActivityProjects.Location = new Point(730, 440);
            lblDashboardActivityProjects.Name = "lblDashboardActivityProjects";
            lblDashboardActivityProjects.Size = new Size(207, 31);
            lblDashboardActivityProjects.TabIndex = 9;
            lblDashboardActivityProjects.Text = "Activity By Projects";
            // 
            // formPlotDashboardActivityProjects
            // 
            formPlotDashboardActivityProjects.DisplayScale = 1.25F;
            formPlotDashboardActivityProjects.Location = new Point(730, 474);
            formPlotDashboardActivityProjects.Name = "formPlotDashboardActivityProjects";
            formPlotDashboardActivityProjects.Size = new Size(384, 233);
            formPlotDashboardActivityProjects.TabIndex = 10;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(57, 57, 57);
            Controls.Add(formPlotDashboardActivityProjects);
            Controls.Add(lblDashboardActivityProjects);
            Controls.Add(lblDashboardActivityByLevels);
            Controls.Add(lblDashboardActivityWeekly);
            Controls.Add(formPlotDashboardActivityLevels);
            Controls.Add(formPlotDashboardActivityWeekly);
            Controls.Add(lblDashboardProjectsTitle);
            Controls.Add(flowLayoutPanelProjectCards);
            Controls.Add(separator);
            Controls.Add(lblDashboardActivity);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Dashboard";
            Padding = new Padding(16);
            Size = new Size(1133, 718);
            Load += Dashboard_Load;
            SizeChanged += App_SizeChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelProjectCards;
        private Label lblDashboardProjectsTitle;
        private Label separator;
        private Label lblDashboardActivity;
        private ScottPlot.WinForms.FormsPlot formPlotDashboardActivityWeekly;
        private ScottPlot.WinForms.FormsPlot formPlotDashboardActivityLevels;
        private Label lblDashboardActivityWeekly;
        private Label lblDashboardActivityByLevels;
        private Label lblDashboardActivityProjects;
        private ScottPlot.WinForms.FormsPlot formPlotDashboardActivityProjects;
    }
}
