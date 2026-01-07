using Microsoft.EntityFrameworkCore;
using ProjectR.DTOs;
using ProjectR.Entities;
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
                    LastUpdated = p.Issues.Count > 0 ? p.Issues.Max(i => i.LastUpdated) : p.CreatedAt,
                })
                .OrderBy(p => p.ProjectName)
                .ToListAsync();

            return results;
        }

        public async Task<ProjectDisplayDto?> GetProjectViewDetailsById(int projectId)
        {
            var projectQuery = await _context
                .Projects.Where(p => p.Id == projectId)
                .Select(p => new ProjectDisplayDto
                {
                    ProjectId = p.Id,
                    ProjectName = p.Name,
                    CreatedAt = p.CreatedAt,
                    Issues = p
                        .Issues.Select(i => new IssuePreviewDto
                        {
                            IssueId = i.Id,
                            IssueName = i.Name,
                            ChangesCount = i.Changes.Count,
                            Status = i.Status,
                            Severity = i.Severity,
                            CreatedAt = i.CreatedAt,
                            LastUpdated = i.LastUpdated,
                        })
                        .OrderByDescending(i => i.LastUpdated)
                        .ToList(),
                })
                .FirstOrDefaultAsync();

            return projectQuery;
        }

        public async Task AddNewProject(NewProjectDto newProject)
        {
            await _context.Projects.AddAsync(new Project { Name = newProject.Name, Issues = [], CreatedAt = newProject.CreatedAt });

            await _context.SaveChangesAsync();
        }
    }
}
