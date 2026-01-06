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

        private List<ProjectPreview> projectPreviews = [];
        private List<GraphData<DateTime>> scatterData = [];
        private List<GraphData<string>> radarData = [];
        private List<GraphData<string>> barData = [];

        private async void Dashboard_Load(object sender, EventArgs e)
        {
            DateTime startOfWeekRange = DateTime.Now.AddDays(-6).Date;
            DateTime todayWeekRange = DateTime.Now.Date;

            projectPreviews = await _projectsService.GetProjectPreviews();

            scatterData =
            [
                .. _context
                    .Changes.Where(c =>
                        c.CreatedAt.Date >= startOfWeekRange && c.CreatedAt.Date <= todayWeekRange
                    )
                    .GroupBy(g => new
                    {
                        g.CreatedAt.Year,
                        g.CreatedAt.Month,
                        g.CreatedAt.Day,
                    })
                    .Select(o => new GraphData<DateTime>(
                        new DateTime(o.Key.Year, o.Key.Month, o.Key.Day),
                        o.Count()
                    )),
            ];

            for (int i = 0; i <= 6; i++)
            {
                DateTime targetDate = DateTime.Now.AddDays(-6 + i).Date;

                if (!scatterData.Any(sq => sq.XSeries == targetDate))
                {
                    scatterData.Insert(
                        i,
                        new GraphData<DateTime>(DateTime.Now.AddDays(-6 + i).Date, 0)
                    );
                }
            }

            HandleResizeables();
            // If this isnt handled a vertical scroll bar will appear when the window is resized to overflow.
            flowLayoutPanelProjectCards.Height += SystemInformation.HorizontalScrollBarHeight;

            foreach (ProjectPreview proj in projectPreviews)
            {
                flowLayoutPanelProjectCards.Controls.Add(new ProjectCard(proj, _context, _mainNav));
            }

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

            radarData = await _graphService.GetDashboardRadarGraphData();

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

            barData =
            [
                .. _context
                    .Changes.Where(c =>
                        c.CreatedAt.Date >= DateTime.Now.AddDays(-6).Date
                        && c.CreatedAt.Date <= DateTime.Now.Date
                    )
                    .GroupBy(c => c.Issue.Project.Name)
                    .Select(g => new GraphData<string>(g.Key, g.Count())),
            ];

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
