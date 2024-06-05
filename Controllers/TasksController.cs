using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TaskManagementSystem.Api.DTOs;
using TaskManagementSystem.Api.Services;
using TaskModel = TaskManagementSystem.Api.Models.Task;

namespace TaskManagementSystem.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;
        private readonly ILogger<TasksController> _logger;

        public TasksController(TaskService taskService, ILogger<TasksController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        // Endpoint to get all tasks
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            _logger.LogInformation("Getting all tasks.");
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        // Endpoint to get a task by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            _logger.LogInformation("Getting task with ID {Id}.", id);
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
            {
                _logger.LogWarning("Task with ID {Id} not found.", id);
                return NotFound();
            }
            return Ok(task);
        }

        // Endpoint to create a new task
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskDto taskDto)
        {
            _logger.LogInformation("Creating a new task.");
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid task data provided.");
                return BadRequest(ModelState);
            }

            var task = new TaskModel
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                Status = taskDto.Status,
                UserId = taskDto.UserId
            };

            var createdTask = await _taskService.CreateTaskAsync(task);
            _logger.LogInformation("Task created with ID {Id}.", createdTask.Id);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        // Endpoint to update an existing task
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskDto taskDto)
        {
            _logger.LogInformation("Updating task with ID {Id}.", id);
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid task data provided.");
                return BadRequest(ModelState);
            }

            var task = new TaskModel
            {
                Id = id,
                Title = taskDto.Title,
                Description = taskDto.Description,
                Status = taskDto.Status,
                UserId = taskDto.UserId
            };

            await _taskService.UpdateTaskAsync(task);
            _logger.LogInformation("Task with ID {Id} updated.", id);
            return NoContent();
        }

        // Endpoint to delete a task by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            _logger.LogInformation("Deleting task with ID {Id}.", id);
            await _taskService.DeleteTaskAsync(id);
            _logger.LogInformation("Task with ID {Id} deleted.", id);
            return NoContent();
        }
    }
}
