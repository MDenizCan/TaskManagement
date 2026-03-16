using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.BLL.Interfaces;
using TaskManagement.MODELS.UserDTO;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public AuthController(IAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            if (await _authService.UserExistsAsync(userRegisterDto.Email))
            {
                return BadRequest("User with this email already exists.");
            }

            var user = await _authService.RegisterAsync(userRegisterDto, userRegisterDto.Password);
            
            if (user == null)
            {
                return BadRequest("Could not register user.");
            }

            return Ok(new { message = "User registered successfully!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var user = await _authService.LoginAsync(userLoginDto.Email, userLoginDto.Password);

            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            var token = _tokenService.CreateToken(user);

            return Ok(new { token });
        }
    }
}
