using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
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
            if (rolesPermisos == null || rolesPermisos.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var rolesPermisosList = await _rolesPermisos.GetRolesPermisos();
                var exists = rolesPermisosList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _rolesPermisos.PutRolesPermisos(rolesPermisos);

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

        [HttpDelete("DeleteRolesPermisos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRolesPermisos(int id, [FromBody] RolesPermisos rolesPermisos)
        {
            if (rolesPermisos == null || rolesPermisos.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var rolesPermisosList = await _rolesPermisos.GetRolesPermisos();
                var exists = rolesPermisosList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _rolesPermisos.DeleteRolesPermisos(rolesPermisos);

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
