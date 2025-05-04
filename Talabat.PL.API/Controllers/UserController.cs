using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
            var users = await userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("get/user/{id}")]
        public async Task<IActionResult> getUserById(string userId)
        {
            var user = await userService.userById(userId);
            return Ok(user);
        }

        [HttpPost("add/user")]
        public async Task<IActionResult> AddUser([FromBody] CreateUserDTO user)
        {
           var result = await userService.CreateUser(user);
            return Ok(result);
        }

        [HttpDelete("remove/role/{id}/{rolename}")]
        public async Task<IActionResult> RemoveUserRole([FromRoute]string id, string roleName)
        {
            var result = await userService.RemoveRoleFromUser(id, roleName);
            return Ok(result);
        }

        [HttpPut("update/user")]
        // UserDTO dto
        public async Task<IActionResult> updateUser([FromQuery]string userId , UpdateUserDTO user)
        {
            var result = await userService.Edit(userId, user);
            return Ok(result);
        }

        [HttpDelete("user/{id}")]
        public async Task<IActionResult> deleteUser(string userId)
        {
            var isDeleted = await userService.RemoveUser(userId);
            return Ok(isDeleted);
        }

    }
}
