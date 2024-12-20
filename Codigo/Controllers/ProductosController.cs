﻿using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
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

        [HttpPost("PostProductos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostProductos([FromBody] Productos productos)
        {
            try
            {
                var response = await _productos.PostProductos(productos);
                if (response == true)
                    return Ok("Se ha agregado un producto correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutProductos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutProductos ( int id, [FromBody] Productos productos)
        {


            try
            {
                var response = await _productos.PutProductos(productos);
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

        [HttpDelete("DeleteProductos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProductos(int id, [FromBody] Productos productos)
        {
            if (productos == null || productos.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var productosList = await _productos.GetProductos();
                var exists = productosList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El producto no existe.");

                // Llamar al método de eliminación con el id
                var response = await _productos.DeleteProductos(id);

                if (response)
                    return Ok("Producto eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el producto.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }
    }
}
