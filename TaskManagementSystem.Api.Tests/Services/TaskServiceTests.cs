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
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            var context = new ApplicationDbContext(options);
            _mockTaskRepository = new Mock<TaskRepository>(context);
            _mockLogger = new Mock<ILogger<TaskService>>();
            _taskService = new TaskService(_mockTaskRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllTasksAsync_ReturnsAllTasks()
        {
            var tasks = new List<TaskModel>
            {
                new TaskModel { Id = 1, Title = "Test Task 1" },
                new TaskModel { Id = 2, Title = "Test Task 2" }
            };
            _mockTaskRepository.Setup(repo => repo.GetAllTasksAsync()).ReturnsAsync(tasks);

            var result = await _taskService.GetAllTasksAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetTaskByIdAsync_ExistingId_ReturnsTask()
        {
            var task = new TaskModel { Id = 1, Title = "Test Task 1" };
            _mockTaskRepository.Setup(repo => repo.GetTaskByIdAsync(1)).ReturnsAsync(task);

            var result = await _taskService.GetTaskByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task CreateTaskAsync_ValidTask_CreatesTask()
        {
            var task = new TaskModel { Id = 1, Title = "Test Task 1" };

            var result = await _taskService.CreateTaskAsync(task);

            _mockTaskRepository.Verify(repo => repo.AddTaskAsync(task), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }
    }
}