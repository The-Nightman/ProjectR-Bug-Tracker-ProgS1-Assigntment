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
        [Category("GraphData Service")]
        public async Task GetDashboardScatterGraphData_FetchesScatterGraphData_CollectionIsList()
        {
            // Arrange
            var dataList = new List<GraphData<DateTime>>
            {
                new(DateTime.Today.AddDays(-2), 5),
                new(DateTime.Today.AddDays(-1), 3),
                new(DateTime.Today, 7),
            };

            _mockRepository.GetDashboardScatterGraphData().Returns(Task.FromResult(dataList));

            // Act
            var result = await _service.GetDashboardScatterGraphData();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.TypeOf<List<GraphData<DateTime>>>());
                Assert.That(result, Has.Count.EqualTo(7));

                Assert.That(result[0].XSeries, Is.EqualTo(DateTime.Today.AddDays(-6)));
                Assert.That(result[0].Value, Is.EqualTo(0));
                Assert.That(result[1].XSeries, Is.EqualTo(DateTime.Today.AddDays(-5)));
                Assert.That(result[1].Value, Is.EqualTo(0));
                Assert.That(result[2].XSeries, Is.EqualTo(DateTime.Today.AddDays(-4)));
                Assert.That(result[2].Value, Is.EqualTo(0));
                Assert.That(result[3].XSeries, Is.EqualTo(DateTime.Today.AddDays(-3)));
                Assert.That(result[3].Value, Is.EqualTo(0));
                Assert.That(result[4].XSeries, Is.EqualTo(DateTime.Today.AddDays(-2)));
                Assert.That(result[4].Value, Is.EqualTo(5));
                Assert.That(result[5].XSeries, Is.EqualTo(DateTime.Today.AddDays(-1)));
                Assert.That(result[5].Value, Is.EqualTo(3));
                Assert.That(result[6].XSeries, Is.EqualTo(DateTime.Today));
                Assert.That(result[6].Value, Is.EqualTo(7));
            });
        }

        [Test]
        [Category("Unit")]
        [Category("GraphData Service")]
        public async Task GetDashboardScatterGraphData_WhenNoDataExists_ReturnsFullListWithZeroDatapointValues()
        {
            // Arrange
            var dataList = new List<GraphData<DateTime>>();

            _mockRepository.GetDashboardScatterGraphData().Returns(Task.FromResult(dataList));

            // Act
            var result = await _service.GetDashboardScatterGraphData();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.TypeOf<List<GraphData<DateTime>>>());
                Assert.That(result, Has.Count.EqualTo(7));

                Assert.That(result[0].XSeries, Is.EqualTo(DateTime.Today.AddDays(-6)));
                Assert.That(result[0].Value, Is.EqualTo(0));
                Assert.That(result[1].XSeries, Is.EqualTo(DateTime.Today.AddDays(-5)));
                Assert.That(result[1].Value, Is.EqualTo(0));
                Assert.That(result[2].XSeries, Is.EqualTo(DateTime.Today.AddDays(-4)));
                Assert.That(result[2].Value, Is.EqualTo(0));
                Assert.That(result[3].XSeries, Is.EqualTo(DateTime.Today.AddDays(-3)));
                Assert.That(result[3].Value, Is.EqualTo(0));
                Assert.That(result[4].XSeries, Is.EqualTo(DateTime.Today.AddDays(-2)));
                Assert.That(result[4].Value, Is.EqualTo(0));
                Assert.That(result[5].XSeries, Is.EqualTo(DateTime.Today.AddDays(-1)));
                Assert.That(result[5].Value, Is.EqualTo(0));
                Assert.That(result[6].XSeries, Is.EqualTo(DateTime.Today));
                Assert.That(result[6].Value, Is.EqualTo(0));
            });
        }

        [Test]
        [Category("Unit")]
        [Category("GraphData Service")]
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
        [Category("GraphData Service")]
        public async Task GetDashboardRadarGraphData_WhenRowWithColumnDoesNotExist_ReturnsColumnWithZero()
        {
            // Arrange
            var severity = new Dictionary<string, int> { ["Low"] = 5, ["Critical"] = 1 };

            var status = new Dictionary<string, int> { ["In Review"] = 3 };

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

        [Test]
        [Category("Unit")]
        [Category("GraphData Service")]
        public async Task GetDashboardBarGraphData_FetchesBarGraphData_CollectionIsList()
        {
            // Arrange
            var dataList = new List<GraphData<string>>
            {
                new("Project A", 5),
                new("Project B", 3),
                new("Project C", 7),
            };

            _mockRepository.GetDashboardBarGraphData().Returns(Task.FromResult(dataList));

            // Act
            var result = await _service.GetDashboardBarGraphData();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.TypeOf<List<GraphData<string>>>());
                Assert.That(result, Has.Count.EqualTo(3));

                Assert.That(result[0].XSeries, Is.EqualTo("Project A"));
                Assert.That(result[0].Value, Is.EqualTo(5));
                Assert.That(result[1].XSeries, Is.EqualTo("Project B"));
                Assert.That(result[1].Value, Is.EqualTo(3));
                Assert.That(result[2].XSeries, Is.EqualTo("Project C"));
                Assert.That(result[2].Value, Is.EqualTo(7));
            });
        }

        [Test]
        [Category("Unit")]
        [Category("GraphData Service")]
        public async Task GetDashboardBarGraphData_WhenNoDataExists_ReturnsEmptyList()
        {
            // Arrange
            var dataList = new List<GraphData<string>>();

            _mockRepository.GetDashboardBarGraphData().Returns(Task.FromResult(dataList));

            // Act
            var result = await _service.GetDashboardBarGraphData();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.TypeOf<List<GraphData<string>>>());
                Assert.That(result, Has.Count.EqualTo(0));
            });
        }

        [Test]
        [Category("Unit")]
        [Category("GraphData Service")]
        public async Task GetProjectOpenIssuesGraphData_FetchesBarGraphData_CollectionIsList()
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
                ["Investigating"] = 6,
                ["In Review"] = 3,
                ["Fixed"] = 12,
            };

            _mockRepository
                .GetProjectCurrentOpenIssuesBarGraphData(1)
                .Returns(Task.FromResult((severity, status)));

            // Act

            var result = await _service.GetProjectCurrentOpenIssuesBarGraphData(1);

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
                Assert.That(result[3].Value, Is.EqualTo(6));
                Assert.That(result[4].XSeries, Is.EqualTo("In Review"));
                Assert.That(result[4].Value, Is.EqualTo(3));
                Assert.That(result[5].XSeries, Is.EqualTo("Fixed"));
                Assert.That(result[5].Value, Is.EqualTo(12));
            });
        }

        [Test]
        [Category("Unit")]
        [Category("GraphData Service")]
        public async Task GetProjectOpenIssuesGraphData_WhenRowWithColumnDoesNotExist_ReturnsColumnWithZero()
        {
            // Arrange
            var severity = new Dictionary<string, int> { ["Low"] = 5, ["Critical"] = 1 };

            var status = new Dictionary<string, int> { ["In Review"] = 3 };

            _mockRepository
                .GetProjectCurrentOpenIssuesBarGraphData(1)
                .Returns(Task.FromResult((severity, status)));

            // Act
            var result = await _service.GetProjectCurrentOpenIssuesBarGraphData(1);

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
