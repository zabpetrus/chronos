using Chronos.Application.Interfaces;
using Chronos.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chronos.Api.Controllers
{
    /// <summary>
    /// Perfis Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PerfisController : ControllerBase
    {
        private readonly IPerfilAppService _perfilAppService;

        public PerfisController(IPerfilAppService perfilAppService)
        {
            _perfilAppService = perfilAppService;
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
                return Ok("Success");
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);   
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
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// Add
        /// </summary>
        /// <param name="perfilViewModel">A Perfil View Model</param>
        /// <returns>An IActionResult.</returns>
        [HttpPost]
        public IActionResult Add(PerfilViewModel perfilViewModel)
        {
            try
            {
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="perfilViewModel">A Perfil View Model</param>
        /// <returns>An IActionResult.</returns>
        [HttpPut]
        public IActionResult Update(PerfilViewModel perfilViewModel)
        {
            try
            {
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">An Id</param>
        /// <returns>An IActionResult.</returns>
        [HttpDelete]
        public IActionResult Delete(long id)
        {
            try
            {
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
