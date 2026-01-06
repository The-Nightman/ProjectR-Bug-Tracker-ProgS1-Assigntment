using ProjectR.Classes;

namespace ProjectR.Interfaces
{
    public interface IGraphDataService
    {
        public Task<List<GraphData<string>>> GetDashboardRadarGraphData();
    }
}
