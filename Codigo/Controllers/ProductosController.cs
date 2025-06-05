using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para la gestión de productos dentro del sistema.
    /// </summary>
    [Route("api/Productos")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductos _productos;

        /// <summary>
        /// Constructor que inyecta el repositorio de productos.
        /// </summary>
        /// <param name="productos">Interfaz del repositorio de productos</param>
        public ProductosController(IProductos productos)
        {
            _productos = productos;
        }

        /// <summary>
        /// Obtiene la lista de todos los productos.
        /// </summary>
        /// <returns>Lista de productos</returns>
        [HttpGet("GetProductos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProductos()
        {
            var response = await _productos.GetProductos();
            return Ok(response);
        }

        /// <summary>
        /// Realiza una búsqueda de productos por término.
        /// </summary>
        /// <param name="busqueda">Término de búsqueda</param>
        /// <returns>Lista de productos encontrados</returns>
        [HttpGet("GetBusqueda")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetBusqueda([FromQuery] string? palabra = null, [FromQuery] int? categoriaId = null, [FromQuery] string? descripcion = null, [FromQuery] decimal? precioMin = null, [FromQuery] decimal? precioMax = null)
        {
            var response = await _productos.GetBusqueda(palabra, categoriaId, descripcion, precioMin, precioMax);
            return Ok(response);
        }

        /// <summary>
        /// Obtiene un producto por su ID.
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <returns>Producto correspondiente al ID</returns>
        [HttpGet("GetProducto/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProducto(int id)
        {
            var producto = await _productos.GetProductoById(id);

            if (producto == null)
                return NotFound(new { mensaje = "Producto no encontrado." });

            return Ok(producto);
        }

        /// <summary>
        /// Inserta un nuevo producto.
        /// </summary>
        /// <param name="productos">Objeto producto a insertar</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPost("PostProductos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostProductos([FromBody] Productos productos)
        {
            try
            {
                if (productos == null)
                    return BadRequest(new { mensaje = "El objeto Producto no puede ser nulo." });

                var response = await _productos.PostProductos(productos);

                if (response)
                    return CreatedAtAction(nameof(PostProductos), new { id = productos.Id }, productos);
                else
                    return BadRequest(new { mensaje = "No se pudo agregar el producto, revise los datos." });
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new
                {
                    mensaje = "Error interno del servidor al guardar en la base de datos.",
                    error = ex.InnerException?.Message ?? ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor.", error = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <param name="productos">Objeto con los datos actualizados</param>
        /// <returns>Resultado de la operación</returns>
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
                var inner = ex.InnerException != null ? ex.InnerException.Message : "Sin InnerException";

                return BadRequest(new
                {
                    message = ex.Message,
                    inner = inner,
                    stackTrace = ex.StackTrace
                });
            }
        }

        /// <summary>
        /// Elimina un producto por su ID.
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <returns>Resultado de la operación</returns>
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
