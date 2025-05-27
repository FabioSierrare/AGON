using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/Pagos")]
    [ApiController]
    public class PagosController : Controller
    {
        private readonly IPagos _Pagos;
        public PagosController(IPagos Pagos)
        {
            _Pagos = Pagos;
        }

        [HttpGet("GetPagos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetPagos()
        {
            var response = await _Pagos.GetPagos();
            return Ok(response);
        }

        [HttpPost("PostPagos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostPagos([FromBody] Pagos pagos)
        {
            try
            {
                var response = await _Pagos.PostPagos(pagos);
                if (response == true)
                    return Ok("Se ha agregado una notifiacacion correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("PutPagos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutPagos(int id, [FromBody] Pagos pagos)
        {


            try
            {
                var response = await _Pagos.PutPagos(pagos);
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

        [HttpDelete("DeletePagos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePagos(int id)
        {
            try
            {
                // Obtener la lista de logs del sistema
                var logsSistemaList = await _Pagos.GetPagos();
                var exists = logsSistemaList.Any(a => a.Id == id);

                // Verificar si el recurso existe
                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llamar al método de eliminación con solo el id
                var response = await _Pagos.DeletePagos(id);

                // Verificar si la eliminación fue exitosa
                if (response)
                    return Ok(" eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el log.");
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }

    }
}