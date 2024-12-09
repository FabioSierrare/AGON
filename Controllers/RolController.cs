﻿using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class RolController : Controller
    {
        private readonly IRol _rol;
        public RolController(IRol rol)
        {
            _rol = rol;
        }

        [HttpGet("GetRol")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetRol()
        {
            var response = await _rol.GetRol();
            return Ok(response);
        }

        [HttpPost("PostRol")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostRol([FromBody] Rol rol)
        {
            try
            {
                var response = await _rol.PostRol(rol);
                if (response == true)
                    return Ok("Se ha agregado una Rol correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutRol/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutRol( int id, [FromBody] Rol rol)
        {
            try
            {
                var response = await _rol.PutRol(rol);
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

        [HttpDelete("DeleteRol/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRol(int id)
        {
            try
            {
                // Obtener la lista de roles
                var rolList = await _rol.GetRol();
                var exists = rolList.Any(a => a.Id == id);

                // Verificar si el recurso existe
                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llamar al método de eliminación con solo el id
                var response = await _rol.DeleteRol(id);

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
