using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para la gestión de comentarios en productos del sistema E-Commerce.
    /// </summary>
    [Route("api/Comentarios")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly IComentarios _comentarios;

        /// <summary>
        /// Constructor que inyecta la dependencia del repositorio de comentarios.
        /// </summary>
        /// <param name="comentarios">Repositorio de comentarios.</param>
        public ComentariosController(IComentarios comentarios)
        {
            _comentarios = comentarios;
        }

        /// <summary>
        /// Obtiene los comentarios asociados a un producto específico.
        /// </summary>
        /// <param name="productoId">ID del producto.</param>
        /// <returns>Lista de comentarios del producto.</returns>
        [HttpGet("GetComentariosPorProducto/{productoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetComentariosPorProducto(int productoId)
        {
            try
            {
                var todos = await _comentarios.GetComentarios();
                var filtrados = todos.Where(c => c.ProductoId == productoId).ToList();
                return Ok(filtrados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todos los comentarios del sistema.
        /// </summary>
        /// <returns>Lista de todos los comentarios.</returns>
        [HttpGet("GetComentarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetComentarios()
        {
            var response = await _comentarios.GetComentarios();
            return Ok(response);
        }

        /// <summary>
        /// Crea un nuevo comentario en el sistema.
        /// </summary>
        /// <param name="comentarios">Objeto del comentario a insertar.</param>
        /// <returns>Mensaje de éxito o error.</returns>
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

        /// <summary>
        /// Actualiza un comentario existente.
        /// </summary>
        /// <param name="comentarios">Comentario actualizado.</param>
        /// <returns>Mensaje de éxito o error.</returns>
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

        /// <summary>
        /// Elimina un comentario por su ID.
        /// </summary>
        /// <param name="id">ID del comentario a eliminar.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpDelete("DeleteComentarios/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteComentarios(int id)
        {
            try
            {
                var categoriasList = await _comentarios.GetComentarios();
                var exists = categoriasList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _comentarios.DeleteComentarios(id);

                if (response)
                    return Ok("El comentario fue eliminado correctamente.");
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
