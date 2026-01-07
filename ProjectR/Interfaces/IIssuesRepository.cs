using ProjectR.DTOs;

namespace ProjectR.Interfaces
{
    public interface IIssuesRepository
    {
        public Task AddNewIssue(int projectId, AddNewIssueDto newIssueDto);

        public Task<IssueDto> GetIssueById(int issueId);

        public Task UpdateIssueDetails(int issueId, EditIssueDetailsDto editIssueDetailsDto);

        public Task<List<MediaDto>> GetIssueMedia(int issueId);

        public Task AddNewMedia(int projectId, NewMediaDto mediaDto);

        public Task UpdateMedia(EditMediaDto editMedia);

        public Task DeleteMediaById(int mediaId);

        public Task<ChangeDto> GetChangeById(int changeId);

        public Task AddNewChange(int issueId, NewChangeDto newChange);
    }
}
