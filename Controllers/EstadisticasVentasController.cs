using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controller/estadisticasventas")]
    [ApiController]
    public class EstadisticasVentasController : Controller
    {
        private readonly IEstadisticasVentas _estadisticasVentas;

        public EstadisticasVentasController(IEstadisticasVentas estadisticasVentas)
        {
            _estadisticasVentas = estadisticasVentas;
        }

        [HttpGet("GetEstadisticasVentas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetEstadisticasVentas()
        {
            var response = await _estadisticasVentas.GetEstadisticasVentas();
            return Ok(response);
        }

        [HttpPost("PostEstadisticasVentas")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostEstadisticasVentas([FromBody] EstadisticasVentas estadisticasVentas)
        {
            try
            {
                var response = await _estadisticasVentas.PostEstadisticasVentas(estadisticasVentas);
                if (response)
                    return Ok("El envío ha sido agregado correctamente.");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // Other actions
    }
}
