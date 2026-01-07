using Microsoft.EntityFrameworkCore;
using ProjectR.DTOs;
using ProjectR.Interfaces;

namespace ProjectR.Data.Repositories
{
    public class ProjectsRepository(DatabaseContext dbContext) : IProjectsRepository
    {
        private readonly DatabaseContext _context = dbContext;

        public async Task<List<ProjectPreviewDto>> GetProjectPreviews()
        {
            DateTime startOfWeekRange = DateTime.Now.AddDays(-6).Date;
            DateTime todayWeekRange = DateTime.Now.Date;

            List<ProjectPreviewDto> results = await _context
                .Projects.Select(p => new ProjectPreviewDto
                {
                    ProjectId = p.Id,
                    ProjectName = p.Name,
                    OpenIssues = p.Issues.Count(i => i.Status != "Fixed"),
                    CriticalIssues = p.Issues.Count(i =>
                        i.Severity == "Critical" && i.Status != "Fixed"
                    ),
                    ThisWeekIssues = p.Issues.Count(i =>
                        i.LastUpdated >= startOfWeekRange && i.LastUpdated <= todayWeekRange
                    ),
                    LastUpdated = p.Issues.Max(i => i.LastUpdated),
                })
                .OrderBy(p => p.ProjectName)
                .ToListAsync();

            return results;
        }

        public async Task<ProjectDisplayDto?> GetProjectViewDetailsById(int projectId)
        {
            var projectQuery = await _context
                .Projects
                .Where(p => p.Id == projectId)
                .Select(p => new ProjectDisplayDto
                {
                    ProjectId = p.Id,
                    ProjectName = p.Name,
                    Issues = p.Issues.Select(i => new IssuePreviewDto
                    {
                        IssueId = i.Id,
                        IssueName = i.Name,
                        ChangesCount = i.Changes.Count,
                        Status = i.Status,
                        Severity = i.Severity,
                        CreatedAt = i.CreatedAt,
                        LastUpdated = i.LastUpdated,
                    }).OrderByDescending(i => i.LastUpdated).ToList(),
                })
                .FirstOrDefaultAsync();

            return projectQuery;
        }
    }
}
