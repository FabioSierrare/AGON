using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para la gestión de tickets de soporte.
    /// </summary>
    [Route("api/TicketsSoporte")]
    [ApiController]
    public class TicketsSoporteController : Controller
    {
        private readonly ITicketsSoporte _ticketsSoporte;

        /// <summary>
        /// Constructor que inyecta el repositorio de tickets de soporte.
        /// </summary>
        /// <param name="tikectsSoporte">Interfaz del repositorio</param>
        public TicketsSoporteController(ITicketsSoporte tikectsSoporte)
        {
            _ticketsSoporte = tikectsSoporte;
        }

        /// <summary>
        /// Obtiene la lista de tickets de soporte.
        /// </summary>
        /// <returns>Lista de tickets</returns>
        [HttpGet("GetTicketsSoporte")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetTicketsSoporte()
        {
            var response = await _ticketsSoporte.GetTicketsSoporte();
            return Ok(response);
        }

        /// <summary>
        /// Crea un nuevo ticket de soporte.
        /// </summary>
        /// <param name="tikectsSoporte">Objeto del ticket</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPost("PostTicketsSoporte")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostTicketsSoporte([FromBody] TicketsSoporte tikectsSoporte)
        {
            try
            {
                var response = await _ticketsSoporte.PostTicketsSoporte(tikectsSoporte);
                if (response == true)
                    return Ok("Se ha agregado un ticket de soporte correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un ticket de soporte existente.
        /// </summary>
        /// <param name="id">ID del ticket</param>
        /// <param name="ticketsSoporte">Datos del ticket</param>
        /// <returns>Resultado de la actualización</returns>
        [HttpPut("PutTicketsSoporte/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutTicketsSoporte(int id, [FromBody] TicketsSoporte ticketsSoporte)
        {
            try
            {
                var response = await _ticketsSoporte.PutTicketsSoporte(ticketsSoporte);
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
        /// Elimina un ticket de soporte por ID.
        /// </summary>
        /// <param name="id">ID del ticket</param>
        /// <returns>Resultado de la eliminación</returns>
        [HttpDelete("DeleteTicketsSoporte/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTicketsSoporte(int id)
        {
            try
            {
                var ticketsSoporteList = await _ticketsSoporte.GetTicketsSoporte();
                var exists = ticketsSoporteList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _ticketsSoporte.DeleteTicketsSoporte(id);

                if (response)
                    return Ok("Ticket de soporte eliminado correctamente.");
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
