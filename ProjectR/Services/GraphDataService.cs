using ProjectR.Classes;
using ProjectR.Interfaces;
using System.Globalization;

namespace ProjectR.Services
{
    public class GraphDataService(IGraphDataRepository repository) : IGraphDataService
    {
        private readonly IGraphDataRepository _repository = repository;

        public async Task<List<GraphData<DateTime>>> GetDashboardScatterGraphData()
        {
            var scatterData = await _repository.GetDashboardScatterGraphData();

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

            return scatterData;
        }

        public async Task<List<GraphData<string>>> GetDashboardRadarGraphData()
        {
            List<string> severityLevels = ["Low", "Medium", "Critical"];
            List<string> statusLevels = ["Investigating", "In Review", "Fixed"];

            var radarData = await _repository.GetDashboardRadarGraphData();

            List<GraphData<string>> radarListSeverity =
            [
                .. severityLevels.Select(s => new GraphData<string>(
                    s,
                    radarData.Item1.TryGetValue(s, out int value) ? value : 0
                )),
            ];

            List<GraphData<string>> radarListStatus =
            [
                .. statusLevels.Select(s => new GraphData<string>(
                    s,
                    radarData.Item2.TryGetValue(s, out int value) ? value : 0
                )),
            ];

            return [.. radarListSeverity.Concat(radarListStatus)];
        }

        public async Task<List<GraphData<string>>> GetDashboardBarGraphData()
        {
            return await _repository.GetDashboardBarGraphData();
        }

        public async Task<List<GraphData<string>>> GetProjectCurrentOpenIssuesBarGraphData(
            int projectId
        )
        {
            List<string> severityLevels = ["Low", "Medium", "Critical"];
            List<string> statusLevels = ["Investigating", "In Review", "Fixed"];

            var barData = await _repository.GetProjectCurrentOpenIssuesBarGraphData(projectId);

            List<GraphData<string>> barListSeverity =
            [
                .. severityLevels.Select(s => new GraphData<string>(
                    s,
                    barData.Item1.TryGetValue(s, out int value) ? value : 0
                )),
            ];

            List<GraphData<string>> barListStatus =
            [
                .. statusLevels.Select(s => new GraphData<string>(
                    s,
                    barData.Item2.TryGetValue(s, out int value) ? value : 0
                )),
            ];

            return [.. barListSeverity.Concat(barListStatus)];
        }

        public async Task<double[,]> GetProjectActivityHeatmap(int projectId, int year)
        {
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

            var heatmapData = await _repository.GetProjectActivityHeatmap(projectId, year);

            DateOnly startDate = DateOnly.Parse($"01-01-{year}", new CultureInfo("en-GB"));

            int maxDays = DateTime.IsLeapYear(year) ? 366 : 365;

            // Fix for incorrectly calculated trailing days and more efficient refactor adapted from: https://stackoverflow.com/a/20364799
            for (
                int i = -(int)startDate.DayOfWeek;
                i < maxDays + (6 - ((int)startDate.DayOfWeek + maxDays - 1) % 7);
                i++
            )
            {
                double dayData;

                if (i < 0 || i >= maxDays)
                {
                    dayData = double.NaN;
                }
                else
                {
                    // bucket the values into 5 levels for heatmap display, this lets us consolidate
                    // values and is due to issues with the colour bar not showing the full colour
                    // map and incremental values not being very relevant or understandable
                    dayData = heatmapData.TryGetValue(i + 1, out int value) switch
                    {
                        true => value switch
                        {
                            <= 5 => 1,
                            <= 10 => 2,
                            <= 15 => 3,
                            _ => 4,
                        },
                        false => 0,
                    };
                }

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
