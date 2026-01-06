using ProjectR.Classes;
using ProjectR.Interfaces;

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
    }
}
