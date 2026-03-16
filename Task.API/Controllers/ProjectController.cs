using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.BLL.Interfaces;
using TaskManagement.MODELS.CreateProjectDTO;
using TaskManagement.MODELS.UpdateProjectDTO;

namespace TaskManagement.API.Controllers;

[Authorize]
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
        var project = await _projectService.GetByIdAsync(id);
        return Ok(project);
    }

    [HttpGet("{id}/users")]
    public async Task<IActionResult> GetUserAsync(int id)
    {
        var users = await _projectService.GetUsersAsync(id);
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProjectDTO dto)
    {
        var createdProject = await _projectService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = createdProject.Id }, createdProject);
    }

    [HttpPost("{projectId}/users/{userId}")]
    public async Task<IActionResult> AddUserAsync(int projectId, int userId)
    {
        await _projectService.AddUserAsync(projectId, userId);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateProjectDTO dto)
    {
        var updatedProject = await _projectService.UpdateAsync(id, dto);
        return Ok(updatedProject);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _projectService.DeleteAsync(id);
        return NoContent();
    }

    [HttpDelete("{projectId}/users/{userId}")]
    public async Task<IActionResult> RemoveUserAsync(int projectId, int userId)
    {
        await _projectService.RemoveUserAsync(projectId, userId);
        return NoContent();
    }
}
