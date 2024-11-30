using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class EmpresasEnvioController : Controller
    {
        private readonly IEmpresasEnvio _empresasEnvio;
        public EmpresasEnvioController(IEmpresasEnvio empresasEnvio)
        {
            _empresasEnvio = empresasEnvio;
        }

        [HttpGet("GetEmpresasEnvios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetEmpresasEnvios()
        {
            var response = await _empresasEnvio.GetEmpresasEnvios();
            return Ok(response);
        }

        [HttpPost("PostEmpresasEnvios")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostEmpresasEnvios([FromBody]  EmpresasEnvio empresasEnvio)
        {
            try
            {
                var response = await _empresasEnvio.PostEmpresasEnvios(empresasEnvio);
                if (response == true)
                    return Ok("La Empresa del Envio fue agregada correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("PutEmpresasEnvios/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutEmpresasEnvios(int id, [FromBody] EmpresasEnvio empresasEnvio)
        {
            if (empresasEnvio == null || empresasEnvio.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var empresaEnvioList = await _empresasEnvio.GetEmpresasEnvios();
                var exists = empresaEnvioList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _empresasEnvio.PutEmpresasEnvios(empresasEnvio);

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

        [HttpDelete("DeleteEmpresasEnvio/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEmpresasEnvio(int id, [FromBody] EmpresasEnvio empresasEnvio)
        {
            if (empresasEnvio == null || empresasEnvio.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var empresasEnvioList = await _empresasEnvio.GetEmpresasEnvios();
                var exists = empresasEnvioList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _empresasEnvio.DeleteEmpresasEnvios(empresasEnvio);

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
