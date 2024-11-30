using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class NotificacionesController : Controller
    {
        private readonly INotificaciones _notificaciones;
        public NotificacionesController(INotificaciones notificaciones)
        {
            _notificaciones = notificaciones;
        }

        [HttpGet("GetNotificaciones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetNotificaciones()
        {
            var response = await _notificaciones.GetNotificaciones();
            return Ok(response);
        }

        [HttpPost("PostNotificaciones")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostNotificaciones([FromBody] Notificaciones notificaciones)
        {
            try
            {
                var response = await _notificaciones.PostNotificaciones(notificaciones);
                if (response == true)
                    return Ok("Se ha agregado una notifiacacion correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("PutNotificaciones/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutNotificaciones(int id, [FromBody] Notificaciones notificaciones)
        {
            if (notificaciones == null || notificaciones.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var notificacionesList = await _notificaciones.GetNotificaciones();
                var exists = notificacionesList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _notificaciones.PutNotificaciones(notificaciones);

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

        [HttpDelete("DeleteNotificaciones/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteNotificaciones(int id, [FromBody] Notificaciones notificaciones)
        {
            if (notificaciones == null || notificaciones.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var notificacionesList = await _notificaciones.GetNotificaciones();
                var exists = notificacionesList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _notificaciones.DeleteNotificaciones(notificaciones);

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