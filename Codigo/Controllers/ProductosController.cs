using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace E_Commerce.Controllers
{
    [Route("api/Productos")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductos _productos;
        public ProductosController(IProductos productos)
        {
            _productos = productos;
        }

        [HttpGet("GetProductos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProductos()
        {
            var response = await _productos.GetProductos();
            return Ok(response);
        }

        [HttpGet("GetProducto/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProducto(int id)
        {
            var producto = await _productos.GetProductoById(id); // Este método debería estar implementado en tu repositorio.

            if (producto == null)
            {
                return NotFound(new { mensaje = "Producto no encontrado." });
            }

            return Ok(producto); // Devuelve el producto si se encuentra.
        }


        [HttpPost("PostProductos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostProductos([FromBody] Productos productos)
        {
            try
            {
                if (productos == null)
                {
                    return BadRequest(new { mensaje = "El objeto Producto no puede ser nulo." });
                }

                var response = await _productos.PostProductos(productos);

                if (response)
                {
                    return CreatedAtAction(nameof(PostProductos), new { id = productos.Id }, productos);
                }
                else
                {
                    return BadRequest(new { mensaje = "No se pudo agregar el producto, revise los datos." });
                }
            }
            catch (DbUpdateException ex)  // Captura errores de EF
            {
                return StatusCode(500, new
                {
                    mensaje = "Error interno del servidor al guardar en la base de datos.",
                    error = ex.InnerException?.Message ?? ex.Message  // Captura la causa real
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    mensaje = "Error interno del servidor.",
                    error = ex.Message
                });
            }
        }

        [HttpPut("PutProductos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutProductos(int id, [FromBody] Productos productos)
        {
            try
            {
                var response = await _productos.PutProductos(productos);

                if (response)
                    return Ok("Producto actualizado correctamente.");
                else
                    return NotFound("Producto no encontrado.");
            }
            catch (Exception ex)
            {
                // Extraer detalles del inner exception si existe
                var inner = ex.InnerException != null ? ex.InnerException.Message : "Sin InnerException";

                return BadRequest(new
                {
                    message = ex.Message,
                    inner = inner,
                    stackTrace = ex.StackTrace
                });
            }
        }


        [HttpDelete("DeleteProductos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProductos(int id)
        {
            try
            {
                var productosList = await _productos.GetProductos();
                var exists = productosList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound($"El producto con ID {id} no existe.");

                // Llamar al método de eliminación con el id
                var response = await _productos.DeleteProductos(id);

                if (response)
                    return Ok($"Producto con ID {id} eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el producto.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno: {ex.Message}");
            }
        }

    }
}