namespace ProjectR.Controls
{
    partial class ProjectView
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
            lblProjectsProjectTitle = new Label();
            lblProjectActivityHeatmapTitle = new Label();
            formPlotProjectActivityHeatmap = new ScottPlot.WinForms.FormsPlot();
            separator = new Label();
            lblProjectTrackedIssuesTitle = new Label();
            formPlotCurrentOpenBugs = new ScottPlot.WinForms.FormsPlot();
            lblProjectCurrentOpenBugs = new Label();
            panelHeatmap = new Panel();
            panel1 = new Panel();
            flowLayoutPanelBugTiles = new FlowLayoutPanel();
            panelHeatmap.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblProjectsProjectTitle
            // 
            lblProjectsProjectTitle.AutoSize = true;
            lblProjectsProjectTitle.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProjectsProjectTitle.ForeColor = SystemColors.ControlText;
            lblProjectsProjectTitle.Location = new Point(16, 16);
            lblProjectsProjectTitle.Margin = new Padding(0, 0, 0, 16);
            lblProjectsProjectTitle.Name = "lblProjectsProjectTitle";
            lblProjectsProjectTitle.Size = new Size(189, 32);
            lblProjectsProjectTitle.TabIndex = 3;
            lblProjectsProjectTitle.Text = "ProjectName";
            // 
            // lblProjectActivityHeatmapTitle
            // 
            lblProjectActivityHeatmapTitle.AutoSize = true;
            lblProjectActivityHeatmapTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProjectActivityHeatmapTitle.ForeColor = SystemColors.ControlLightLight;
            lblProjectActivityHeatmapTitle.Location = new Point(16, 16);
            lblProjectActivityHeatmapTitle.Margin = new Padding(0);
            lblProjectActivityHeatmapTitle.Name = "lblProjectActivityHeatmapTitle";
            lblProjectActivityHeatmapTitle.Size = new Size(167, 31);
            lblProjectActivityHeatmapTitle.TabIndex = 15;
            lblProjectActivityHeatmapTitle.Text = "Project Activity";
            // 
            // formPlotProjectActivityHeatmap
            // 
            formPlotProjectActivityHeatmap.DisplayScale = 1.25F;
            formPlotProjectActivityHeatmap.Location = new Point(16, 49);
            formPlotProjectActivityHeatmap.Margin = new Padding(0);
            formPlotProjectActivityHeatmap.Name = "formPlotProjectActivityHeatmap";
            formPlotProjectActivityHeatmap.Size = new Size(604, 233);
            formPlotProjectActivityHeatmap.TabIndex = 13;
            // 
            // separator
            // 
            separator.BackColor = SystemColors.ControlDark;
            separator.BorderStyle = BorderStyle.FixedSingle;
            separator.Location = new Point(16, 386);
            separator.Margin = new Padding(0, 16, 0, 16);
            separator.Name = "separator";
            separator.Size = new Size(1101, 2);
            separator.TabIndex = 11;
            // 
            // lblProjectTrackedIssuesTitle
            // 
            lblProjectTrackedIssuesTitle.AutoSize = true;
            lblProjectTrackedIssuesTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProjectTrackedIssuesTitle.ForeColor = SystemColors.ControlText;
            lblProjectTrackedIssuesTitle.Location = new Point(19, 64);
            lblProjectTrackedIssuesTitle.Name = "lblProjectTrackedIssuesTitle";
            lblProjectTrackedIssuesTitle.Size = new Size(159, 31);
            lblProjectTrackedIssuesTitle.TabIndex = 19;
            lblProjectTrackedIssuesTitle.Text = "Tracked Issues";
            // 
            // formPlotCurrentOpenBugs
            // 
            formPlotCurrentOpenBugs.DisplayScale = 1.25F;
            formPlotCurrentOpenBugs.Location = new Point(16, 47);
            formPlotCurrentOpenBugs.Margin = new Padding(0);
            formPlotCurrentOpenBugs.Name = "formPlotCurrentOpenBugs";
            formPlotCurrentOpenBugs.Size = new Size(419, 233);
            formPlotCurrentOpenBugs.TabIndex = 20;
            // 
            // lblProjectCurrentOpenBugs
            // 
            lblProjectCurrentOpenBugs.AutoSize = true;
            lblProjectCurrentOpenBugs.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProjectCurrentOpenBugs.ForeColor = SystemColors.ControlLightLight;
            lblProjectCurrentOpenBugs.Location = new Point(16, 16);
            lblProjectCurrentOpenBugs.Margin = new Padding(0);
            lblProjectCurrentOpenBugs.Name = "lblProjectCurrentOpenBugs";
            lblProjectCurrentOpenBugs.Size = new Size(208, 31);
            lblProjectCurrentOpenBugs.TabIndex = 21;
            lblProjectCurrentOpenBugs.Text = "Current Open Bugs";
            // 
            // panelHeatmap
            // 
            panelHeatmap.BackColor = Color.FromArgb(57, 57, 57);
            panelHeatmap.Controls.Add(lblProjectActivityHeatmapTitle);
            panelHeatmap.Controls.Add(formPlotProjectActivityHeatmap);
            panelHeatmap.Location = new Point(19, 404);
            panelHeatmap.Margin = new Padding(0);
            panelHeatmap.Name = "panelHeatmap";
            panelHeatmap.Padding = new Padding(16);
            panelHeatmap.Size = new Size(636, 298);
            panelHeatmap.TabIndex = 22;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(57, 57, 57);
            panel1.Controls.Add(lblProjectCurrentOpenBugs);
            panel1.Controls.Add(formPlotCurrentOpenBugs);
            panel1.Location = new Point(666, 406);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(16);
            panel1.Size = new Size(451, 296);
            panel1.TabIndex = 23;
            // 
            // flowLayoutPanelBugTiles
            // 
            flowLayoutPanelBugTiles.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelBugTiles.Location = new Point(19, 98);
            flowLayoutPanelBugTiles.Name = "flowLayoutPanelBugTiles";
            flowLayoutPanelBugTiles.Size = new Size(1095, 269);
            flowLayoutPanelBugTiles.TabIndex = 24;
            // 
            // ProjectView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(flowLayoutPanelBugTiles);
            Controls.Add(panel1);
            Controls.Add(panelHeatmap);
            Controls.Add(lblProjectTrackedIssuesTitle);
            Controls.Add(separator);
            Controls.Add(lblProjectsProjectTitle);
            Margin = new Padding(0);
            Name = "ProjectView";
            Padding = new Padding(16);
            Size = new Size(1133, 718);
            Load += ProjectView_Load;
            panelHeatmap.ResumeLayout(false);
            panelHeatmap.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProjectsProjectTitle;
        private Label lblProjectActivityHeatmapTitle;
        private ScottPlot.WinForms.FormsPlot formPlotProjectActivityHeatmap;
        private Label separator;
        private Label lblProjectTrackedIssuesTitle;
        private ScottPlot.WinForms.FormsPlot formPlotCurrentOpenBugs;
        private Label lblProjectCurrentOpenBugs;
        private Panel panelHeatmap;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanelBugTiles;
    }
}
