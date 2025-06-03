using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para la gestión de cupones en el sistema E-Commerce.
    /// </summary>
    [Route("api/Cupones")]
    [ApiController]
    public class CuponesController : ControllerBase
    {
        private readonly ICupones _cupones;

        /// <summary>
        /// Constructor que inyecta el repositorio de cupones.
        /// </summary>
        /// <param name="cupones">Interfaz del repositorio de cupones.</param>
        public CuponesController(ICupones cupones)
        {
            _cupones = cupones;
        }

        /// <summary>
        /// Obtiene todos los cupones registrados.
        /// </summary>
        /// <returns>Lista de cupones.</returns>
        [HttpGet("GetCupones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCupones()
        {
            var response = await _cupones.GetCupones();
            return Ok(response);
        }

        /// <summary>
        /// Registra un nuevo cupón en el sistema.
        /// </summary>
        /// <param name="cupones">Objeto con los datos del cupón.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpPost("PostCupones")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostCupones([FromBody] Cupones cupones)
        {
            try
            {
                var response = await _cupones.PostCupones(cupones);
                if (response == true)
                    return Ok("Cupon Agregado correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un cupón existente.
        /// </summary>
        /// <param name="cupones">Objeto cupón con la información actualizada.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpPut("PutCupones/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutComentarios([FromBody] Cupones cupones)
        {
            try
            {
                var response = await _cupones.PutCupones(cupones);
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
        /// Elimina un cupón por su ID.
        /// </summary>
        /// <param name="id">ID del cupón a eliminar.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpDelete("DeleteCupones/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCupones(int id)
        {
            try
            {
                var cuponesList = await _cupones.GetCupones();
                var exists = cuponesList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _cupones.DeleteCupones(id);

                if (response)
                    return Ok("El cupón ha sido eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
