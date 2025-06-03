using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con el inventario.
    /// </summary>
    [Route("api/Inventario")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IInventarios _inventarios;

        /// <summary>
        /// Constructor que inyecta la dependencia del repositorio de inventarios.
        /// </summary>
        /// <param name="inventarios">Repositorio de inventarios</param>
        public InventarioController(IInventarios inventarios)
        {
            _inventarios = inventarios;
        }

        /// <summary>
        /// Obtiene todos los registros del inventario.
        /// </summary>
        /// <returns>Lista de inventarios</returns>
        [HttpGet("GetInventarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetInventarios()
        {
            var response = await _inventarios.GetInventarios();
            return Ok(response);
        }

        /// <summary>
        /// Inserta un nuevo registro en el inventario.
        /// </summary>
        /// <param name="inventarios">Datos del nuevo inventario</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPost("PostInventarios")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostInventarios([FromBody] Inventarios inventarios)
        {
            try
            {
                var response = await _inventarios.PostInventarios(inventarios);
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
        /// Actualiza un registro existente del inventario.
        /// </summary>
        /// <param name="id">ID del inventario</param>
        /// <param name="inventarios">Datos actualizados del inventario</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPut("PutInventarios/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutInventarios(int id, [FromBody] Inventarios inventarios)
        {
            try
            {
                var response = await _inventarios.PutInventarios(inventarios);
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
        /// Elimina un registro de inventario por su ID.
        /// </summary>
        /// <param name="id">ID del inventario a eliminar</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete("DeleteInventarios/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteInventarios(int id)
        {
            try
            {
                var inventariosList = await _inventarios.GetInventarios();
                var exists = inventariosList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _inventarios.DeleteInventarios(id);

                if (response)
                    return Ok("Inventario eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el inventario.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }
    }
}
