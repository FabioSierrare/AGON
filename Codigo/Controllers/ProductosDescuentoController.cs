using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para la gestión de productos con descuentos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosDescuentoController : Controller
    {
        private readonly IProductosDescuento _promociones;
        private readonly IPromociones _promos;

        /// <summary>
        /// Constructor del controlador que inyecta las dependencias de productos y promociones.
        /// </summary>
        public ProductosDescuentoController(IProductosDescuento promociones, IPromociones promos)
        {
            _promociones = promociones;
            _promos = promos;
        }

        /// <summary>
        /// Obtiene todos los productos con descuento.
        /// </summary>
        /// <returns>Lista de productos con descuento</returns>
        [HttpGet("GetProductosDescuento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProductosDescuento()
        {
            var response = await _promociones.GetProductosDescuento();
            return Ok(response);
        }

        /// <summary>
        /// Obtiene los productos con descuentos exactos desde el repositorio de promociones.
        /// </summary>
        /// <returns>Lista de productos con descuento</returns>
        [HttpGet("GetProductosDescuentosExacto")]
        public async Task<IActionResult> GetProductosDescuentosExacto()
        {
            var productosDescuento = await _promos.GetProductosDescuento();
            return Ok(productosDescuento);
        }

        /// <summary>
        /// Agrega un nuevo producto con descuento.
        /// </summary>
        /// <param name="promociones">Objeto con los datos del producto con descuento</param>
        /// <returns>Resultado de la operación</returns>
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

        /// <summary>
        /// Actualiza un producto con descuento existente.
        /// </summary>
        /// <param name="id">ID del producto con descuento</param>
        /// <param name="promociones">Datos actualizados del producto con descuento</param>
        /// <returns>Resultado de la operación</returns>
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

        /// <summary>
        /// Elimina un producto con descuento por su ID.
        /// </summary>
        /// <param name="id">ID del producto con descuento</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete("DeleteProductosDescuento/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProductosDescuento(int id)
        {
            try
            {
                var promocionesList = await _promociones.GetProductosDescuento();
                var exists = promocionesList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _promociones.DeleteProductosDescuento(id);

                if (response)
                    return Ok("Recurso eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }
    }
}
