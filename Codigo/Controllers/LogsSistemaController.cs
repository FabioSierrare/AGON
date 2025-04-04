﻿using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/LogsSistema")]
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

        [HttpDelete("DeleteLogsSistema/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteLogsSistema(int id)
        {
            try
            {
                // Obtener la lista de logs del sistema
                var logsSistemaList = await _logsSistema.GetLogsSistema();
                var exists = logsSistemaList.Any(a => a.Id == id);

                // Verificar si el recurso existe
                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llamar al método de eliminación con solo el id
                var response = await _logsSistema.DeleteLogsSistema(id);

                // Verificar si la eliminación fue exitosa
                if (response)
                    return Ok("Log eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el log.");
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }
    }
}