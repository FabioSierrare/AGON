using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para la gestión de roles y permisos.
    /// </summary>
    [Route("api/RolesPermisos")]
    [ApiController]
    public class RolesPermisosController : Controller
    {
        private readonly IRolesPermisos _rolesPermisos;

        /// <summary>
        /// Constructor que inyecta la dependencia del repositorio de roles y permisos.
        /// </summary>
        /// <param name="rolesPermisos">Interfaz del repositorio de roles y permisos</param>
        public RolesPermisosController(IRolesPermisos rolesPermisos)
        {
            _rolesPermisos = rolesPermisos;
        }

        /// <summary>
        /// Obtiene la lista de roles y permisos registrados.
        /// </summary>
        /// <returns>Lista de roles y permisos</returns>
        [HttpGet("GetRolesPermisos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetRolesPermisos()
        {
            var response = await _rolesPermisos.GetRolesPermisos();
            return Ok(response);
        }

        /// <summary>
        /// Inserta un nuevo registro de rol y permiso.
        /// </summary>
        /// <param name="rolesPermisos">Objeto con la información de rol y permiso</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPost("PostRolesPermisos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostRolesPermisos([FromBody] RolesPermisos rolesPermisos)
        {
            try
            {
                var response = await _rolesPermisos.PostRolesPermisos(rolesPermisos);
                if (response == true)
                    return Ok("Se ha agregado una RolPermiso correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza la información de un rol y permiso existente.
        /// </summary>
        /// <param name="id">ID del rolPermiso</param>
        /// <param name="rolesPermisos">Objeto con los datos actualizados</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPut("PutRolesPermisos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutRolesPermisos(int id, [FromBody] RolesPermisos rolesPermisos)
        {
            try
            {
                var response = await _rolesPermisos.PutRolesPermisos(rolesPermisos);
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
        /// Elimina un rol y permiso por su ID.
        /// </summary>
        /// <param name="id">ID del registro a eliminar</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete("DeleteRolesPermisos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRolesPermisos(int id)
        {
            try
            {
                var rolesPermisosList = await _rolesPermisos.GetRolesPermisos();
                var exists = rolesPermisosList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _rolesPermisos.DeleteRolesPermisos(id);

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
