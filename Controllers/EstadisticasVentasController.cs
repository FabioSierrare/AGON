using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controller/estadisticasventas")]
    [ApiController]
    public class EstadisticasVentasController : ControllerBase
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
                    return Ok("El envío de las estadísticas de ventas ha sido agregado correctamente.");
                else
                    return BadRequest("Hubo un error al agregar las estadísticas de ventas.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutEstadisticasVentas/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutEstadisticasVentas([FromBody] EstadisticasVentas estadisticasVentas)
        {


            try
            {
                var response = await _estadisticasVentas.PutEstadisticasVentas(estadisticasVentas);
                if (response)
                    return Ok("Comentario actualizado correctamente.");
                else
                    return NotFound("Comentario no encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteEstadisticasVentas/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEstadisticasVentas(int id)
        {
            try
            {
                var estadisticasVentasList = await _estadisticasVentas.GetEstadisticasVentas();
                var exists = estadisticasVentasList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _estadisticasVentas.DeleteEstadisticasVentas(id);

                if (response)
                    return Ok("Las estadísticas de ventas han sido eliminadas correctamente.");
                else
                    return BadRequest("No se pudo eliminar el recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}