using ProjectR.Classes;

namespace ProjectR.Interfaces
{
    public interface IGraphDataService
    {
        public Task<List<GraphData<DateTime>>> GetDashboardScatterGraphData();

        public Task<List<GraphData<string>>> GetDashboardRadarGraphData();

        public Task<List<GraphData<string>>> GetDashboardBarGraphData();

        public Task<List<GraphData<string>>> GetProjectCurrentOpenIssuesBarGraphData(int projectId);

        public Task<double[,]> GetProjectActivityHeatmap(int projectId, int year);
    }
}
