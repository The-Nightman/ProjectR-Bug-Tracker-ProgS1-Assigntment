using ProjectR.Classes;
using ProjectR.DTOs;
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

        public async Task<ProjectDisplay?> GetProjectViewDetailsById(int projectId)
        {
            var projectDto = await _repository.GetProjectViewDetailsById(projectId);

            if (projectDto == null)
            {
                return null;
            }

            var projectDisplay = new ProjectDisplay(
                projectDto.ProjectId,
                projectDto.ProjectName,
                [
                    .. projectDto.Issues.Select(i => new IssueListItem(
                        i.IssueId,
                        i.IssueName,
                        i.ChangesCount,
                        i.Status,
                        i.Severity,
                        i.CreatedAt,
                        i.LastUpdated
                    )),
                ]
            );

            return projectDisplay;
        }

        public async Task AddNewProject(NewProjectDto newProject)
        {
            await _repository.AddNewProject(newProject);
        }
    }
}
