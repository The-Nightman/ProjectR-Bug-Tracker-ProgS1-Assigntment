namespace ProjectR.Interfaces
{
    public interface IGraphDataRepository
    {
        public Task<(Dictionary<string, int>, Dictionary<string, int>)> GetDashboardRadarGraphData();
    }
}
