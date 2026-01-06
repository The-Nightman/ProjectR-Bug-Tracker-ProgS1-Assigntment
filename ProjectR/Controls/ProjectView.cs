using Microsoft.EntityFrameworkCore;
using ProjectR.Classes;
using ProjectR.Data;
using ProjectR.Entities;
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
        private readonly DatabaseContext _context;
        private Project? _project;
        private readonly IProjectsService _projectsService;
        private readonly IGraphDataService _graphService;

        public ProjectView(
            DatabaseContext dbContext,
            Navigation mainNav,
            int projId,
            IProjectsService projectsService,
            IGraphDataService graphService
        )
        {
            _projectId = projId;
            _mainNav = mainNav;
            _context = dbContext;
            _projectsService = projectsService;
            _graphService = graphService;
            InitializeComponent();
        }

        private async void ProjectView_Load(object sender, EventArgs e)
        {
            _project = _context.Projects.Where(p => p.Id == _projectId).FirstOrDefault();

            lblProjectsProjectTitle.Text = _context
                .Projects.Where(p => p.Id == _projectId)
                .Select(p => p.Name)
                .FirstOrDefault();

            var issuesQuery = _context
                .Issues.Where(i => i.ProjectId == _projectId)
                .OrderByDescending(o => o.LastUpdated)
                .Select(i => new IssueListItem(
                    i.Id,
                    i.Name,
                    i.Changes.Count,
                    i.Status,
                    i.Severity,
                    i.CreatedAt,
                    i.LastUpdated
                ))
                .ToList();

            dataGridViewIssues.DataSource = issuesQuery;

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

            _mainNav.UseNavigate(new IssueView(_context, selectedIssueId));
        }

        private async void btnAddNewIssue_Click(object sender, EventArgs e)
        {
            Form dialog = new AddNewIssueDialog(_project!, _context);
            dialog.ShowDialog();

            await RefreshIssues();
        }

        private async Task RefreshIssues()
        {
            var issuesQuery = await _context
                .Issues.Where(i => i.ProjectId == _projectId)
                .OrderByDescending(o => o.LastUpdated)
                .Select(i => new IssueListItem(
                    i.Id,
                    i.Name,
                    i.Changes.Count,
                    i.Status,
                    i.Severity,
                    i.CreatedAt,
                    i.LastUpdated
                ))
                .ToListAsync();

            dataGridViewIssues.DataSource = issuesQuery;
            dataGridViewIssues.Refresh();
        }
    }
}
