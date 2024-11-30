using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/Controllers")]
    [ApiController]
    public class CuponesController : ControllerBase
    {
        private readonly ICupones _cupones;
        public CuponesController(ICupones cupones)
        {
            _cupones = cupones;
        }

        [HttpGet("GetCupones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCupones()
        {
            var response = await _cupones.GetCupones();
            return Ok(response);
        }

        [HttpPost("PostCupones")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostCupones([FromBody] Cupones cupones)
        {
            try
            {
                var response = await _cupones.PostCupones(cupones);
                if (response == true)
                    return Ok("Cupon Agregado correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("PutCupones/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutCupones(int id, [FromBody] Cupones cupones)
        {
            if (cupones == null || cupones.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var categoriasList = await _cupones.GetCupones();
                var exists = categoriasList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _cupones.PutCupones(cupones);

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

        [HttpDelete("DeleteCupones/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletCupones(int id, [FromBody] Cupones cupones)
        {
            if (cupones == null || cupones.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var cuponesList = await _cupones.GetCupones();
                var exists = cuponesList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _cupones.DeleteCupones(cupones);

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