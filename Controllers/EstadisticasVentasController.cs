using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
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

        [HttpPost(" PostEstadisticasVentas")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostEstadisticasVentas([FromBody] EstadisticasVentas estadisticasVentas)
        {
            try
            {
                var response = await _estadisticasVentas.PostEstadisticasVentas(estadisticasVentas);
                if (response == true)
                    return Ok("El envio a sido agregado correctamente");
                else
                    return BadRequest(response);
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutAuditorias(int id, [FromBody] EstadisticasVentas estadisticasVentas)
        {
            if ( estadisticasVentas == null || estadisticasVentas.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var estadisticasVentasList = await _estadisticasVentas.GetEstadisticasVentas();
                var exists = estadisticasVentasList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _estadisticasVentas.PutEstadisticasVentas(estadisticasVentas);

                if (response)
                    return Ok("Actualizado correctamente.");
                else
                    return BadRequest("No se pudo actualizar el recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }

        [HttpDelete("DeleteEstadisticasVentas/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEstadisticasVentas(int id, [FromBody] EstadisticasVentas estadisticasVentas)
        {
            if (estadisticasVentas == null || estadisticasVentas.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var estadisticasVentasList = await _estadisticasVentas.GetEstadisticasVentas();
                var exists = estadisticasVentasList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _estadisticasVentas.DeleteEstadisticasVentas(estadisticasVentas);

                if (response)
                    return Ok("Actualizado correctamente.");
                else
                    return BadRequest("No se pudo actualizar el recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }
    }
}
