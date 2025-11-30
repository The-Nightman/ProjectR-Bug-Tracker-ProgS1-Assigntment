using ProjectR.Classes;
using ScottPlot;

namespace ProjectR.Controls
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private List<ProjectPreview> projectPreviews =
        [
            new ProjectPreview("Project A", 12, 2, 5, DateTime.Now),
            new ProjectPreview("Project B", 60, 11, 9, DateTime.Now.AddDays(-2)),
            new ProjectPreview("Project C", 35, 1, 7, DateTime.Now.AddDays(-3)),
        ];

        private class Datapoint(DateTime date, int issuesResolved, string level, string projectName)
        {
            public DateTime Date { get; set; } = date;
            public int IssuesResolved { get; set; } = issuesResolved;

            public string Level { get; set; } = level;

            public string ProjectName { get; set; } = projectName;
        }

        private List<Datapoint> data =
        [
            new Datapoint(DateTime.Now.AddDays(-6), 5, "Low", "Project A"),
            new Datapoint(DateTime.Now.AddDays(-5), 8, "Investigating", "Project B"),
            new Datapoint(DateTime.Now.AddDays(-4), 6, "Medium", "Project C"),
            new Datapoint(DateTime.Now.AddDays(-3), 10, "Breaking", "Project D"),
            new Datapoint(DateTime.Now.AddDays(-2), 7, "Fixed", "Project E"),
            new Datapoint(DateTime.Now.AddDays(-1), 12, "In Review", "Project F"),
            new Datapoint(DateTime.Now, 9, "Low", "Project G"),
        ];

        private void Dashboard_Load(object sender, EventArgs e)
        {
            HandleResizeables();
            // If this isnt handled a vertical scroll bar will appear when the window is resized to overflow.
            flowLayoutPanelProjectCards.Height += SystemInformation.HorizontalScrollBarHeight;

            foreach (ProjectPreview proj in projectPreviews)
            {
                flowLayoutPanelProjectCards.Controls.Add(new ProjectCard(proj));
            }

            double[] xs = [.. data.Select(dp => dp.Date.Date.ToOADate())];
            double[] ys = [.. data.Select(dp => (double)dp.IssuesResolved)];

            formPlotDashboardActivityWeekly.Plot.Add.Scatter(xs, ys);
            var axis = formPlotDashboardActivityWeekly.Plot.Axes.DateTimeTicksBottom();
            formPlotDashboardActivityWeekly.UserInputProcessor.Disable();

            var tickGen = (ScottPlot.TickGenerators.DateTimeAutomatic)axis.TickGenerator;
            tickGen.LabelFormatter = (value) =>
            {
                return value.ToString("dd/MM");
            };

            formPlotDashboardActivityWeekly.Plot.Axes.Bottom.TickLabelStyle.Rotation = -45;
            formPlotDashboardActivityWeekly.Plot.Axes.Bottom.TickLabelStyle.Alignment = ScottPlot
                .Alignment
                .MiddleRight;

            formPlotDashboardActivityWeekly.Plot.Axes.MarginsX(0);
            formPlotDashboardActivityWeekly.Plot.Axes.SetLimitsY(
                0,
                (ys.Max() + Math.Ceiling(ys.Max() / 10))
            );
            formPlotDashboardActivityWeekly.Refresh();

            double radarAxisMax = (double)(ys.Max()) switch
            {
                <= 10 => 10,
                <= 15 => 15,
                <= 20 => 20,
                _ => Math.Ceiling(ys.Max() / 10) * 10,
            };

            List<double> ticks = new(5);

            for (int i = 1; i <= 5; i++)
            {
                ticks.Add((radarAxisMax / 5) * i);
            }

            var radar = formPlotDashboardActivityLevels.Plot.Add.Radar(ys);
            radar.PolarAxis.SetSpokes([.. data.Select(dp => dp.Level)], length: radarAxisMax);
            radar.PolarAxis.StraightLines = true;
            radar.PolarAxis.SetCircles(
                [.. ticks.Select(i => i)],
                [.. ticks.Select(t => t.ToString())]
            );
            formPlotDashboardActivityLevels.Refresh();

            for (int i = 0; i < data.Count; i++)
            {
                formPlotDashboardActivityProjects.Plot.Add.Bar(
                    position: i,
                    value: data[i].IssuesResolved
                );
            }

            Tick[] projectTicks =
            [
                .. data.Select<Datapoint, Tick>(
                    (p, i) => new(i, Utils.TrimString(p.ProjectName, 6))
                ),
            ];

            formPlotDashboardActivityProjects.Plot.Axes.Bottom.TickGenerator =
                new ScottPlot.TickGenerators.NumericManual(projectTicks);
            formPlotDashboardActivityWeekly.Plot.Axes.Bottom.TickLabelStyle.Alignment = ScottPlot
                .Alignment
                .MiddleRight;
            formPlotDashboardActivityProjects.Plot.Axes.Margins(left: 0, right: 0, bottom: 0);

            formPlotDashboardActivityProjects.Refresh();
        }

        private void App_SizeChanged(object sender, EventArgs e)
        {
            HandleResizeables();
        }

        private void HandleResizeables()
        {
            // This is need to ensure the FlowLayoutPanel is correctly sized on load or else it will be significantly smaller on load.
            flowLayoutPanelProjectCards.Width = Width - 32;
            separator.Width = Width - 32;
        }
    }
}
