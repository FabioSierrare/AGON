using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para la gestión de permisos dentro del sistema.
    /// </summary>
    [Route("api/Permiso")]
    [ApiController]
    public class PermisoController : ControllerBase
    {
        private readonly IPermiso _permiso;

        /// <summary>
        /// Constructor que inyecta el repositorio de permisos.
        /// </summary>
        /// <param name="permiso">Interfaz del repositorio de permisos</param>
        public PermisoController(IPermiso permiso)
        {
            _permiso = permiso;
        }

        /// <summary>
        /// Obtiene la lista de todos los permisos registrados.
        /// </summary>
        /// <returns>Lista de permisos</returns>
        [HttpGet("GetPermiso")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetPermiso()
        {
            var response = await _permiso.GetPermiso();
            return Ok(response);
        }

        /// <summary>
        /// Crea un nuevo permiso.
        /// </summary>
        /// <param name="permisos">Objeto del permiso a crear</param>
        /// <returns>Resultado de la operación</returns>
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

        /// <summary>
        /// Actualiza un permiso existente.
        /// </summary>
        /// <param name="id">ID del permiso</param>
        /// <param name="permisos">Objeto con los datos actualizados</param>
        /// <returns>Resultado de la operación</returns>
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
                    return Ok("Permiso actualizado correctamente.");
                else
                    return NotFound("Permiso no encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Elimina un permiso por su ID.
        /// </summary>
        /// <param name="id">ID del permiso</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete("DeletePermiso/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePermiso(int id)
        {
            try
            {
                var permisoList = await _permiso.GetPermiso();
                var exists = permisoList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _permiso.DeletePermiso(id);

                if (response)
                    return Ok("Permiso eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el permiso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }
    }
}
