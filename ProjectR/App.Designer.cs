namespace ProjectR
{
    partial class App
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
            this.flowLayoutPanelProjectCards = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDashboardProjectsTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanelProjectCards
            // 
            this.flowLayoutPanelProjectCards.AutoScroll = true;
            this.flowLayoutPanelProjectCards.Location = new System.Drawing.Point(16, 64);
            this.flowLayoutPanelProjectCards.Margin = new System.Windows.Forms.Padding(0, 16, 0, 16);
            this.flowLayoutPanelProjectCards.Name = "flowLayoutPanelProjectCards";
            this.flowLayoutPanelProjectCards.Size = new System.Drawing.Size(1101, 216);
            this.flowLayoutPanelProjectCards.TabIndex = 1;
            this.flowLayoutPanelProjectCards.WrapContents = false;
            // 
            // lblDashboardProjectsTitle
            // 
            this.lblDashboardProjectsTitle.AutoSize = true;
            this.lblDashboardProjectsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboardProjectsTitle.Location = new System.Drawing.Point(16, 16);
            this.lblDashboardProjectsTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblDashboardProjectsTitle.Name = "lblDashboardProjectsTitle";
            this.lblDashboardProjectsTitle.Size = new System.Drawing.Size(172, 32);
            this.lblDashboardProjectsTitle.TabIndex = 2;
            this.lblDashboardProjectsTitle.Text = "My Projects";
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 307);
            this.Controls.Add(this.lblDashboardProjectsTitle);
            this.Controls.Add(this.flowLayoutPanelProjectCards);
            this.Name = "App";
            this.Padding = new System.Windows.Forms.Padding(16);
            this.Text = "ProjectR";
            this.Load += new System.EventHandler(this.App_Load);
            this.SizeChanged += new System.EventHandler(this.App_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProjectCards;
        private System.Windows.Forms.Label lblDashboardProjectsTitle;
    }
}

