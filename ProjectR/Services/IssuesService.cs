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
    }
}
