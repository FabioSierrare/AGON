using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para gestionar el seguimiento de envíos.
    /// </summary>
    [Route("api/TrackingEnvio")]
    [ApiController]
    public class TrackingEnvioController : ControllerBase
    {
        private readonly ITrackingEnvio _trackingEnvio;

        /// <summary>
        /// Constructor que inyecta el repositorio de tracking de envío.
        /// </summary>
        /// <param name="trackingEnvio">Repositorio de tracking</param>
        public TrackingEnvioController(ITrackingEnvio trackingEnvio)
        {
            _trackingEnvio = trackingEnvio;
        }

        /// <summary>
        /// Obtiene todos los registros de tracking de envío.
        /// </summary>
        /// <returns>Lista de registros de tracking</returns>
        [HttpGet("GetTrackinEnvio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetTicketsSoporte()
        {
            var response = await _trackingEnvio.GetTrackingEnvio();
            return Ok(response);
        }

        /// <summary>
        /// Crea un nuevo registro de tracking de envío.
        /// </summary>
        /// <param name="trackingEnvio">Objeto tracking</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPost("PostTrackingEnvio")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostTrackingEnvio([FromBody] TrackingEnvio trackingEnvio)
        {
            try
            {
                var response = await _trackingEnvio.PostTrackingEnvio(trackingEnvio);
                if (response == true)
                    return Ok("Se ha agregado un Envio Tracking correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un registro de tracking de envío existente.
        /// </summary>
        /// <param name="id">ID del tracking</param>
        /// <param name="trackingEnvio">Objeto tracking actualizado</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPut("PutTrackingEnvio/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutTrackingEnvio(int id, [FromBody] TrackingEnvio trackingEnvio)
        {
            try
            {
                var response = await _trackingEnvio.PutTrackingEnvio(trackingEnvio);
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

        /// <summary>
        /// Elimina un registro de tracking de envío por ID.
        /// </summary>
        /// <param name="id">ID del tracking</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete("DeleteTrackingEnvio/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTrackingEnvio(int id)
        {
            try
            {
                var trackingEnvioList = await _trackingEnvio.GetTrackingEnvio();
                var exists = trackingEnvioList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _trackingEnvio.DeleteTrackingEnvio(id);

                if (response)
                    return Ok("TrackingEnvio eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }
    }
}
