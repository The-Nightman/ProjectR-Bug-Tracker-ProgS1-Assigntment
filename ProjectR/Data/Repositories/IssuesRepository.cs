using ProjectR.DTOs;
using ProjectR.Entities;
using ProjectR.Interfaces;

namespace ProjectR.Data.Repositories
{
    public class IssuesRepository(DatabaseContext dbContext) : IIssuesRepository
    {
        private readonly DatabaseContext _context = dbContext;

        public async Task AddNewIssue(int projectId, AddNewIssueDto newIssueDto)
        {
            var trackedProject = await _context.Projects.FindAsync(projectId);

            await _context.Issues.AddAsync(
                new Issue
                {
                    ProjectId = trackedProject.Id,
                    Name = newIssueDto.Name,
                    Description = newIssueDto.Description,
                    Severity = newIssueDto.Severity,
                    Status = newIssueDto.Status,
                    CreatedAt = newIssueDto.CreatedAt,
                    LastUpdated = newIssueDto.CreatedAt,
                    Media = [],
                    Changes = [],
                    Project = trackedProject,
                }
            );

            await _context.SaveChangesAsync();
        }
    }
}
