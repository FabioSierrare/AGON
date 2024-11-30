using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("Api/Controllers")]
    [ApiController]
    public class DetallesPedidosController : ControllerBase
    {
        private readonly IDetallesPedidos _detalles;
        public DetallesPedidosController(IDetallesPedidos detalles)
        {
            _detalles = detalles;
        }

        [HttpGet("GetDetallesPedidos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetDetallesPedidos()
        {
            var response = await _detalles.GetDetallesPedidos();
            return Ok(response);
        }

        [HttpPost("PostDetallesPedidos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostDetallesPedidos([FromBody]  DetallesPedidos detallesPedidos)
        {
            try
            {
                var response = await _detalles.PostDetallesPedidos(detallesPedidos);
                if (response == true)
                    return Ok("Detalle del pedido agregado correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("PutDestallesPedidos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutDetallesPedidos(int id, [FromBody] DetallesPedidos detallesPedidos)
        {
            if (detallesPedidos == null || detallesPedidos.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var detallesPedidosList = await _detalles.GetDetallesPedidos();
                var exists = detallesPedidosList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _detalles.PutDetallesPedidos(detallesPedidos);

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

        [HttpDelete("DeleteDesllesPedidos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletDetallesPedidos(int id, [FromBody] DetallesPedidos detallesPedidos)
        {
            if (detallesPedidos == null || detallesPedidos.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var detallesPedidosList = await _detalles.GetDetallesPedidos();
                var exists = detallesPedidosList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _detalles.DeleteDetallesPedidos(detallesPedidos);

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
