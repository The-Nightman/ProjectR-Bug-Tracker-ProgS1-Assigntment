using Microsoft.EntityFrameworkCore;
using ProjectR.Interfaces;

namespace ProjectR.Data.Repositories
{
    public class GraphDataRepository(DatabaseContext dbContext) : IGraphDataRepository
    {
        private readonly DatabaseContext _context = dbContext;

        public async Task<(Dictionary<string, int>, Dictionary<string, int>)> GetDashboardRadarGraphData()
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
    }
}
