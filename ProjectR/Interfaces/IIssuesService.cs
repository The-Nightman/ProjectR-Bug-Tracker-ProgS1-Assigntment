using ProjectR.Classes;
using ProjectR.DTOs;

namespace ProjectR.Interfaces
{
    public interface IIssuesService
    {
        public Task AddNewIssue(int projectId, AddNewIssueDto newIssueDto);

        public Task<IssueDisplay> GetIssueById(int issueId);

        public Task<List<MediaDisplay>> GetIssueMedia(int issueId);
    }
}
