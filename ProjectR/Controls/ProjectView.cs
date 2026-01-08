using ProjectR.Classes;
using ProjectR.Forms;
using ProjectR.Interfaces;
using ScottPlot;
using System.Globalization;

namespace ProjectR.Controls
{
    public partial class ProjectView : UserControl
    {
        private readonly int _projectId;
        private readonly Navigation _mainNav;
        private readonly IProjectsService _projectsService;
        private readonly IGraphDataService _graphService;
        private readonly IIssuesService _issuesService;

        public ProjectView(
            Navigation mainNav,
            int projId,
            IProjectsService projectsService,
            IGraphDataService graphService,
            IIssuesService issuesService
        )
        {
            _projectId = projId;
            _mainNav = mainNav;
            _projectsService = projectsService;
            _graphService = graphService;
            _issuesService = issuesService;
            InitializeComponent();
        }

        private async void ProjectView_Load(object sender, EventArgs e)
        {
            ProjectDisplay? projectQuery = await _projectsService.GetProjectViewDetailsById(
                _projectId
            );

            if (projectQuery == null)
            {
                return;
            }

            lblProjectsProjectTitle.Text = projectQuery.ProjectName;
            lblProjectCreatedAt.Text = $"Created: {projectQuery.CreatedAt:dd/MM/yyyy}";

            dataGridViewIssues.DataSource = projectQuery.Issues;

            List<GraphData<string>> issuesData =
                await _graphService.GetProjectCurrentOpenIssuesBarGraphData(_projectId);

            // project activity heatmap
            int year = DateTime.Now.Year;

            CoordinateRange xRange = new(
                DateTime.Parse($"01-01-{year}", new CultureInfo("en-GB")).ToOADate(),
                DateTime.Parse($"31-12-{year}", new CultureInfo("en-GB")).ToOADate() - 0.5
            );

            var heatmap = formPlotProjectActivityHeatmap.Plot.Add.Heatmap(
                await _graphService.GetProjectActivityHeatmap(_projectId, year)
            );
            heatmap.Rectangle = new(xRange, new(0.5, 6.5));
            heatmap.CellAlignment = Alignment.LowerLeft;
            heatmap.Position = new(xRange.Min, xRange.Max, 0.5, 6.5);
            string[] colourStrings = ["#151b23", "#033a16", "#196c2e", "#2ea043", "#56d364"]; // github heatmap colour map
            ScottPlot.Color[] colours =
            [
                .. colourStrings.Select(cs => ScottPlot.Color.FromHex(cs)),
            ];
            heatmap.Colormap = new ScottPlot.Colormaps.Custom(colours, false);
            heatmap.ManualRange = new ScottPlot.Range(0, 4);
            formPlotProjectActivityHeatmap.Plot.HideGrid();
            formPlotProjectActivityHeatmap.Plot.Axes.Margins(0, 0);
            formPlotProjectActivityHeatmap.Plot.Axes.FrameColor(Colors.White);
            formPlotProjectActivityHeatmap.Plot.FigureBackground.Color = Colors.Transparent;
            formPlotProjectActivityHeatmap.Plot.DataBackground.Color = Colors.Transparent;
            formPlotProjectActivityHeatmap.Plot.Axes.Left.MajorTickStyle.Color = Colors.White;
            formPlotProjectActivityHeatmap.Plot.Axes.Left.TickLabelStyle.ForeColor = Colors.White;
            formPlotProjectActivityHeatmap.Plot.Axes.Bottom.MajorTickStyle.Color = Colors.White;
            formPlotProjectActivityHeatmap.Plot.Axes.Bottom.TickLabelStyle.ForeColor = Colors.White;

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

            // current open bugs bar graph
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

        private void dataGridViewIssues_SelectionChanged(object sender, EventArgs e)
        {
            btnOpenIssue.Enabled = dataGridViewIssues.SelectedRows.Count > 0;
        }

        private void dataGridViewIssues_DataBindingComplete(
            object sender,
            DataGridViewBindingCompleteEventArgs e
        )
        {
            dataGridViewIssues.ClearSelection();
        }

        private void btnOpenIssue_Click(object sender, EventArgs e)
        {
            int selectedIssueId = (int)dataGridViewIssues.SelectedRows[0].Cells["Id"].Value;

            _mainNav.UseNavigate(new IssueView(selectedIssueId, _issuesService));
        }

        private async void btnAddNewIssue_Click(object sender, EventArgs e)
        {
            Form dialog = new AddNewIssueDialog(_projectId, _issuesService);
            dialog.ShowDialog();

            await RefreshIssues();
        }

        private async Task RefreshIssues()
        {
            var query = await _projectsService.GetProjectViewDetailsById(_projectId);

            if (query == null)
            {
                return;
            }

            dataGridViewIssues.DataSource = query.Issues;
            dataGridViewIssues.Refresh();
        }
    }
}
