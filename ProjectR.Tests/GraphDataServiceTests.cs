using NSubstitute;
using ProjectR.Classes;
using ProjectR.Interfaces;
using ProjectR.Services;

namespace ProjectR.Tests
{
    [TestFixture]
    public class GraphDataServiceTests
    {
        private IGraphDataRepository _mockRepository = null!;
        private GraphDataService _service = null!;

        [SetUp]
        public void Setup()
        {
            _mockRepository = Substitute.For<IGraphDataRepository>();
            _service = new GraphDataService(_mockRepository);
        }

        [Test]
        [Category("Unit")]
        [Category("Projects Service")]
        public async Task GetDashboardRadarGraphData_FetchesRadarGraphData_CollectionIsList()
        {
            // Arrange
            var severity = new Dictionary<string, int>
            {
                ["Low"] = 5,
                ["Medium"] = 3,
                ["Critical"] = 1,
            };

            var status = new Dictionary<string, int>
            {
                ["Investigating"] = 4,
                ["In Review"] = 3,
                ["Fixed"] = 2,
            };

            _mockRepository
                .GetDashboardRadarGraphData()
                .Returns(Task.FromResult((severity, status)));

            // Act
            var result = await _service.GetDashboardRadarGraphData();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.TypeOf<List<GraphData<string>>>());
                Assert.That(result, Has.Count.EqualTo(6));
                Assert.That(result[0].XSeries, Is.EqualTo("Low"));
                Assert.That(result[0].Value, Is.EqualTo(5));
                Assert.That(result[1].XSeries, Is.EqualTo("Medium"));
                Assert.That(result[1].Value, Is.EqualTo(3));
                Assert.That(result[2].XSeries, Is.EqualTo("Critical"));
                Assert.That(result[2].Value, Is.EqualTo(1));
                Assert.That(result[3].XSeries, Is.EqualTo("Investigating"));
                Assert.That(result[3].Value, Is.EqualTo(4));
                Assert.That(result[4].XSeries, Is.EqualTo("In Review"));
                Assert.That(result[4].Value, Is.EqualTo(3));
                Assert.That(result[5].XSeries, Is.EqualTo("Fixed"));
                Assert.That(result[5].Value, Is.EqualTo(2));
            });
        }

        [Test]
        [Category("Unit")]
        [Category("Projects Service")]
        public async Task GetDashboardRadarGraphData_WhenRowWithColumnDoesNotExist_ReturnsColumnWithZero()
        {
            // Arrange
            var severity = new Dictionary<string, int>
            {
                ["Low"] = 5,
                ["Critical"] = 1,
            };

            var status = new Dictionary<string, int>
            {
                ["In Review"] = 3,
            };

            _mockRepository
                .GetDashboardRadarGraphData()
                .Returns(Task.FromResult((severity, status)));

            // Act
            var result = await _service.GetDashboardRadarGraphData();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.TypeOf<List<GraphData<string>>>());
                Assert.That(result, Has.Count.EqualTo(6));
                Assert.That(result[0].XSeries, Is.EqualTo("Low"));
                Assert.That(result[0].Value, Is.EqualTo(5));
                Assert.That(result[1].XSeries, Is.EqualTo("Medium"));
                Assert.That(result[1].Value, Is.EqualTo(0));
                Assert.That(result[2].XSeries, Is.EqualTo("Critical"));
                Assert.That(result[2].Value, Is.EqualTo(1));
                Assert.That(result[3].XSeries, Is.EqualTo("Investigating"));
                Assert.That(result[3].Value, Is.EqualTo(0));
                Assert.That(result[4].XSeries, Is.EqualTo("In Review"));
                Assert.That(result[4].Value, Is.EqualTo(3));
                Assert.That(result[5].XSeries, Is.EqualTo("Fixed"));
                Assert.That(result[5].Value, Is.EqualTo(0));
            });
        }
    }
}
