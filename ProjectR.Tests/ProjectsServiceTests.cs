using NSubstitute;
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
    }
}
