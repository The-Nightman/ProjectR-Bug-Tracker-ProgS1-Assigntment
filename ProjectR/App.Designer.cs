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
            flowLayoutPanelProjectCards = new FlowLayoutPanel();
            lblDashboardProjectsTitle = new Label();
            SuspendLayout();
            // 
            // flowLayoutPanelProjectCards
            // 
            flowLayoutPanelProjectCards.AutoScroll = true;
            flowLayoutPanelProjectCards.Location = new Point(16, 80);
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
            lblDashboardProjectsTitle.Location = new Point(16, 20);
            lblDashboardProjectsTitle.Margin = new Padding(0);
            lblDashboardProjectsTitle.Name = "lblDashboardProjectsTitle";
            lblDashboardProjectsTitle.Size = new Size(172, 32);
            lblDashboardProjectsTitle.TabIndex = 2;
            lblDashboardProjectsTitle.Text = "My Projects";
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 384);
            Controls.Add(lblDashboardProjectsTitle);
            Controls.Add(flowLayoutPanelProjectCards);
            Margin = new Padding(3, 4, 3, 4);
            Name = "App";
            Padding = new Padding(16, 20, 16, 20);
            Text = "ProjectR";
            Load += App_Load;
            SizeChanged += App_SizeChanged;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelProjectCards;
        private Label lblDashboardProjectsTitle;
    }
}
