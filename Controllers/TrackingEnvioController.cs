using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class TrackingEnvioController : ControllerBase
    {
        private readonly ITrackingEnvio _trackingEnvio;
        public TrackingEnvioController(ITrackingEnvio trackingEnvio)
        {
            _trackingEnvio = trackingEnvio;
        }

        [HttpGet("GetTrackingEnvio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetTrackingEnvio()
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
            if (trackingEnvio == null || trackingEnvio.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var trackingEnvioList = await _trackingEnvio.GetTrackingEnvio();
                var exists = trackingEnvioList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _trackingEnvio.PutTrackingEnvio(trackingEnvio);

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

        [HttpDelete("DeleteTrackingEnvio/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTrackingEnvio(int id, [FromBody] TrackingEnvio trackingEnvio)
        {
            if (trackingEnvio == null || trackingEnvio.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var trackingEnvioList = await _trackingEnvio.GetTrackingEnvio();
                var exists = trackingEnvioList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _trackingEnvio.DeleteTrackingEnvio(trackingEnvio);

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
