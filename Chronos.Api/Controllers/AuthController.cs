using Chronos.Application.Interfaces;
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

        private readonly IAuthAppService _authappService;

        public AuthController(IAuthAppService authappService)
        {
            _authappService = authappService;
        }

        /// <summary>
        /// Auth
        /// </summary>
        /// <param name="username">An Username</param>
        /// <param name="password">A Password</param>
        /// <returns>An IActionResult.</returns>
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            try
            {
                TokenResult token = _authappService.Login(username, password);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }              
        }
    }
}
