using Microsoft.EntityFrameworkCore;
using ProjectR.Classes;
using ProjectR.Interfaces;

namespace ProjectR.Data.Repositories
{
    public class GraphDataRepository(DatabaseContext dbContext) : IGraphDataRepository
    {
        private readonly DatabaseContext _context = dbContext;

        public async Task<List<GraphData<DateTime>>> GetDashboardScatterGraphData()
        {
            var scatterData = await _context
                .Changes.Where(c =>
                    c.CreatedAt.Date >= DateTime.Now.AddDays(-6).Date
                    && c.CreatedAt.Date <= DateTime.Now.Date
                )
                .GroupBy(c => c.CreatedAt.Date)
                .Select(s => new GraphData<DateTime>(s.Key, s.Count()))
                .ToListAsync();

            return scatterData;
        }

        public async Task<(
            Dictionary<string, int>,
            Dictionary<string, int>
        )> GetDashboardRadarGraphData()
        {
            var radarQuerySeverity = await _context
                .Changes.Where(c =>
                    c.CreatedAt.Date >= DateTime.Now.AddDays(-6).Date
                    && c.CreatedAt.Date <= DateTime.Now.Date
                )
                .GroupBy(c => c.Issue.Severity)
                .Select(s => new { s.Key, Value = s.Count() })
                .ToDictionaryAsync(x => x.Key, x => x.Value);

            var radarQueryStatus = await _context
                .Changes.Where(c =>
                    c.CreatedAt.Date >= DateTime.Now.AddDays(-6).Date
                    && c.CreatedAt.Date <= DateTime.Now.Date
                )
                .GroupBy(c => c.Issue.Status)
                .Select(s => new { s.Key, Value = s.Count() })
                .ToDictionaryAsync(x => x.Key, x => x.Value);

            return (radarQuerySeverity, radarQueryStatus);
        }

        public async Task<List<GraphData<string>>> GetDashboardBarGraphData()
        {
            return await _context
                .Changes.Where(c =>
                    c.CreatedAt.Date >= DateTime.Now.AddDays(-6).Date
                    && c.CreatedAt.Date <= DateTime.Now.Date
                )
                .GroupBy(c => c.Issue.Project.Name)
                .Select(g => new GraphData<string>(g.Key, g.Count()))
                .ToListAsync();
        }
    }
}
