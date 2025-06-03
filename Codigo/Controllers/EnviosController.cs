using E_Commerce.Models;
using E_Commerce.Repositories;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para manejar operaciones relacionadas con los envíos.
    /// </summary>
    [Route("api/Envios")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        private readonly IEnvios _envios;

        /// <summary>
        /// Constructor que inyecta la dependencia del repositorio de envíos.
        /// </summary>
        /// <param name="envios">Interfaz del repositorio de envíos.</param>
        public EnviosController(IEnvios envios)
        {
            _envios = envios;
        }

        /// <summary>
        /// Obtiene todos los registros de envíos.
        /// </summary>
        /// <returns>Lista de envíos.</returns>
        [HttpGet("GetEnvios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetEnvios()
        {
            var response = await _envios.GetEnvios();
            return Ok(response);
        }

        /// <summary>
        /// Crea un nuevo envío.
        /// </summary>
        /// <param name="envios">Objeto de tipo Envios.</param>
        /// <returns>Mensaje de confirmación o error.</returns>
        [HttpPost("PostEnvios")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostEnvios([FromBody] Envios envios)
        {
            try
            {
                var response = await _envios.PostEnvios(envios);
                if (response == true)
                    return Ok("El envio a sido agregado correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza la información de un envío existente.
        /// </summary>
        /// <param name="envio">Objeto con la información del envío.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpPut("PutEnvios/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutEnvios([FromBody] Envios envio)
        {
            try
            {
                var response = await _envios.PutEnvios(envio);
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
        /// Elimina un envío por su ID.
        /// </summary>
        /// <param name="id">ID del envío.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpDelete("DeleteEnvio/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEnvio(int id)
        {
            try
            {
                // Obtiene la lista de envíos
                var envioList = await _envios.GetEnvios();

                // Verifica si el envío con el ID existe
                var exists = envioList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llama al método de eliminación en el repositorio
                var response = await _envios.DeleteEnvios(id);

                if (response)
                    return Ok("El envío ha sido eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Obtiene envíos filtrados por ID del vendedor.
        /// </summary>
        /// <param name="idVendedor">ID del vendedor.</param>
        /// <returns>Lista de envíos filtrados.</returns>
        [HttpGet("GetEnviosFiltrados/{idVendedor}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetEnviosFiltrados(int idVendedor)
        {
            var response = await _envios.GetEnviosFiltrados(idVendedor);
            return Ok(response);
        }
    }
}
