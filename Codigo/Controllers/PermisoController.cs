using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace E_Commerce.Controllers
{
    [Route("api/Permiso")]
    [ApiController]
    public class PermisoController : ControllerBase
    {
        private readonly IPermiso _permiso;
        public PermisoController(IPermiso permiso)
        {
            _permiso = permiso;
        }

        [HttpGet("GetPermiso")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetPermiso()
        {
            var response = await _permiso.GetPermiso();
            return Ok(response);
        }

        [HttpPost("PostPermiso")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostPermiso([FromBody] Permisos permisos)
        {
            try
            {
                var response = await _permiso.PostPermiso(permisos);
                if (response == true)
                    return Ok("Se ha agregado un permiso correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutPermiso/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> PutPermiso(int id, [FromBody] Permisos permisos)
        {


            try
            {
                var response = await _permiso.PutPermiso(permisos);
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
        [HttpDelete("DeletePermiso/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePermiso(int id)
        {
            try
            {
                // Obtener la lista de permisos
                var permisoList = await _permiso.GetPermiso();
                var exists = permisoList.Any(a => a.Id == id);

                // Verificar si el recurso existe
                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llamar al método de eliminación con el id
                var response = await _permiso.DeletePermiso(id);

                // Verificar si la eliminación fue exitosa
                if (response)
                    return Ok("Permiso eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el permiso.");
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }
    }
}
