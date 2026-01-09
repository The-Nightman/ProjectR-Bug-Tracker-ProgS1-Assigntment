using ProjectR.Classes;

namespace ProjectR.Interfaces
{
    public interface IGraphDataRepository
    {
        public Task<List<GraphData<DateTime>>> GetDashboardScatterGraphData();

        public Task<(
            Dictionary<string, int>,
            Dictionary<string, int>
        )> GetDashboardRadarGraphData();

        public Task<List<GraphData<string>>> GetDashboardBarGraphData();

        public Task<(
            Dictionary<string, int>,
            Dictionary<string, int>
        )> GetProjectCurrentOpenIssuesBarGraphData(int projectId);

        public Task<Dictionary<int, int>> GetProjectActivityHeatmap(int projectId, int year);
    }
}
