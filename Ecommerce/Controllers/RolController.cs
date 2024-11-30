using E_Commerce.Models;
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
            if (rol == null || rol.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var rolList = await _rol.GetRol();
                var exists = rolList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _rol.PutRol(rol);

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

        [HttpDelete("DeleteRol/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRol(int id, [FromBody] Rol rol)
        {
            if (rol == null || rol.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var rolList = await _rol.GetRol();
                var exists = rolList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _rol.DeleteRol(rol);

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
