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
    }
}
