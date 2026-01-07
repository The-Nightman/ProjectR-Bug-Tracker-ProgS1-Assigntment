using ProjectR.Classes;
using ProjectR.DTOs;

namespace ProjectR.Interfaces
{
    public interface IProjectsService
    {
        Task<List<ProjectPreview>> GetProjectPreviews();

        public Task<ProjectDisplay?> GetProjectViewDetailsById(int projectId);

        public Task AddNewProject(NewProjectDto newProject);
    }
}
