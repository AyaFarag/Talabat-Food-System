using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Talabat.PL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        // RegisterDTO dto
        public async Task<IActionResult> Register()
        {
            // service.regiser
            return Ok();
        }

        [HttpPost("login")]
        // LoginDTO dto
        public async Task<IActionResult> login()
        {
            // service.login
            return Ok();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> logout()
        {
            // service.logout
            return Ok();
        }
    }
}
