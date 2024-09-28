using Chronos.Application.Interfaces;
using Chronos.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chronos.Api.Controllers
{
    /// <summary>
    /// Usuarios Internos Controller
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosInternosController : ControllerBase
    {
        private readonly IUsuarioInternoAppService _usuarioInternoAppService;

        public UsuariosInternosController(IUsuarioInternoAppService usuarioappservice)
        {
            _usuarioInternoAppService = usuarioappservice;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns>An IActionResult.</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<UsuarioInternoViewModel> lista = _usuarioInternoAppService.GetAll();
            return Ok(lista);
        }
        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id">An Id</param>
        /// <returns>An IActionResult.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            UsuarioInternoViewModel usuario = _usuarioInternoAppService.GetById(id);
            return Ok(usuario);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model">A Model</param>
        /// <returns>An IActionResult.</returns>
        [HttpPost]
        public IActionResult Create([FromBody] UsuarioInternoViewModel model)
        {
            UsuarioInternoViewModel result = _usuarioInternoAppService.Create(model);
            return Ok(result);
        }


        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model">A Model</param>
        /// <returns>An IActionResult.</returns
        [HttpPut]
        public IActionResult Update([FromBody] UsuarioInternoViewModel model)
        {
            UsuarioInternoViewModel result = _usuarioInternoAppService.Update(model);
            return Ok(result);
        }
        /// <summary>
        /// Delete By Id
        /// </summary>
        /// <param name="id">An Id</param>
        /// <returns>An IActionResult.</returns>
        [HttpDelete]
        public IActionResult DeleteById(long id)
        {
            int result = _usuarioInternoAppService.DeleteById(id);
            if (result == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
