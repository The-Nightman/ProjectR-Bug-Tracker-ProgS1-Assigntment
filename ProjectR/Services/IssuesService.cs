using ProjectR.Classes;
using ProjectR.Interfaces;

namespace ProjectR.Services
{
    public class IssuesService(IIssuesRepository repository) : IIssuesService
    {
        private readonly IIssuesRepository _repository = repository;

        public async Task AddNewIssue(int projectId, DTOs.AddNewIssueDto newIssueDto)
        {
            await _repository.AddNewIssue(projectId, newIssueDto);
        }

        public async Task<IssueDisplay> GetIssueById(int issueId)
        {
            var issueQuery = await _repository.GetIssueById(issueId);

            return new IssueDisplay(
                issueQuery.Id,
                issueQuery.Name,
                issueQuery.Description,
                issueQuery.Severity,
                issueQuery.Status,
                issueQuery.CreatedAt,
                issueQuery.LastUpdated,
                [
                    .. issueQuery.Changes.Select(c => new ChangeDisplay(
                        c.Id,
                        c.ChangeHash,
                        c.Name,
                        c.Description,
                        c.CreatedAt,
                        c.IssueId
                    )),
                ],
                [
                    .. issueQuery.Media.Select(m => new MediaDisplay(
                        m.Id,
                        m.Title,
                        m.Description,
                        m.Path,
                        m.IssueId
                    )),
                ],
                issueQuery.ProjectId
            );
        }

        public async Task<List<MediaDisplay>> GetIssueMedia(int issueId)
        {
            var mediaDtos = await _repository.GetIssueMedia(issueId);

            return [.. mediaDtos.Select(m => new MediaDisplay(m.Id, m.Title, m.Description, m.Path, m.IssueId))];
        }
    }
}
