using Microsoft.AspNetCore.Mvc;
using TaskManagement.BLL.Interfaces;
using TaskManagement.MODELS.CreateProjectDTO;
using TaskManagement.MODELS.UpdateProjectDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectService.GetAllAsync();
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var project = await _projectService.GetByIdAsync(id);
            return Ok(project);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    [HttpGet("{id}/users")]
    public async Task<IActionResult> GetUserAsync(int id)
    {
        try
        {
            var users = await _projectService.GetUsersAsync(id);
            return Ok(users);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateProjectDTO dto)
    {
        try
        {
            var createdProject = await _projectService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdProject.Id }, createdProject);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("{projectId}/users/{userId}")]
    public async Task<IActionResult> AddUserAsync(int projectId, int userId)
    {
        try
        {
            await _projectService.AddUserAsync(projectId, userId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateProjectDTO dto)
    {
        try
        {
            var updatedProject = await _projectService.UpdateAsync(id, dto);
            return Ok(updatedProject);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _projectService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{projectId}/users/{userId}")]
    public async Task<IActionResult> RemoveUserAsync(int projectId, int userId)
    {
        try
        {
            await _projectService.RemoveUserAsync(projectId, userId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}



