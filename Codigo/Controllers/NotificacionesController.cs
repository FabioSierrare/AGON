using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para gestionar las notificaciones dentro del sistema.
    /// </summary>
    [Route("api/Notificaciones")]
    [ApiController]
    public class NotificacionesController : Controller
    {
        private readonly INotificaciones _notificaciones;

        /// <summary>
        /// Constructor que inyecta la dependencia del repositorio de notificaciones.
        /// </summary>
        /// <param name="notificaciones">Repositorio de notificaciones</param>
        public NotificacionesController(INotificaciones notificaciones)
        {
            _notificaciones = notificaciones;
        }

        /// <summary>
        /// Obtiene todas las notificaciones existentes.
        /// </summary>
        /// <returns>Lista de notificaciones</returns>
        [HttpGet("GetNotificaciones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetNotificaciones()
        {
            var response = await _notificaciones.GetNotificaciones();
            return Ok(response);
        }

        /// <summary>
        /// Agrega una nueva notificación al sistema.
        /// </summary>
        /// <param name="notificaciones">Datos de la notificación</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPost("PostNotificaciones")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostNotificaciones([FromBody] Notificaciones notificaciones)
        {
            try
            {
                var response = await _notificaciones.PostNotificaciones(notificaciones);
                if (response == true)
                    return Ok("Se ha agregado una notificación correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza una notificación existente.
        /// </summary>
        /// <param name="id">ID de la notificación</param>
        /// <param name="notificaciones">Datos actualizados de la notificación</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPut("PutNotificaciones/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutNotificaciones(int id, [FromBody] Notificaciones notificaciones)
        {
            try
            {
                var response = await _notificaciones.PutNotificaciones(notificaciones);
                if (response)
                    return Ok("Notificación actualizada correctamente.");
                else
                    return NotFound("Notificación no encontrada.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Elimina una notificación por su ID.
        /// </summary>
        /// <param name="id">ID de la notificación</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete("DeleteNotificaciones/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteNotificaciones(int id)
        {
            try
            {
                var logsSistemaList = await _notificaciones.GetNotificaciones();
                var exists = logsSistemaList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _notificaciones.DeleteNotificaciones(id);

                if (response)
                    return Ok("Notificación eliminada correctamente.");
                else
                    return BadRequest("No se pudo eliminar la notificación.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }
    }
}
