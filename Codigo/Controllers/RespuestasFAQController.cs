using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/RespuestasFAQ")]
    [ApiController]
    public class RespuestasFAQController : Controller
    {
        private readonly IRespuestasFAQ _respuestasFAQ;
        public RespuestasFAQController(IRespuestasFAQ respuestasFAQ)
        {
            _respuestasFAQ = respuestasFAQ;
        }

        [HttpGet("GetRespuestasFAQ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetRespuestasFAQ()
        {
            var response = await _respuestasFAQ.GetRespuestasFAQ();
            return Ok(response);
        }

        [HttpPost("PostRespuestaFAQ")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostRespuestasFAQ([FromBody] RespuestasFAQ respuestasFAQ)
        {
            try
            {
                var response = await _respuestasFAQ.PostRespuestaFAQ(respuestasFAQ);
                if (response == true)
                    return Ok("Se ha agregado una RespuestaFAQ correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutRespuestaFAQ/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> PutRespuestaFAQ(int id, [FromBody] RespuestasFAQ respuestaFAQ)
        {
            try
            {
                var response = await _respuestasFAQ.PutRespuestasFAQ(respuestaFAQ);
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

        [HttpDelete("DeleteRespuestaFAQ/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRespuestaFAQ(int id)
        {
            try
            {
                // Obtener la lista de respuestas FAQ
                var respuestasFAQList = await _respuestasFAQ.GetRespuestasFAQ();
                var exists = respuestasFAQList.Any(a => a.Id == id);

                // Verificar si el recurso existe
                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llamar al método de eliminación con solo el id
                var response = await _respuestasFAQ.DeleteRespuestasFAQ(id);

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
