using NSubstitute;
using ProjectR.DTOs;
using ProjectR.Interfaces;
using ProjectR.Services;

namespace ProjectR.Tests
{
    [TestFixture]
    public class IssuesServiceTests
    {
        private IIssuesRepository _mockRepository = null!;
        private IssuesService _service = null!;

        [SetUp]
        public void Setup()
        {
            _mockRepository = Substitute.For<IIssuesRepository>();
            _service = new IssuesService(_mockRepository);
        }

        [Test]
        [Category("Unit")]
        [Category("Issues Service")]
        public async Task AddNewIssue_CallsRepositoryWithCorrectParameters()
        {
            // Arrange
            int projectId = 1;
            var newIssueDto = new AddNewIssueDto
            {
                ProjectId = projectId,
                Name = "New Issue",
                Description = "Issue Description",
                Severity = "High",
                Status = "Open",
                CreatedAt = DateTime.UtcNow,
            };

            // Act
            await _service.AddNewIssue(projectId, newIssueDto);

            // Assert
            await _mockRepository.Received(1).AddNewIssue(projectId, newIssueDto);
        }

        [Test]
        [Category("Unit")]
        [Category("Issues Service")]
        public async Task GetIssueById_ReturnsCorrectIssueDisplay()
        {
            // Arrange
            int issueId = 1;
            var issueDto = new IssueDto
            {
                Id = issueId,
                Name = "Test Issue",
                Description = "Test Description",
                Severity = "Medium",
                Status = "In Progress",
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                LastUpdated = DateTime.UtcNow,
                Changes = [],
                Media = [],
                ProjectId = 2,
            };

            _mockRepository.GetIssueById(issueId).Returns(Task.FromResult(issueDto));

            // Act
            var result = await _service.GetIssueById(issueId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.IssueId, Is.EqualTo(issueDto.Id));
                Assert.That(result.Name, Is.EqualTo(issueDto.Name));
                Assert.That(result.Description, Is.EqualTo(issueDto.Description));
                Assert.That(result.Severity, Is.EqualTo(issueDto.Severity));
                Assert.That(result.Status, Is.EqualTo(issueDto.Status));
                Assert.That(result.CreatedAt, Is.EqualTo(issueDto.CreatedAt));
                Assert.That(result.LastUpdated, Is.EqualTo(issueDto.LastUpdated));
                Assert.That(result.ChangesList, Has.Count.EqualTo(issueDto.Changes.Count));
                Assert.That(result.MediaList, Has.Count.EqualTo(issueDto.Media.Count));
                Assert.That(result.ProjectId, Is.EqualTo(issueDto.ProjectId));
            });
        }
    }
}
