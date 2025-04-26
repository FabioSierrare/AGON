using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosDescuentoController : Controller
    {
        private readonly IProductosDescuento _promociones;
        private readonly IPromociones _promos;


        public ProductosDescuentoController(IProductosDescuento promociones, IPromociones promos)
        {
            _promociones = promociones;
            _promos = promos;
        }

        [HttpGet("GetProductosDescuento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProductosDescuento()
        {
            var response = await _promociones.GetProductosDescuento();
            return Ok(response);
        }

        [HttpGet("GetProductosDescuentosExacto")]
        public async Task<IActionResult> GetProductosDescuentosExacto()
        {
            var productosDescuento = await _promos.GetProductosDescuento();
            return Ok(productosDescuento);
        }

        [HttpPost("PostProductosDescuento")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostProductosDescuento([FromBody] ProductosDescuento promociones)
        {
            try
            {
                var response = await _promociones.PostProductosDescuento(promociones);
                if (response == true)
                    return Ok("Se ha agregado una promocion correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutProductosDescuento/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutProductosDescuento(int id, [FromBody] ProductosDescuento promociones)
        {


            try
            {
                var response = await _promociones.PutProductosDescuento(promociones);
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

        [HttpDelete("DeleteProductosDescuento/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProductosDescuento(int id)
        {
            try
            {
                // Obtener la lista de promociones
                var promocionesList = await _promociones.GetProductosDescuento();
                var exists = promocionesList.Any(a => a.Id == id);

                // Verificar si el recurso existe
                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llamar al método de eliminación con solo el id
                var response = await _promociones.DeleteProductosDescuento(id);

                // Verificar si la eliminación fue exitosa
                if (response)
                    return Ok("Recurso eliminado correctamente.");
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
