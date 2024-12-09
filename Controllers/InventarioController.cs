using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IInventarios _inventarios;
        public InventarioController(IInventarios inventarios)
        {
            _inventarios = inventarios;
        }

        [HttpGet("GetInventarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetInventarios()
        {
            var response = await _inventarios.GetInventarios();
            return Ok(response);
        }

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

        [HttpDelete("DeleteInventarios/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteInventarios(int id)
        {
            try
            {
                // Obtener la lista de inventarios
                var inventariosList = await _inventarios.GetInventarios();
                var exists = inventariosList.Any(a => a.Id == id);

                // Verificar si el recurso existe
                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llamar al método de eliminación con solo el id
                var response = await _inventarios.DeleteInventarios(id);

                // Verificar si la eliminación fue exitosa
                if (response)
                    return Ok("Inventario eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el inventario.");
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }
    }
}
