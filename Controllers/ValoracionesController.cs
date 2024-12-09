﻿using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class ValoracionesController : ControllerBase
    {
        private readonly IValoraciones _valoraciones;
        public ValoracionesController(IValoraciones valoraciones)
        {
            _valoraciones = valoraciones;
        }

        [HttpGet("GetValoraciones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetValoraciones()
        {
            var response = await _valoraciones.GetValoraciones();
            return Ok(response);
        }

        [HttpPost("PostValoraciones")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostValoraciones([FromBody] Valoraciones valoraciones)
        {
            try
            {
                var response = await _valoraciones.PostValoraciones(valoraciones);
                if (response == true)
                    return Ok("Se ha agregado a una Valoracion correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutValoraciones/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutValoraciones(int id, [FromBody] Valoraciones valoraciones)
        {
            try
            {
                var response = await _valoraciones.PutValoraciones(valoraciones);
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

        [HttpDelete("DeleteValoraciones/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteValoraciones(int id)
        {
            try
            {
                // Verificar si la valoración existe
                var trackingEnvioList = await _valoraciones.GetValoraciones();
                var exists = trackingEnvioList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llamar al repositorio para eliminar la valoración
                var response = await _valoraciones.DeleteValoraciones(id);

                if (response)
                    return Ok("Valoración eliminada correctamente.");
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

