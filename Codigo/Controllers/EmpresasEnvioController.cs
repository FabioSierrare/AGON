using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/Empresas")]
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
        public async Task<IActionResult> PutEmpresasEnvios([FromBody] EmpresasEnvio empresasEnvio)
        {


            try
            {
                var response = await _empresasEnvio.PutEmpresasEnvios(empresasEnvio);
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

        [HttpDelete("DeleteEmpresasEnvio/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEmpresasEnvio(int id)
        {
            try
            {
                // Obtiene la lista de envíos
                var envioList = await _empresasEnvio.GetEmpresasEnvios();

                // Verifica si el envío con el ID existe
                var exists = envioList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llama al método de eliminación en el repositorio
                var response = await _empresasEnvio.DeleteEmpresasEnvios(id);

                if (response)
                    return Ok("El envío ha sido eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
