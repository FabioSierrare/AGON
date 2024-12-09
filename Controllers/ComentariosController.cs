using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly IComentarios _comentarios;
        public ComentariosController(IComentarios comentarios)
        {
            _comentarios = comentarios;
        }

        [HttpGet("GetComentarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetComentarios()
        {
            var response = await _comentarios.GetComentarios();
            return Ok(response);
        }

        [HttpPost("PostComentarios")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostComentarios([FromBody] Comentarios comentarios)
        {
            try
            {
                var response = await _comentarios.PostComentarios(comentarios);
                if (response == true)
                    return Ok("Comentario Agregado correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutComentarios/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutComentarios([FromBody] Comentarios comentarios)
        {


            try
            {
                var response = await _comentarios.PutComentarios(comentarios);
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

        [HttpDelete("DeleteComentarios/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteComentarios(int id)
        {
            try
            {
                // Verificar si el comentario existe
                var categoriasList = await _comentarios.GetComentarios();
                var exists = categoriasList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llamar al repositorio para eliminar el comentario
                var response = await _comentarios.DeleteComentarios(id);

                if (response)
                    return Ok("El comentario fue eliminado correctamente.");
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
