using ProjectR.DTOs;

namespace ProjectR.Interfaces
{
    public interface IProjectsRepository
    {
        public Task<List<ProjectPreviewDto>> GetProjectPreviews();

        public Task<ProjectDisplayDto?> GetProjectViewDetailsById(int projectId);

        public Task AddNewProject(NewProjectDto newProject);
    }
}
