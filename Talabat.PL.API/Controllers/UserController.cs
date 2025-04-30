using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Application.Contracts.Interfaces;
using Talabat.Application.DTO.User;
using Talabat.Application.Repository.Interfaces;

namespace Talabat.PL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IuserService userService;

        public UserController(IuserService _userService)
        {
            userService = _userService;
        }

        [HttpGet("get/users")]
        public async Task<IActionResult> getAllUser()
        {
            // service.getAlluser();
            return Ok();
        }

        [HttpGet("get/user/{id}")]
        public async Task<IActionResult> getUserById(int userId)
        {
            // service.getAlluser(userId);
            return Ok();
        }

        [HttpPost("add/user")]
        public async Task<IActionResult> AddUser(CreateUserDTO user, IEnumerable<string>? roles)
        {
           var result = await userService.CreateUser(user, roles);
            return Ok(result);
        }

        [HttpPut("update/user/{id}")]
        // UserDTO dto
        public async Task<IActionResult> updateUser(int userId)
        {
            // service.updateuser(userId);
            return Ok();
        }

        [HttpDelete("user/{id}")]
        public async Task<IActionResult> deleteUser(int userId)
        {
            // service.deleteuser(userId);
            return Ok();
        }

    }
}
