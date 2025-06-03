using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con usuarios.
    /// </summary>
    [Route("api/Usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarios _usuarios;

        /// <summary>
        /// Constructor que inyecta el repositorio de usuarios.
        /// </summary>
        /// <param name="usuarios">Repositorio de usuarios</param>
        public UsuariosController(IUsuarios usuarios)
        {
            _usuarios = usuarios;
        }

        /// <summary>
        /// Obtiene la lista de todos los usuarios.
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        [HttpGet("GetUsuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUsuarios()
        {
            var response = await _usuarios.GetUsuarios();
            return Ok(response);
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="usuarios">Objeto de usuario</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPost("PostUsuarios")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostUsuarios([FromBody] Usuarios usuarios)
        {
            try
            {
                var response = await _usuarios.PostUsuarios(usuarios);
                if (response == true)
                    return Ok("Se ha agregado a un Usuario correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza la información de un usuario existente.
        /// </summary>
        /// <param name="id">ID del usuario</param>
        /// <param name="usuarios">Objeto de usuario actualizado</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPut("PutUsuarios/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutUsuarios(int id, [FromBody] Usuarios usuarios)
        {
            try
            {
                var response = await _usuarios.PutUsuarios(usuarios);
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
        /// Elimina un usuario por su ID.
        /// </summary>
        /// <param name="id">ID del usuario a eliminar</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete("DeleteUsuarios/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUsuarios(int id)
        {
            try
            {
                var result = await _usuarios.DeleteUsuarios(id);
                if (result)
                {
                    return Ok("El usuario fue eliminado correctamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar el usuario.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message, innerException = ex.InnerException?.Message });
            }
        }
    }
}
