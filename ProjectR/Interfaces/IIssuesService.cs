using ProjectR.DTOs;

namespace ProjectR.Interfaces
{
    public interface IIssuesService
    {
        public Task AddNewIssue(int projectId, AddNewIssueDto newIssueDto);
    }
}
