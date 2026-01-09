using NSubstitute;
using ProjectR.Classes;
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

        [Test]
        [Category("Unit")]
        [Category("Issues Service")]
        public async Task GetIssueMedia_ReturnsCorrectMediaList()
        {
            // Arrange
            int issueId = 1;
            var mediaDtos = new List<MediaDto>
            {
                new()
                {
                    Id = 1,
                    Title = "Media 1",
                    Description = "Desc 1",
                    Path = "/path/1",
                    IssueId = issueId,
                },
                new()
                {
                    Id = 2,
                    Title = "Media 2",
                    Description = "Desc 2",
                    Path = "/path/2",
                    IssueId = issueId,
                },
            };

            _mockRepository.GetIssueMedia(issueId).Returns(Task.FromResult(mediaDtos));

            // Act
            var result = await _service.GetIssueMedia(issueId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Has.Count.EqualTo(mediaDtos.Count));
                Assert.That(result, Is.TypeOf<List<MediaDisplay>>());

                Assert.That(result[0].MediaId, Is.EqualTo(mediaDtos[0].Id));
                Assert.That(result[0].Title, Is.EqualTo(mediaDtos[0].Title));
                Assert.That(result[0].Description, Is.EqualTo(mediaDtos[0].Description));
                Assert.That(result[0].Path, Is.EqualTo(mediaDtos[0].Path));
                Assert.That(result[0].IssueId, Is.EqualTo(mediaDtos[0].IssueId));
                Assert.That(result[1].MediaId, Is.EqualTo(mediaDtos[1].Id));
                Assert.That(result[1].Title, Is.EqualTo(mediaDtos[1].Title));
                Assert.That(result[1].Description, Is.EqualTo(mediaDtos[1].Description));
                Assert.That(result[1].Path, Is.EqualTo(mediaDtos[1].Path));
                Assert.That(result[1].IssueId, Is.EqualTo(mediaDtos[1].IssueId));
            });
        }

        [Test]
        [Category("Unit")]
        [Category("Issues Service")]
        public async Task AddNewMedia_CallsRepositoryWithCorrectParameters()
        {
            // Arrange
            int projectId = 1;

            var newMediaDto = new NewMediaDto
            {
                Title = "New Media",
                Description = "Media Description",
                Path = "/path/to/media",
            };

            // Act
            await _service.AddNewMedia(projectId, newMediaDto);

            // Assert
            await _mockRepository.Received(1).AddNewMedia(projectId, newMediaDto);
        }

        [Test]
        [Category("Unit")]
        [Category("Issues Service")]
        public async Task UpdateIssueDetails_CallsRepositoryWithCorrectParameters()
        {
            // Arrange
            int issueId = 1;
            var editIssueDto = new EditIssueDetailsDto
            {
                Name = "Updated Issue Name",
                Description = "Updated Description",
                Severity = "Low",
                Status = "Closed",
            };

            // Act
            await _service.UpdateIssueDetails(issueId, editIssueDto);

            // Assert
            await _mockRepository.Received(1).UpdateIssueDetails(issueId, editIssueDto);
        }

        [Test]
        [Category("Unit")]
        [Category("Issues Service")]
        public async Task UpdateMedia_CallsRepositoryWithCorrectParameters()
        {
            // Arrange
            var editMediaDto = new EditMediaDto
            {
                Id = 1,
                Title = "test title",
                Description = "test desc",
            };

            // Act
            await _service.UpdateMedia(editMediaDto);

            // Assert
            await _mockRepository.Received(1).UpdateMedia(editMediaDto);
        }

        [Test]
        [Category("Unit")]
        [Category("Issues Service")]
        public async Task DeleteMediaById_CallsRepositoryWithCorrectParameters()
        {
            // Arrange
            int mediaId = 1;

            // Act
            await _service.DeleteMediaById(mediaId);

            // Assert
            await _mockRepository.Received(1).DeleteMediaById(mediaId);
        }

        [Test]
        [Category("Unit")]
        [Category("Issues Service")]
        public async Task GetChangeById_ReturnsCorrectChangeDisplay()
        {
            // Arrange
            int changeId = 1;
            var changeDto = new ChangeDto
            {
                Id = changeId,
                ChangeHash = "abc123",
                Name = "Test Change",
                Description = "Test Desc",
                CreatedAt = DateTime.Now,
                IssueId = changeId,
            };

            _mockRepository.GetChangeById(changeId).Returns(Task.FromResult(changeDto));

            // Act
            var result = await _service.GetChangeById(changeId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.TypeOf<ChangeDisplay>());

                Assert.That(result.ChangeId, Is.EqualTo(changeId));
                Assert.That(result.ChangeHash, Is.EqualTo(changeDto.ChangeHash));
                Assert.That(result.Name, Is.EqualTo(changeDto.Name));
                Assert.That(result.Description, Is.EqualTo(changeDto.Description));
                Assert.That(result.CreatedAt, Is.EqualTo(changeDto.CreatedAt));
                Assert.That(result.IssueId, Is.EqualTo(changeDto.IssueId));
            });
        }

        [Test]
        [Category("Unit")]
        [Category("Issues Service")]
        public async Task AddNewChange_CallsRepositoryWithCorrectParameters()
        {
            // Arrange
            int issueId = 1;
            var newChangeDto = new NewChangeDto
            {
                ChangeHash = "abc123",
                Name = "New Change",
                Description = "Change Description",
                CreatedAt = DateTime.UtcNow,
            };

            // Act
            await _service.AddNewChange(issueId, newChangeDto);

            // Assert
            await _mockRepository.Received(1).AddNewChange(issueId, newChangeDto);
        }

        [Test]
        [Category("Unit")]
        [Category("Issues Service")]
        public async Task UpdateChange_CallsRepositoryWithCorrectParameters()
        {
            // Arrange
            var editChangeDto = new EditChangeDto
            {
                Id = 1,
                ChangeHash = "abc123",
                Name = "New Change",
                Description = "Change Description",
                CreatedAt = DateTime.UtcNow,
            };

            // Act
            await _service.UpdateChange(editChangeDto);

            // Assert
            await _mockRepository.Received(1).UpdateChange(editChangeDto);
        }
    }
}
