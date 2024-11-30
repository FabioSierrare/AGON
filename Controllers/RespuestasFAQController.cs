using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
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
            if (respuestaFAQ == null || respuestaFAQ.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var respuestasFAQList = await _respuestasFAQ.GetRespuestasFAQ();
                var exists = respuestasFAQList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _respuestasFAQ.PutRespuestasFAQ(respuestaFAQ);

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

        [HttpDelete("DeleteRespuestaFAQ/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteRespuestaFAQ(int id, [FromBody] RespuestasFAQ respuestaFAQ)
        {
            if (respuestaFAQ == null || respuestaFAQ.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var respuestasFAQList = await _respuestasFAQ.GetRespuestasFAQ();
                var exists = respuestasFAQList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _respuestasFAQ.DeleteRespuestasFAQ(respuestaFAQ);

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
