﻿using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/TrackingEnvio")]
    [ApiController]
    public class TrackingEnvioController : ControllerBase
    {
        private readonly ITrackingEnvio _trackingEnvio;
        public TrackingEnvioController(ITrackingEnvio trackingEnvio)
        {
            _trackingEnvio = trackingEnvio;
        }


        [HttpGet("GetTrackinEnvio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetTicketsSoporte()
        {
            var response = await _trackingEnvio.GetTrackingEnvio();
            return Ok(response);
        }

        [HttpPost("PostTrackingEnvio")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostTrackingEnvio([FromBody]  TrackingEnvio trackingEnvio)
        {
            try
            {
                var response = await _trackingEnvio.PostTrackingEnvio(trackingEnvio);
                if (response == true)
                    return Ok("Se ha agregado un Envio Tracking correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutTrackingEnvio/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutTrackingEnvio( int id, [FromBody] TrackingEnvio trackingEnvio)
        {
            try
            {
                var response = await _trackingEnvio.PutTrackingEnvio(trackingEnvio);
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

        [HttpDelete("DeleteTrackingEnvio/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTrackingEnvio(int id)
        {
            try
            {
                // Verificar si el TrackingEnvio existe
                var trackingEnvioList = await _trackingEnvio.GetTrackingEnvio();
                var exists = trackingEnvioList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llamar al repositorio para eliminar el TrackingEnvio
                var response = await _trackingEnvio.DeleteTrackingEnvio(id);

                if (response)
                    return Ok("TrackingEnvio eliminado correctamente.");
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
