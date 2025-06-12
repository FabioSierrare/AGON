using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para gestionar las categorías del sistema E-Commerce.
    /// Permite obtener, crear, actualizar y eliminar categorías.
    /// </summary>
    [Route("api/Categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoria _categoria;

        /// <summary>
        /// Constructor que inyecta el repositorio de categorías.
        /// </summary>
        /// <param name="categoria">Interfaz del repositorio de categorías.</param>
        public CategoriasController(ICategoria categoria)
        {
            _categoria = categoria;
        }

        /// <summary>
        /// Obtiene todas las categorías disponibles.
        /// </summary>
        /// <returns>Lista de categorías.</returns>
        [HttpGet("GetCategoria")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCategoria()
        {
            var response = await _categoria.GetCategoria();
            return Ok(response);
        }

        /// <summary>
        /// Crea una nueva categoría.
        /// </summary>
        /// <param name="categoria">Objeto Categorias con los datos a insertar.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpPost("PostCategoria")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostCategoria([FromBody] Categorias categoria)
        {
            try
            {
                var response = await _categoria.PostCategoria(categoria);
                if (response == true)
                    return Ok("Categoria Insertada correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza una categoría existente.
        /// </summary>
        /// <param name="categoria">Objeto Categorias con los datos actualizados.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpPut("PutCategoria/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAdministrador([FromBody] Categorias categoria)
        {
            try
            {
                var response = await _categoria.PutCategoria(categoria);
                if (response)
                    return Ok("Categoria actualizado correctamente.");
                else
                    return NotFound("Categoria no encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los productos filtrados por categoría.
        /// </summary>
        /// <param name="id">ID de la categoría.</param>
        /// <returns>Lista de productos pertenecientes a la categoría.</returns>
        [HttpGet("GetPorCategoria/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPorCategoria(int id)
        {
            try
            {
                var productos = await _categoria.GetProductosPorCategoria(id);

                if (productos == null || productos.Count == 0)
                    return NotFound("No se encontraron productos para esta categoría.");

                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno: {ex.Message}");
            }
        }


        /// <summary>
        /// Elimina una categoría por su ID.
        /// </summary>
        /// <param name="id">ID de la categoría a eliminar.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpDelete("DeleteCategoria/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCategorias(int id)
        {
            try
            {
                var response = await _categoria.DeleteCategoria(id);

                if (response)
                    return Ok("Categoría eliminada con éxito.");
                else
                    return NotFound("La categoría no fue encontrada.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}