using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Application.Contracts.Interfaces;
using Talabat.Application.DTO.Auth;

namespace Talabat.PL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService userService)
        {
            _authService = userService;
        }
        [HttpPost("register")]
     
        public async Task<IActionResult> Register(UserRegisterRequest userDto)
        {
            var user = await _authService.RegisterAsync(userDto);
            return Ok(user);
        }

        [HttpPost("login")]

        public async Task<IActionResult> login(UserLoginRequest userDto)
        {
            var user = await _authService.LoginAsync(userDto);
            return Ok(user);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> logout()
        {
            // service.logout
            return Ok();
        }
    }
}
