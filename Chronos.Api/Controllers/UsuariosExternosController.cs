using Chronos.Application.Interfaces;
using Chronos.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Chronos.Api.Controllers
{
    /// <summary>
    /// Usuarios Externos Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosExternosController : ControllerBase
    {
        private readonly IUsuarioExternoAppService _usuarioExternoAppService;

        public UsuariosExternosController(IUsuarioExternoAppService usuarioExternoAppService)
        {
            _usuarioExternoAppService = usuarioExternoAppService;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns>An IActionResult.</returns>
        [HttpGet]
        public ActionResult<List<UsuarioExternoViewModel>> GetAll()
        {
            try
            {
                var lista = _usuarioExternoAppService.GetAll();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                // Log exception (ex) here
                return StatusCode(500, "Internal server error: ." + ex);
            }
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id">An Id</param>
        /// <returns>An IActionResult.</returns>
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<UsuarioExternoViewModel> GetById(long id)
        {
            try
            {
                var usuario = _usuarioExternoAppService.GetById(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                // Log exception (ex) here
                return StatusCode(500, "Internal server error: " + ex);
            }
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model">A Model</param>
        /// <returns>An IActionResult.</returns>
        [Authorize]
        [HttpPost]
        public ActionResult<UsuarioExternoViewModel> Create([FromBody] UsuarioExternoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _usuarioExternoAppService.Create(model);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                        // Log exception (ex) here
                        return StatusCode(500, "Internal server error." + ex);
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model">A Model</param>
        /// <returns>An IActionResult.</returns>
        [Authorize]
        [HttpPut]
        public ActionResult<UsuarioExternoViewModel> Update([FromBody] UsuarioExternoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _usuarioExternoAppService.Update(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log exception (ex) here
                return StatusCode(500, "Internal server error." + ex);
            }
        }

        /// <summary>
        /// Delete By Id
        /// </summary>
        /// <param name="id">An Id</param>
        /// <returns>An IActionResult.</returns>
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteById(long id)
        {
            try
            {
                var result = _usuarioExternoAppService.DeleteById(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log exception (ex) here
                return StatusCode(500, "Internal server error." + ex);
            }
        }
    }
}
