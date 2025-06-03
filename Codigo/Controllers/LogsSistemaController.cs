using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para gestionar los registros del sistema (LogsSistema).
    /// </summary>
    [Route("api/LogsSistema")]
    [ApiController]
    public class LogsSistemaController : Controller
    {
        private readonly ILogsSistema _logsSistema;

        /// <summary>
        /// Constructor que inyecta la dependencia del repositorio de logs del sistema.
        /// </summary>
        /// <param name="logsSistema">Repositorio de logs del sistema</param>
        public LogsSistemaController(ILogsSistema logsSistema)
        {
            _logsSistema = logsSistema;
        }

        /// <summary>
        /// Obtiene todos los registros del sistema.
        /// </summary>
        /// <returns>Lista de logs del sistema</returns>
        [HttpGet("GetLogsSistema")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetLogsSistema()
        {
            var response = await _logsSistema.GetLogsSistema();
            return Ok(response);
        }

        /// <summary>
        /// Agrega un nuevo registro de log al sistema.
        /// </summary>
        /// <param name="logsSistema">Datos del log</param>
        /// <returns>Resultado de la operación</returns>
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

        /// <summary>
        /// Actualiza un registro existente del log del sistema.
        /// </summary>
        /// <param name="id">ID del log</param>
        /// <param name="logsSistema">Datos actualizados del log</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPut("PutLogsSistema/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutLogsSistema(int id, [FromBody] LogsSistema logsSistema)
        {
            try
            {
                var response = await _logsSistema.PutLogsSistema(logsSistema);
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
        /// Elimina un registro de log del sistema por su ID.
        /// </summary>
        /// <param name="id">ID del log</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete("DeleteLogsSistema/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteLogsSistema(int id)
        {
            try
            {
                var logsSistemaList = await _logsSistema.GetLogsSistema();
                var exists = logsSistemaList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _logsSistema.DeleteLogsSistema(id);

                if (response)
                    return Ok("Log eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el log.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }
    }
}
