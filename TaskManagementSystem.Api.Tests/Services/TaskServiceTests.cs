using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Api.Repositories;
using TaskManagementSystem.Api.Services;
using Xunit;
using TaskModel = TaskManagementSystem.Api.Models.Task;
using TaskManagementSystem.Api.Data;

namespace TaskManagementSystem.Api.Tests.Services
{
    public class TaskServiceTests
    {
        private readonly TaskService _taskService;
        private readonly Mock<TaskRepository> _mockTaskRepository;
        private readonly Mock<ILogger<TaskService>> _mockLogger;

        public TaskServiceTests()
        {
            // Setting up in-memory database for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            var context = new ApplicationDbContext(options);

            // Mocking TaskRepository and ILogger for TaskService
            _mockTaskRepository = new Mock<TaskRepository>(context);
            _mockLogger = new Mock<ILogger<TaskService>>();

            // Initializing TaskService with mocked dependencies
            _taskService = new TaskService(_mockTaskRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllTasksAsync_ReturnsAllTasks()
        {
            // Arrange: Setting up mock data and repository behavior
            var tasks = new List<TaskModel>
            {
                new TaskModel { Id = 1, Title = "Test Task 1" },
                new TaskModel { Id = 2, Title = "Test Task 2" }
            };
            _mockTaskRepository.Setup(repo => repo.GetAllTasksAsync()).ReturnsAsync(tasks);

            // Act: Calling the method to be tested
            var result = await _taskService.GetAllTasksAsync();

            // Assert: Verifying the results
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetTaskByIdAsync_ExistingId_ReturnsTask()
        {
            // Arrange: Setting up mock data and repository behavior
            var task = new TaskModel { Id = 1, Title = "Test Task 1" };
            _mockTaskRepository.Setup(repo => repo.GetTaskByIdAsync(1)).ReturnsAsync(task);

            // Act: Calling the method to be tested
            var result = await _taskService.GetTaskByIdAsync(1);

            // Assert: Verifying the results
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task CreateTaskAsync_ValidTask_CreatesTask()
        {
            // Arrange: Setting up mock data
            var task = new TaskModel { Id = 1, Title = "Test Task 1" };

            // Act: Calling the method to be tested
            var result = await _taskService.CreateTaskAsync(task);

            // Assert: Verifying the results and repository interaction
            _mockTaskRepository.Verify(repo => repo.AddTaskAsync(task), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }
    }
}