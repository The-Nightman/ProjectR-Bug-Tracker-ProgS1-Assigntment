using ProjectR.Classes;
using ProjectR.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjectR
{
    public partial class App : Form
    {
        private List<ProjectPreview> projectPreviews = new List<ProjectPreview>()
        {
            new ProjectPreview("Project A", 12, 2, 5, DateTime.Now),
            new ProjectPreview("Project B", 60, 11, 9, DateTime.Now.AddDays(-2)),
            new ProjectPreview("Project C", 35, 1, 7, DateTime.Now.AddDays(-3)),
        };

        public App()
        {
            InitializeComponent();
        }

        private void App_Load(object sender, EventArgs e)
        {
            // This is need to ensure the FlowLayoutPanel is correctly sized on load or else it will be significantly smaller on load.
            flowLayoutPanelProjectCards.Width = this.ClientSize.Width - 32;
            // If this isnt handled a vertical scroll bar will appear when the window is resized to overflow.
            flowLayoutPanelProjectCards.Height += SystemInformation.HorizontalScrollBarHeight;

            foreach (ProjectPreview proj in projectPreviews)
            {
                flowLayoutPanelProjectCards.Controls.Add(new ProjectCard(proj));
            }
        }

        private void App_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanelProjectCards.Width = this.ClientSize.Width - 32;
        }
    }
}
