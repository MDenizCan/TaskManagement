using Microsoft.AspNetCore.Mvc;
using TaskManagement.BLL.Interfaces;
using TaskManagement.MODELS.UserDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateUserDTO dto)
    {
        var createdUser = await _userService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = createdUser.Id }, createdUser);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateUserDTO dto)
    {
        var updatedUser = await _userService.UpdateAsync(id, dto);
        if (updatedUser == null)
        {
            return NotFound();
        }
        return Ok(updatedUser);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _userService.DeleteAsync(id);
        return NoContent();
    }
}
