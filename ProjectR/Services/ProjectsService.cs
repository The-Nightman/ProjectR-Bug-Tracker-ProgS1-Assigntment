using ProjectR.Classes;
using ProjectR.Interfaces;

namespace ProjectR.Services
{
    public class ProjectsService(IProjectsRepository repository) : IProjectsService
    {
        private readonly IProjectsRepository _repository = repository;

        public async Task<List<ProjectPreview>> GetProjectPreviews()
        {
            var projectPreviewDtos = await _repository.GetProjectPreviews();
            var projectPreviews = projectPreviewDtos
                .Select(dto => new ProjectPreview(
                    dto.ProjectId,
                    dto.ProjectName,
                    dto.OpenIssues,
                    dto.CriticalIssues,
                    dto.ThisWeekIssues,
                    dto.LastUpdated
                ))
                .ToList();

            return projectPreviews;
        }
    }
}
