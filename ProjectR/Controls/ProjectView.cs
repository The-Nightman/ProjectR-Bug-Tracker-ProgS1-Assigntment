using ProjectR.Classes;
using ProjectR.Data;
using ScottPlot;
using System.Globalization;

namespace ProjectR.Controls
{
    public partial class ProjectView : UserControl
    {
        private readonly int _projectId;
        private readonly Navigation _mainNav;
        private readonly DatabaseContext _context;

        public ProjectView(DatabaseContext dbContext, Navigation mainNav, int projId)
        {
            _projectId = projId;
            _mainNav = mainNav;
            _context = dbContext;
            InitializeComponent();
        }

        private List<GraphData<string>> issuesData = [];

        private void ProjectView_Load(object sender, EventArgs e)
        {
            List<string> severityLevels = ["Low", "Medium", "Critical"];
            List<string> statusLevels = ["Investigating", "In Review", "Fixed"];

            var querySeverity = _context
                .Issues.Where(i => i.ProjectId == _projectId)
                .GroupBy(g => g.Severity)
                .Select(s => new { s.Key, Value = s.Count() })
                .ToDictionary(x => x.Key, x => x.Value);

            var queryStatus = _context
                .Issues.Where(c => c.ProjectId == _projectId)
                .GroupBy(c => c.Status)
                .Select(s => new { s.Key, Value = s.Count() })
                .ToDictionary(x => x.Key, x => x.Value);

            List<GraphData<string>> listSeverity =
            [
                .. severityLevels.Select(s => new GraphData<string>(
                    s,
                    querySeverity.TryGetValue(s, out int value) ? value : 0
                )),
            ];

            List<GraphData<string>> listStatus =
            [
                .. statusLevels.Select(s => new GraphData<string>(
                    s,
                    queryStatus.TryGetValue(s, out int value) ? value : 0
                )),
            ];

            issuesData = [.. listSeverity.Concat(listStatus)];

            int[] testTiles = new int[10];

            foreach (var item in testTiles)
            {
                flowLayoutPanelBugTiles.Controls.Add(new BugTile());
            }

            if (flowLayoutPanelBugTiles.VerticalScroll.Visible)
            {
                flowLayoutPanelBugTiles.Width += SystemInformation.VerticalScrollBarWidth;
            }

            int year = DateTime.Now.Year;

            CoordinateRange xRange = new(
                DateTime.Parse($"01-01-{year}", new CultureInfo("en-GB")).ToOADate(),
                DateTime.Parse($"31-12-{year}", new CultureInfo("en-GB")).ToOADate() - 0.5
            );

            var heatmap = formPlotProjectActivityHeatmap.Plot.Add.Heatmap(PreProcessHeatmapData());
            heatmap.Rectangle = new(xRange, new(0.5, 6.5));
            heatmap.CellAlignment = Alignment.LowerLeft;
            heatmap.Position = new(xRange.Min, xRange.Max, 0.5, 6.5);
            heatmap.Colormap = new ScottPlot.Colormaps.Greens();
            formPlotProjectActivityHeatmap.Plot.Add.ColorBar(heatmap);
            formPlotProjectActivityHeatmap.Plot.HideGrid();
            formPlotProjectActivityHeatmap.Plot.Axes.Margins(0, 0);

            Tick[] dayTicks =
            [
                new(7, "Sun"),
                new(6, "Mon"),
                new(5, "Tue"),
                new(4, "Wed"),
                new(3, "Thu"),
                new(2, "Fri"),
                new(1, "Sat"),
            ];

            formPlotProjectActivityHeatmap.Plot.Axes.Left.TickGenerator =
                new ScottPlot.TickGenerators.NumericManual(dayTicks);

            ScottPlot.TickGenerators.DateTimeManual axisX = new();

            for (int m = 1; m <= 12; m++)
            {
                DateTime dt = new(year, m, 1);
                double oa = dt.ToOADate();
                if (oa >= xRange.Min && oa <= xRange.Max)
                {
                    axisX.AddMajor(dt, dt.ToString("MMM"));
                }
            }

            formPlotProjectActivityHeatmap.Plot.Axes.Bottom.TickGenerator = axisX;

            formPlotProjectActivityHeatmap.UserInputProcessor.Disable();
            formPlotProjectActivityHeatmap.Refresh();

            for (int i = 0; i < issuesData.Count; i++)
            {
                var bar = formPlotCurrentOpenBugs.Plot.Add.Bar(
                    position: i,
                    value: issuesData[i].Value
                );

                bar.Color = i switch
                {
                    0 => new ScottPlot.Color("#47D5A6"),
                    1 => new ScottPlot.Color("#D7AC61"),
                    2 => new ScottPlot.Color("#D94A4A"),
                    3 => new ScottPlot.Color("#4077D1"),
                    4 => new ScottPlot.Color("#A835D8"),
                    _ => Colors.Gray,
                };
            }

            Tick[] projectTicks =
            [
                .. issuesData.Select<GraphData<string>, Tick>((p, i) => new(i, p.XSeries)),
            ];

            formPlotCurrentOpenBugs.Plot.Axes.Bottom.TickGenerator =
                new ScottPlot.TickGenerators.NumericManual(projectTicks);
            formPlotCurrentOpenBugs.Plot.Axes.Bottom.TickLabelStyle.Alignment = ScottPlot
                .Alignment
                .MiddleRight;
            formPlotCurrentOpenBugs.Plot.Axes.Margins(left: 0, right: 0, bottom: 0);

            formPlotCurrentOpenBugs.UserInputProcessor.Disable();
            formPlotCurrentOpenBugs.Refresh();
        }

        private static double[,] PreProcessHeatmapData()
        {
            // create dictionary of dayOfYear key to Changes.Count value
            // interate through cells in loop
            // if cell number exists as key then cell value = Changes.Count
            // else cell value = 0

            // TODO :  explore styling cells with 0.5/1px borders to create grid effect
            // TODO : explore colour grading options for heatmap and whether to invert values

            List<List<double>> yearData2d =
            [
                [],
                [],
                [],
                [],
                [],
                [],
                [],
            ];

            int year = DateTime.Now.Year;

            DateOnly startDate = DateOnly.Parse($"01-01-{year}", new CultureInfo("en-GB"));
            DateOnly endDate = DateOnly.Parse($"31-12-{year}", new CultureInfo("en-GB"));

            int maxDays = DateTime.IsLeapYear(year) ? 366 : 365;

            int dayOffset = -(int)startDate.DayOfWeek;

            int dayofyear = startDate.DayOfYear;

            for (int i = dayOffset; i < maxDays + Math.Abs(dayOffset); i++)
            {
                double dayData =
                    i < 0 ? double.NaN
                    : i >= maxDays ? double.NaN
                    : i + 1;

                DateOnly currentDate = startDate.AddDays(i);

                yearData2d[(int)currentDate.DayOfWeek].Add(dayData);
            }

            double[,] processedData = new double[7, yearData2d[0].Count];

            for (int w = 0; w < yearData2d.Count; w++)
            {
                for (int h = 0; h < yearData2d[w].Count; h++)
                {
                    processedData[w, h] = yearData2d[w][h];
                }
            }

            return processedData;
        }
    }
}
