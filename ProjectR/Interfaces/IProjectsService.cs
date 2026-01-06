using ProjectR.Classes;

namespace ProjectR.Interfaces
{
    public interface IProjectsService
    {
        Task<List<ProjectPreview>> GetProjectPreviews();

        public Task<ProjectDisplay?> GetProjectViewDetailsById(int projectId);
    }
}
