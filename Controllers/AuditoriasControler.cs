using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using E_Commerce.Repositories.Interfaces;
using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]

    public class AuditoriasControler : ControllerBase
    {
        private readonly IAuditorias _auditorias;
        public AuditoriasControler(IAuditorias auditorias)
        {
            _auditorias = auditorias;
        }

        [HttpGet("GetAuditorias")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAuditorias()
        {
            var response = await _auditorias.GetAuditorias();
            return Ok(response);
        }

        [HttpPost("PostAuditorias")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAuditorias([FromBody] Auditorias auditorias)
        {
            try
            {
                var response = await _auditorias.PostAuditorias(auditorias);
                if (response == true)
                    return Ok("Insertado correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutAuditorias/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutAuditorias(int id, [FromBody] Auditorias auditorias)
        {
            if (auditorias == null || auditorias.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var auditoriasList = await _auditorias.GetAuditorias();
                var exists = auditoriasList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _auditorias.PutAuditorias(auditorias);

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

        [HttpDelete("DeleteAuditorias/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAuditorias(int id, [FromBody] Auditorias auditorias)
        {
            if (auditorias == null || auditorias.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var auditoriasList = await _auditorias.GetAuditorias();
                var exists = auditoriasList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _auditorias.DeleteAuditorias(auditorias);

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


