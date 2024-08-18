using Chronos.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chronos.Api.Controllers
{
    /// <summary>
    /// Registros Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosController : ControllerBase
    {
        private readonly IRegistrosAppService _registrosAppService;

        public RegistrosController(IRegistrosAppService registrosAppService)
        {
            _registrosAppService = registrosAppService;
        }


    }
}
