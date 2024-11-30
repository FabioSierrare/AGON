using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class UsuariosNotificadosContoller : Controller
    {
        private readonly IUsuariosNotificados _usuariosNotificados;
        public UsuariosNotificadosContoller(IUsuariosNotificados usuariosNotificados)
        {
            _usuariosNotificados = usuariosNotificados;
        }

        [HttpGet("GetUsuariosNotificados")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUsuariosNotificados()
        {
            var response = await _usuariosNotificados.GetUsuariosNotificados();
            return Ok(response);
        }

        [HttpPost("PostUsuariosNotificados")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostUsuariosNotificados([FromBody] UsuariosNotificados usuariosNotificados)
        {
            try
            {
                var response = await _usuariosNotificados.PostUsuariosNotificados(usuariosNotificados);
                if (response == true)
                    return Ok("Se ha agregado a una Notificacion a los usuarios correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutUsuariosNotificados/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutUsuariosNotificados(int id, [FromBody]UsuariosNotificados usuariosNotificados) 
        {
            if (usuariosNotificados == null || usuariosNotificados.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var trackingEnvioList = await _usuariosNotificados.GetUsuariosNotificados();
                var exists = trackingEnvioList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _usuariosNotificados.PutUsuariosNotificados(usuariosNotificados);

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

        [HttpDelete("DeleteUsuariosNotificados/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUsuariosNotificados(int id, [FromBody] UsuariosNotificados usuariosNotificados)
        {
            if (usuariosNotificados == null || usuariosNotificados.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var trackingEnvioList = await _usuariosNotificados.GetUsuariosNotificados();
                var exists = trackingEnvioList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _usuariosNotificados.DeleteUsuariosNotificados(usuariosNotificados);

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
