using NSubstitute;
using ProjectR.Classes;
using ProjectR.DTOs;
using ProjectR.Interfaces;
using ProjectR.Services;

namespace ProjectR.Tests
{
    [TestFixture]
    public class ProjectsServiceTests
    {
        private IProjectsRepository _mockRepository = null!;
        private ProjectsService _service = null!;

        [SetUp]
        public void Setup()
        {
            _mockRepository = Substitute.For<IProjectsRepository>();
            _service = new ProjectsService(_mockRepository);
        }

        [Test]
        [Category("Unit")]
        [Category("Projects Service")]
        public async Task GetProjectPreviews_FetchesProjectPreview_MapsDtosToProjectPreview()
        {
            // Arrange
            var dto = new ProjectPreviewDto
            {
                ProjectId = 1,
                ProjectName = "Test Project",
                OpenIssues = 3,
                CriticalIssues = 1,
                ThisWeekIssues = 2,
                LastUpdated = DateTime.Today,
            };

            _mockRepository
                .GetProjectPreviews()
                .Returns(Task.FromResult(new List<ProjectPreviewDto> { dto }));

            // Act
            var result = await _service.GetProjectPreviews();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(1));

            var preview = result[0];

            Assert.Multiple(() =>
            {
                Assert.That(preview.ProjectId, Is.EqualTo(dto.ProjectId));
                Assert.That(preview.ProjectName, Is.EqualTo(dto.ProjectName));
                Assert.That(preview.OpenIssues, Is.EqualTo(dto.OpenIssues));
                Assert.That(preview.CriticalIssues, Is.EqualTo(dto.CriticalIssues));
                Assert.That(preview.ThisWeekIssues, Is.EqualTo(dto.ThisWeekIssues));
                Assert.That(preview.LastUpdated, Is.EqualTo(dto.LastUpdated));
            });
        }

        [Test]
        [Category("Unit")]
        [Category("Projects Service")]
        public async Task GetProjectPreviews_WhenRepositoryReturnsEmpty_ReturnsEmptyList()
        {
            // Arrange
            _mockRepository
                .GetProjectPreviews()
                .Returns(Task.FromResult(new List<ProjectPreviewDto>()));

            // Act
            var result = await _service.GetProjectPreviews();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Empty);
        }

        [Test]
        [Category("Unit")]
        [Category("Projects Service")]
        public async Task GetProjectViewDetailsById_WhenProjectExists_MapsDtoToProjectDisplayAndIssueListItem()
        {
            // Arrange
            int projectId = 1;
            var dto = new ProjectDisplayDto
            {
                ProjectId = projectId,
                ProjectName = "Test Project",
                Issues =
                [
                    new IssuePreviewDto
                    {
                        IssueId = 101,
                        IssueName = "Test Issue",
                        ChangesCount = 5,
                        Status = "Open",
                        Severity = "High",
                        CreatedAt = DateTime.Today.AddDays(-10),
                        LastUpdated = DateTime.Today,
                    },
                ],
            };

            _mockRepository
                .GetProjectViewDetailsById(projectId)
                .Returns(Task.FromResult<ProjectDisplayDto?>(dto));

            // Act
            var result = await _service.GetProjectViewDetailsById(projectId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Is.TypeOf<ProjectDisplay?>());

                Assert.That(result!.ProjectId, Is.EqualTo(dto.ProjectId));
                Assert.That(result.ProjectName, Is.EqualTo(dto.ProjectName));

                Assert.That(result.Issues, Has.Count.EqualTo(dto.Issues.Count));
                Assert.That(result.Issues, Is.TypeOf<List<IssueListItem>>());
            });
        }

        [Test]
        [Category("Unit")]
        [Category("Projects Service")]
        public async Task GetProjectViewDetailsById_WhenProjectDoesNotExist_ReturnsNull()
        {
            // Arrange
            int projectId = 999;

            _mockRepository
                .GetProjectViewDetailsById(projectId)
                .Returns(Task.FromResult<ProjectDisplayDto?>(null));

            // Act
            var result = await _service.GetProjectViewDetailsById(projectId);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        [Category("Unit")]
        [Category("Projects Service")]
        public async Task AddNewProject_CallsRepositoryWithNewParameters()
        {
            // Arrange
            var newProjectDto = new NewProjectDto { Name = "New Test Project", CreatedAt = DateTime.Now };

            // Act
            await _service.AddNewProject(newProjectDto);

            // Assert
            await _mockRepository.Received(1).AddNewProject(newProjectDto);
        }
    }
}
