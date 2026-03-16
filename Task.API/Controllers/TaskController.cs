using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.BLL.Interfaces;
using TaskManagement.MODELS.TaskDTO;

namespace TaskManagement.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;
    private readonly IProjectService _projectService;

    public TaskController(ITaskService taskService, IProjectService projectService)
    {
        _taskService = taskService;
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var tasks = await _taskService.GetAllAsync();
        return Ok(tasks);
    }

    [HttpGet("{id}", Name = "GetTaskById")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var task = await _taskService.GetByIdAsync(id);
        return Ok(task);
    }

    [HttpGet("project/{projectId}/tasks")]
    public async Task<IActionResult> GetByProjectAsync(int projectId)
    {
        var tasks = await _taskService.GetByProjectAsync(projectId);
        return Ok(tasks);
    }

    [HttpPost("project/{projectId}/createTask")]
    public async Task<IActionResult> CreateAsync(int projectId, CreateTaskDTO dto)
    {
        var createdTask = await _taskService.CreateAsync(projectId, dto);
        return CreatedAtRoute("GetTaskById", new { id = createdTask.Id }, createdTask);
    }

    [HttpPost("{taskId}/assign/{userId}")]
    public async Task<IActionResult> AssignUserAsync(int taskId, int userId)
    {
        var task = await _taskService.AssignUserAsync(taskId, userId);
        return Ok(task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateTaskDTO dto)
    {
        var updatedTask = await _taskService.UpdateAsync(id, dto);
        return Ok(updatedTask);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _taskService.DeleteAsync(id);
        return NoContent();
    }
}