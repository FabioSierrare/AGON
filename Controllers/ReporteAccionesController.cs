using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class ReporteAccionesController : Controller
    {
        private readonly IReporteAcciones _reporteAcciones;
        public ReporteAccionesController(IReporteAcciones reporteAcciones)
        {
            _reporteAcciones = reporteAcciones;
        }

        [HttpGet("GetReporteAcciones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetReporteAcciones()
        {
            var response = await _reporteAcciones.GetReporteAcciones();
            return Ok(response);
        }

        [HttpPost("PostReporteAcciones")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostReporteAcciones([FromBody] ReporteAcciones reporteAcciones)
        {
            try
            {
                var response = await _reporteAcciones.PostReporteAcciones(reporteAcciones);
                if (response == true)
                    return Ok("Se ha agregado el reporte de una accion correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutReporteAcciones/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> PutReporteAcciones(int id, [FromBody] ReporteAcciones reporteAcciones)
        {


            try
            {
                var response = await _reporteAcciones.PutReporteAcciones(reporteAcciones);
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

        [HttpDelete("DeleteReporteAcciones/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteReporteAcciones(int id)
        {
            try
            {
                // Obtener la lista de reportes de acciones
                var reporteAccionesList = await _reporteAcciones.GetReporteAcciones();
                var exists = reporteAccionesList.Any(a => a.Id == id);

                // Verificar si el recurso existe
                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llamar al método de eliminación con solo el id
                var response = await _reporteAcciones.DeleteReporteAcciones(id);

                // Verificar si la eliminación fue exitosa
                if (response)
                    return Ok("Recurso eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el recurso.");
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }
    }
}
