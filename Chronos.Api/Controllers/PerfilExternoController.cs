using Chronos.Application.Interfaces;
using Chronos.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Chronos.Api.Controllers
{
    /// <summary>
    /// Perfil Externo Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilExternoController : ControllerBase
    {
        private readonly IPerfilExternoAppService _perfilExternoAppService;
        private readonly ILogger<PerfilExternoController> _logger;

        public PerfilExternoController(IPerfilExternoAppService perfilExternoAppService, ILogger<PerfilExternoController> logger)
        {
            _perfilExternoAppService = perfilExternoAppService;
            _logger = logger;
        }
        /// <summary>
        /// Get All
        /// </summary>
        /// <returns>An IActionResult.</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var res = _perfilExternoAppService.GetAll();
                _logger.LogInformation("Fetched all external profiles successfully.");
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching external profiles.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching profiles.");
            }
        }
        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id">An Id</param>
        /// <returns>An IActionResult.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var res = _perfilExternoAppService.GetById(id);
                if (res == null)
                {
                    _logger.LogWarning($"Profile with ID {id} not found.");
                    return NotFound($"Profile with ID {id} not found.");
                }

                _logger.LogInformation($"Fetched profile with ID {id} successfully.");
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching profile with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the profile.");
            }
        }
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model">A Model</param>
        /// <returns>An IActionResult.</returns>
        [HttpPost]
        public IActionResult Create(PerfilExternoViewModel model)
        {
            if (model == null)
            {
                _logger.LogWarning("Create request received with null model.");
                return BadRequest("Profile data is required.");
            }

            try
            {
                var res = _perfilExternoAppService.Create(model);
                _logger.LogInformation("Profile created successfully.");
                return CreatedAtAction(nameof(Create), res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating profile.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the profile.");
            }
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model">A Model</param>
        /// <returns>An IActionResult.</returns>
        [HttpPut]
        public IActionResult Update(PerfilExternoViewModel model)
        {
            if (model == null)
            {
                _logger.LogWarning("Update request received with null model.");
                return BadRequest("Profile data is required.");
            }

            try
            {
                var res = _perfilExternoAppService.Update(model);
                _logger.LogInformation($"Profile updated successfully.");
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating profile.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the profile.");
            }
        }
        /// <summary>
        /// Delete By Id
        /// </summary>
        /// <param name="id">An Id</param>
        /// <returns>An IActionResult.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteById(long id)
        {
            try
            {
                var res = _perfilExternoAppService.DeleteById(id);
                if (res > 0)
                {
                    _logger.LogWarning($"Profile with ID {id} not found for deletion.");
                    return NotFound($"Profile with ID {id} not found.");
                }

                _logger.LogInformation($"Profile with ID {id} deleted successfully.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting profile with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the profile.");
            }
        }
    }
}
