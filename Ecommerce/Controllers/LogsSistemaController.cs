using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class LogsSistemaController : Controller
    {
        private readonly ILogsSistema _logsSistema;
        public LogsSistemaController(ILogsSistema logsSistema)
        {
            _logsSistema = logsSistema;
        }

        [HttpGet("GetLogsSistema")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetLogsSistema()
        {
            var response = await _logsSistema.GetLogsSistema();
            return Ok(response);
        }

        [HttpPost("PostLogsSistema")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostLogsSistema([FromBody] LogsSistema logsSistema)
        {
            try
            {
                var response = await _logsSistema.PostLogsSistema(logsSistema);
                if (response == true)
                    return Ok("El nuevo inventario a sido agregado correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("PutLogsSistema/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutLogsSistema(int id, [FromBody] LogsSistema logsSistema)
        {
            if (logsSistema == null || logsSistema.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var logsSistemaList = await _logsSistema.GetLogsSistema();
                var exists = logsSistemaList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _logsSistema.PutLogsSistema(logsSistema);

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

        [HttpDelete("DeleteLogsSistema/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteLogsSistema (int id, [FromBody] LogsSistema logsSistema)
        {
            if (logsSistema == null || logsSistema.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var logsSistemaList = await _logsSistema.GetLogsSistema();
                var exists = logsSistemaList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _logsSistema.DeleteLogsSistema(logsSistema);

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