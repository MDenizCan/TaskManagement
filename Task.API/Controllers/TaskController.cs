using Microsoft.AspNetCore.Mvc;
using TaskManagement.BLL.Interfaces;
using TaskManagement.MODELS.TaskDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.API.Controllers;

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
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var task = await _taskService.GetByIdAsync(id);
        if (task == null)
            return NotFound();
        return Ok(task);
    }

    [HttpGet]
    [Route("project/{projectId}")]
    public async Task<IActionResult> GetByProjectAsync(int projectId)
    {
        var tasks = await _taskService.GetByProjectAsync(projectId);
        return Ok(tasks);
    }

    [HttpPost]
    [Route("project/{projectId}")]
    public async Task<IActionResult> CreateAsync(int projectId, CreateTaskDTO dto)
    {
        var project = await _projectService.GetByIdAsync(projectId);
        if (project == null)
            return NotFound($"Project with not found.");
        try
        {
            return CreatedAtAction(nameof(GetByIdAsync), new { id = await _taskService.CreateAsync(projectId, dto) }, null);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("{taskId}/assign/{userId}")]
    public async Task<IActionResult> AssignUserAsync(int taskId, int userId)
    {
        try
        {
            var task = await _taskService.AssignUserAsync(taskId, userId);
            return Ok(task);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateTaskDTO dto)
    {
        try
        {
            var updatedTask = await _taskService.UpdateAsync(id, dto);
            return Ok(updatedTask);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            await _taskService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}