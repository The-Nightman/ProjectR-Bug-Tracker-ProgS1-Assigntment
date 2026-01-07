using Microsoft.EntityFrameworkCore;
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
            var trackedProject =
                await _context.Projects.FindAsync(projectId)
                ?? throw new ArgumentException($"Project with ID {projectId} does not exist.");

            _ = await _context.Issues.AddAsync(
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

        public async Task<IssueDto> GetIssueById(int issueId)
        {
            var issueQuery =
                await _context
                    .Issues.Include(i => i.Media)
                    .Include(i => i.Changes)
                    .FirstOrDefaultAsync(i => i.Id == issueId)
                ?? throw new ArgumentException($"Issue with ID {issueId} does not exist.");

            return new IssueDto
            {
                Id = issueQuery.Id,
                Name = issueQuery.Name,
                Description = issueQuery.Description,
                Severity = issueQuery.Severity,
                Status = issueQuery.Status,
                CreatedAt = issueQuery.CreatedAt,
                LastUpdated = issueQuery.LastUpdated,
                Changes =
                [
                    .. issueQuery
                        .Changes.Select(c => new ChangeDto
                        {
                            Id = c.Id,
                            ChangeHash = c.ChangeHash,
                            Name = c.Name,
                            Description = c.Description,
                            CreatedAt = c.CreatedAt,
                            IssueId = c.IssueId,
                        })
                        .OrderByDescending(c => c.CreatedAt),
                ],
                Media =
                [
                    .. issueQuery
                        .Media.Select(m => new MediaDto
                        {
                            Id = m.Id,
                            Title = m.Title,
                            Description = m.Description,
                            Path = m.Path,
                            IssueId = m.IssueId,
                        })
                        .OrderBy(m => m.Title),
                ],
                ProjectId = issueQuery.ProjectId,
            };
        }

        public async Task UpdateIssueDetails(int issueId, EditIssueDetailsDto editIssueDetailsDto)
        {
            var trackedIssue =
                await _context.Issues.FirstOrDefaultAsync(i => i.Id == issueId)
                ?? throw new ArgumentException($"Issue with ID {issueId} does not exist.");

            trackedIssue.Name = editIssueDetailsDto.Name;
            trackedIssue.Description = editIssueDetailsDto.Description;
            trackedIssue.Severity = editIssueDetailsDto.Severity;
            trackedIssue.Status = editIssueDetailsDto.Status;

            await _context.SaveChangesAsync();
        }

        public async Task<List<MediaDto>> GetIssueMedia(int issueId)
        {
            return await _context
                .Media.Where(m => m.IssueId == issueId)
                .Select(m => new MediaDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Path = m.Path,
                    IssueId = m.IssueId,
                })
                .OrderBy(m => m.Title)
                .ToListAsync();
        }

        public async Task AddNewMedia(int issueId, NewMediaDto newMedia)
        {
            var trackedIssue =
                await _context.Issues.FindAsync(issueId)
                ?? throw new ArgumentException($"Issue with ID {issueId} does not exist.");

            _ = await _context.Media.AddAsync(
                new Media
                {
                    IssueId = issueId,
                    Title = newMedia.Title,
                    Description = newMedia.Description,
                    MediaType = "Image",
                    Path = newMedia.Path,
                    Issue = trackedIssue,
                }
            );

            await _context.SaveChangesAsync();
        }
    }
}
