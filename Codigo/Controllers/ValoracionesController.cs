using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con valoraciones de productos.
    /// </summary>
    [Route("api/Valoraciones")]
    [ApiController]
    public class ValoracionesController : ControllerBase
    {
        private readonly IValoraciones _valoraciones;

        /// <summary>
        /// Constructor que inyecta el repositorio de valoraciones.
        /// </summary>
        /// <param name="valoraciones">Repositorio de valoraciones</param>
        public ValoracionesController(IValoraciones valoraciones)
        {
            _valoraciones = valoraciones;
        }

        /// <summary>
        /// Obtiene la lista de todas las valoraciones.
        /// </summary>
        /// <returns>Lista de valoraciones</returns>
        [HttpGet("GetValoraciones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetValoraciones()
        {
            var response = await _valoraciones.GetValoraciones();
            return Ok(response);
        }

        /// <summary>
        /// Crea una nueva valoración.
        /// </summary>
        /// <param name="valoraciones">Objeto de valoración</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPost("PostValoraciones")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostValoraciones([FromBody] Valoraciones valoraciones)
        {
            try
            {
                var response = await _valoraciones.PostValoraciones(valoraciones);
                if (response == true)
                    return Ok("Se ha agregado a una Valoracion correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza una valoración existente.
        /// </summary>
        /// <param name="id">ID de la valoración</param>
        /// <param name="valoraciones">Objeto de valoración actualizado</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPut("PutValoraciones/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutValoraciones(int id, [FromBody] Valoraciones valoraciones)
        {
            try
            {
                var response = await _valoraciones.PutValoraciones(valoraciones);
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
        /// Elimina una valoración por su ID.
        /// </summary>
        /// <param name="id">ID de la valoración a eliminar</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete("DeleteValoraciones/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteValoraciones(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El ID proporcionado no es válido.");
            }

            try
            {
                var deleted = await _valoraciones.DeleteValoraciones(id);

                if (deleted)
                {
                    return Ok("Valoración eliminada correctamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar el recurso.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno: {ex.Message}");
            }
        }
    }
}
