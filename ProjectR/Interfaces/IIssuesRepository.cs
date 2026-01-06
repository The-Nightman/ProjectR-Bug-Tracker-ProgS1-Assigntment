using ProjectR.DTOs;

namespace ProjectR.Interfaces
{
    public interface IIssuesRepository
    {
        public Task AddNewIssue(int projectId, AddNewIssueDto newIssueDto);
    }
}
