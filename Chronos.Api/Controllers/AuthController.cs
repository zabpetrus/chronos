using Chronos.Application.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chronos.Api.Controllers
{
    /// <summary>
    /// Auth Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Auth
        /// </summary>
        /// <param name="username">An Username</param>
        /// <param name="password">A Password</param>
        /// <returns>An IActionResult.</returns>
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if(username == "admin" || password == "123456")
            {
                var token = TokenService.GenerateToken( new Domain.Entities.UsuarioExterno() );
                return Ok(token);
            }

            return BadRequest("Login ou senha invalidos");
        }
    }
}
