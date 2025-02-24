using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/RolesPermisos")]
    [ApiController]
    public class RolesPermisosController : Controller
    {
        private readonly IRolesPermisos _rolesPermisos;
        public RolesPermisosController(IRolesPermisos rolesPermisos)
        {
            _rolesPermisos = rolesPermisos;
        }

        [HttpGet("GetRolesPermisos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetRolesPermisos()
        {
            var response = await _rolesPermisos.GetRolesPermisos();
            return Ok(response);
        }

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

        [HttpPut("PutRolesPermisos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutRolesPermisos ( int id, [FromBody] RolesPermisos rolesPermisos)
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

        [HttpDelete("DeleteRolesPermisos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRolesPermisos(int id)
        {
            try
            {
                // Obtener la lista de roles y permisos
                var rolesPermisosList = await _rolesPermisos.GetRolesPermisos();
                var exists = rolesPermisosList.Any(a => a.Id == id);

                // Verificar si el recurso existe
                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llamar al método de eliminación con solo el id
                var response = await _rolesPermisos.DeleteRolesPermisos(id);

                // Verificar si la eliminación fue exitosa
                if (response)
                    return Ok("Recurso eliminado correctamente.");
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
