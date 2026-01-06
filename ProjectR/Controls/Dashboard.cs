using ProjectR.Classes;
using ProjectR.Data;
using ProjectR.Interfaces;
using ScottPlot;

namespace ProjectR.Controls
{
    public partial class Dashboard : UserControl
    {
        private readonly Navigation _mainNav;
        private readonly DatabaseContext _context;
        private readonly IProjectsService _projectsService;
        private readonly IGraphDataService _graphService;

        public Dashboard(
            DatabaseContext dbContext,
            Navigation mainNav,
            IProjectsService projectsService,
            IGraphDataService graphService
        )
        {
            _mainNav = mainNav;
            _context = dbContext;
            _projectsService = projectsService;
            _graphService = graphService;
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Region = new Region(Utils.PaintRoundedCorners(this, 10));

            base.OnPaint(e);
        }

        private async void Dashboard_Load(object sender, EventArgs e)
        {
            List<ProjectPreview> projectPreviews = await _projectsService.GetProjectPreviews();
            List<GraphData<DateTime>> scatterData = await _graphService.GetDashboardScatterGraphData();
            List<GraphData<string>> radarData = await _graphService.GetDashboardRadarGraphData();
            List<GraphData<string>> barData = await _graphService.GetDashboardBarGraphData();

            DateTime startOfWeekRange = DateTime.Now.AddDays(-6).Date;
            DateTime todayWeekRange = DateTime.Now.Date;

            HandleResizeables();
            // If this isnt handled a vertical scroll bar will appear when the window is resized to overflow.
            flowLayoutPanelProjectCards.Height += SystemInformation.HorizontalScrollBarHeight;

            foreach (ProjectPreview proj in projectPreviews)
            {
                flowLayoutPanelProjectCards.Controls.Add(new ProjectCard(proj, _context, _mainNav, _graphService));
            }

            // Scatter Plot
            double[] xs = [.. scatterData.Select(gd => gd.XSeries.Date.ToOADate())];
            double[] ys = [.. scatterData.Select(gd => gd.Value)];

            formPlotDashboardActivityWeekly.Plot.Add.Scatter(xs, ys);
            var axis = formPlotDashboardActivityWeekly.Plot.Axes.DateTimeTicksBottom();
            formPlotDashboardActivityWeekly.UserInputProcessor.Disable();

            var tickGen = (ScottPlot.TickGenerators.DateTimeAutomatic)axis.TickGenerator;
            tickGen.LabelFormatter = (value) =>
            {
                return value.ToString("dd/MM");
            };

            formPlotDashboardActivityWeekly.Plot.Axes.Bottom.TickLabelStyle.Rotation = -45;
            formPlotDashboardActivityWeekly.Plot.Axes.Bottom.TickLabelStyle.Alignment =
                Alignment.MiddleRight;

            formPlotDashboardActivityWeekly.Plot.Axes.MarginsX(0);
            formPlotDashboardActivityWeekly.Plot.Axes.SetLimitsY(
                0,
                (ys.Max() + Math.Ceiling(ys.Max() / 10))
            );
            formPlotDashboardActivityWeekly.Refresh();

            // Radar Chart
            double[] radarYs = [.. radarData.Select(gd => gd.Value)];

            double radarAxisMax = radarYs.Max() switch
            {
                <= 10 => 10,
                <= 15 => 15,
                <= 20 => 20,
                _ => Math.Ceiling(radarYs.Max() / 10) * 10,
            };

            List<double> ticks = new(5);

            for (int i = 1; i <= 5; i++)
            {
                ticks.Add((radarAxisMax / 5) * i);
            }

            var radar = formPlotDashboardActivityLevels.Plot.Add.Radar(radarYs);
            radar.PolarAxis.SetSpokes([.. radarData.Select(dp => dp.XSeries)], radarAxisMax);
            radar.PolarAxis.StraightLines = true;
            radar.PolarAxis.SetCircles(
                [.. ticks.Select(i => i)],
                [.. ticks.Select(t => t.ToString())]
            );
            formPlotDashboardActivityLevels.Refresh();

            // Bar Graph
            for (int i = 0; i < barData.Count; i++)
            {
                formPlotDashboardActivityProjects.Plot.Add.Bar(
                    position: i,
                    value: barData[i].Value
                );
            }

            Tick[] projectTicks =
            [
                .. barData.Select<GraphData<string>, Tick>(
                    (p, i) => new(i, Utils.TrimString(p.XSeries, 6))
                ),
            ];

            formPlotDashboardActivityProjects.Plot.Axes.Bottom.TickGenerator =
                new ScottPlot.TickGenerators.NumericManual(projectTicks);
            formPlotDashboardActivityWeekly.Plot.Axes.Bottom.TickLabelStyle.Alignment =
                Alignment.MiddleRight;
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
