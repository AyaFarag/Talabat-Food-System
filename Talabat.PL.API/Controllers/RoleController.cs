using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Application.Contracts.Interfaces;
using Talabat.Application.DTO.Role;

namespace Talabat.PL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService _roleService)
        {
            roleService = _roleService;
        }

        [HttpGet("get/roles")]
        public async Task<IActionResult> getRoles()
        {
            return Ok(await roleService.getRoles());
        }

        [HttpPost("create/role")]
        public async Task<IActionResult> createRole(CreateRoleDTO role)
        {
            var result = await roleService.createRole(role);
            return Ok(result);
        }

        [HttpPut("update/role")]
        public async Task<IActionResult> updateRole([FromQuery] string id, [FromBody] UpdateRoleDTO roleDTO)
        {
            return Ok(await roleService.updateRole(id, roleDTO));
        }

        [HttpDelete("delete/role/{id}")]
        public async Task<IActionResult> deleteRole([FromRoute] string id)
        {
            return Ok(await roleService.deleteRole(id));
        }

      
    }
}
