using ProjectR.Classes;
using ProjectR.DTOs;

namespace ProjectR.Interfaces
{
    public interface IIssuesService
    {
        public Task AddNewIssue(int projectId, AddNewIssueDto newIssueDto);

        public Task<IssueDisplay> GetIssueById(int issueId);

        public Task UpdateIssueDetails(int issueId, EditIssueDetailsDto editIssueDetailsDto);

        public Task<List<MediaDisplay>> GetIssueMedia(int issueId);

        public Task AddNewMedia(int issueId, NewMediaDto newMedia);

        public Task UpdateMedia(EditMediaDto editMedia);

        public Task DeleteMediaById(int mediaId);

        public Task<ChangeDisplay> GetChangeById(int changeId);

        public Task AddNewChange(int issueId, NewChangeDto newChange);

        public Task UpdateChange(EditChangeDto editChange);
    }
}
