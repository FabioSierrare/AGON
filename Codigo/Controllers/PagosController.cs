using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para gestionar los pagos dentro del sistema.
    /// </summary>
    [Route("api/Pagos")]
    [ApiController]
    public class PagosController : Controller
    {
        private readonly IPagos _Pagos;

        /// <summary>
        /// Constructor que inyecta el repositorio de pagos.
        /// </summary>
        /// <param name="Pagos">Interfaz del repositorio de pagos</param>
        public PagosController(IPagos Pagos)
        {
            _Pagos = Pagos;
        }

        /// <summary>
        /// Obtiene la lista de todos los pagos registrados.
        /// </summary>
        /// <returns>Lista de pagos</returns>
        [HttpGet("GetPagos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetPagos()
        {
            var response = await _Pagos.GetPagos();
            return Ok(response);
        }

        /// <summary>
        /// Agrega un nuevo registro de pago.
        /// </summary>
        /// <param name="pagos">Objeto de tipo Pagos</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPost("PostPagos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostPagos([FromBody] Pagos pagos)
        {
            try
            {
                var response = await _Pagos.PostPagos(pagos);
                if (response == true)
                    return Ok("Se ha agregado un pago correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza la información de un pago existente.
        /// </summary>
        /// <param name="id">ID del pago</param>
        /// <param name="pagos">Objeto de tipo Pagos con los datos actualizados</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPut("PutPagos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutPagos(int id, [FromBody] Pagos pagos)
        {
            try
            {
                var response = await _Pagos.PutPagos(pagos);
                if (response)
                    return Ok("Pago actualizado correctamente.");
                else
                    return NotFound("Pago no encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Elimina un registro de pago por su ID.
        /// </summary>
        /// <param name="id">ID del pago</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete("DeletePagos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePagos(int id)
        {
            try
            {
                var pagosList = await _Pagos.GetPagos();
                var exists = pagosList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _Pagos.DeletePagos(id);

                if (response)
                    return Ok("Pago eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el pago.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }
    }
}
