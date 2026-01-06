using ProjectR.Classes;
using ProjectR.Interfaces;

namespace ProjectR.Services
{
    public class GraphDataService(IGraphDataRepository repository) : IGraphDataService
    {
        private readonly IGraphDataRepository _repository = repository;

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
    }
}
