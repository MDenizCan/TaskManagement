using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManagement.ENTITIES.Entities;
using TaskManagement.MODELS.UserDTO;
using AutoMapper;

namespace TaskManagement.API.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IMapper _mapper;

    public AccountController(UserManager<UserEntity> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }


    [HttpPost]
    public async Task<ActionResult> CreateAccount([FromBody] CreateUserDTO dto)

    {
        var userEntity = _mapper.Map<UserEntity>(dto);
        var createdUser = await _userManager.CreateAsync(userEntity, dto.Password);

        // TODO: Handle Result (IdentityResult) properly later, for now just returning Ok
        if (createdUser.Succeeded)
        {
            return Ok(userEntity); 
        }
        
        return BadRequest(createdUser.Errors);
    }

    [HttpPost]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Logout()
    {
        return View();
    }
    [HttpGet]
    public IActionResult GetCurrentUser()
    {
        return View();
    }
}
