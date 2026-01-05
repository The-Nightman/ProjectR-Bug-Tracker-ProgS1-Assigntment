using ProjectR.DTOs;

namespace ProjectR.Interfaces
{
    public interface IProjectsRepository
    {
        public Task<List<ProjectPreviewDto>> GetProjectPreviews();
    }
}
