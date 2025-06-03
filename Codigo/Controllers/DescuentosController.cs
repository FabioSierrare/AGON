using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para la gestión de descuentos (promociones) en el sistema E-Commerce.
    /// </summary>
    [Route("api/Descuentos")]
    [ApiController]
    public class DescuentosController : Controller
    {
        private readonly IDescuentos _descuentos;

        /// <summary>
        /// Constructor que inyecta el repositorio de descuentos.
        /// </summary>
        /// <param name="descuentos">Interfaz del repositorio de descuentos.</param>
        public DescuentosController(IDescuentos descuentos)
        {
            _descuentos = descuentos;
        }

        /// <summary>
        /// Obtiene todos los descuentos registrados en el sistema.
        /// </summary>
        /// <returns>Lista de descuentos.</returns>
        [HttpGet("GetDescuentos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetDescuentos()
        {
            var response = await _descuentos.GetDescuentos();
            return Ok(response);
        }

        /// <summary>
        /// Registra un nuevo descuento o promoción.
        /// </summary>
        /// <param name="promociones">Objeto con los datos del descuento.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpPost("PostDescuentos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostDescuentos([FromBody] Descuentos promociones)
        {
            try
            {
                var response = await _descuentos.PostDescuentos(promociones);
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
        /// Actualiza un descuento existente.
        /// </summary>
        /// <param name="id">ID del descuento a actualizar.</param>
        /// <param name="descuentos">Objeto con los nuevos datos del descuento.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpPut("PutDescuentos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutDescuentos(int id, [FromBody] Descuentos descuentos)
        {
            try
            {
                var response = await _descuentos.PutDescuentos(descuentos);
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
        /// Elimina un descuento por su ID.
        /// </summary>
        /// <param name="id">ID del descuento a eliminar.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpDelete("DeleteDescuentos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteDescuentos(int id)
        {
            try
            {
                var promocionesList = await _descuentos.GetDescuentos();
                var exists = promocionesList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _descuentos.DeleteDescuentos(id);

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
