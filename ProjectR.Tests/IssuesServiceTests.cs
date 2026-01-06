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

    }
}
