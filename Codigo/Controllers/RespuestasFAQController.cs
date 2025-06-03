using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para la gestión de respuestas a preguntas frecuentes (FAQ).
    /// </summary>
    [Route("api/RespuestasFAQ")]
    [ApiController]
    public class RespuestasFAQController : Controller
    {
        private readonly IRespuestasFAQ _respuestasFAQ;

        /// <summary>
        /// Constructor que inyecta la dependencia del repositorio de respuestas FAQ.
        /// </summary>
        /// <param name="respuestasFAQ">Interfaz del repositorio de respuestas FAQ</param>
        public RespuestasFAQController(IRespuestasFAQ respuestasFAQ)
        {
            _respuestasFAQ = respuestasFAQ;
        }

        /// <summary>
        /// Obtiene todas las respuestas a preguntas frecuentes.
        /// </summary>
        /// <returns>Lista de respuestas FAQ</returns>
        [HttpGet("GetRespuestasFAQ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetRespuestasFAQ()
        {
            var response = await _respuestasFAQ.GetRespuestasFAQ();
            return Ok(response);
        }

        /// <summary>
        /// Inserta una nueva respuesta a una pregunta frecuente.
        /// </summary>
        /// <param name="respuestasFAQ">Objeto con los datos de la respuesta</param>
        /// <returns>Resultado de la operación</returns>
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

        /// <summary>
        /// Actualiza una respuesta a una pregunta frecuente existente.
        /// </summary>
        /// <param name="id">ID de la respuesta</param>
        /// <param name="respuestaFAQ">Objeto con los datos actualizados</param>
        /// <returns>Resultado de la operación</returns>
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

        /// <summary>
        /// Elimina una respuesta a una pregunta frecuente por su ID.
        /// </summary>
        /// <param name="id">ID de la respuesta</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete("DeleteRespuestaFAQ/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRespuestaFAQ(int id)
        {
            try
            {
                var respuestasFAQList = await _respuestasFAQ.GetRespuestasFAQ();
                var exists = respuestasFAQList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _respuestasFAQ.DeleteRespuestasFAQ(id);

                if (response)
                    return Ok("Recurso eliminado correctamente.");
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
