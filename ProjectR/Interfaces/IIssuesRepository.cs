using ProjectR.DTOs;

namespace ProjectR.Interfaces
{
    public interface IIssuesRepository
    {
        public Task AddNewIssue(int projectId, AddNewIssueDto newIssueDto);

        public Task<IssueDto> GetIssueById(int issueId);

        public Task<List<MediaDto>> GetIssueMedia(int issueId);
    }
}
