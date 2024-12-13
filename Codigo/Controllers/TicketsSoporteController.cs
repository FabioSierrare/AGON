using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class TicketsSoporteController : Controller
    {
        private readonly ITicketsSoporte _ticketsSoporte;
        public TicketsSoporteController(ITicketsSoporte tikectsSoporte)
        {
            _ticketsSoporte = tikectsSoporte;
        }

        [HttpGet("GetTicketsSoporte")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetTicketsSoporte()
        {
            var response = await _ticketsSoporte.GetTicketsSoporte();
            return Ok(response);
        }

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

        [HttpDelete("DeleteTicketsSoporte/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTicketsSoporte(int id)
        {
            try
            {
                // Obtener la lista de tickets de soporte
                var ticketsSoporteList = await _ticketsSoporte.GetTicketsSoporte();
                var exists = ticketsSoporteList.Any(a => a.Id == id);

                // Verificar si el ticket de soporte existe
                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llamar al método para eliminar el ticket de soporte usando solo el id
                var response = await _ticketsSoporte.DeleteTicketsSoporte(id);

                // Verificar si la eliminación fue exitosa
                if (response)
                    return Ok("Ticket de soporte eliminado correctamente.");
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
