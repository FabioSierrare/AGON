using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador encargado de gestionar las operaciones CRUD sobre los detalles de pedidos.
    /// </summary>
    [Route("Api/DetallesPedidos")]
    [ApiController]
    public class DetallesPedidosController : ControllerBase
    {
        private readonly IDetallesPedidos _detalles;

        /// <summary>
        /// Constructor que inyecta la dependencia del repositorio de detalles de pedidos.
        /// </summary>
        /// <param name="detalles">Interfaz del repositorio de detalles de pedidos</param>
        public DetallesPedidosController(IDetallesPedidos detalles)
        {
            _detalles = detalles;
        }

        /// <summary>
        /// Obtiene todos los detalles de pedidos.
        /// </summary>
        /// <returns>Una lista de detalles de pedidos.</returns>
        [HttpGet("GetDetallesPedidos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetDetallesPedidos()
        {
            var response = await _detalles.GetDetallesPedidos();
            return Ok(response);
        }

        /// <summary>
        /// Inserta un nuevo detalle de pedido.
        /// </summary>
        /// <param name="detallesPedidos">Objeto DetallesPedidos a insertar</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPost("PostDetallesPedidos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostDetallesPedidos([FromBody] DetallesPedidos detallesPedidos)
        {
            try
            {
                var response = await _detalles.PostDetallesPedidos(detallesPedidos);
                if (response == true)
                    return Ok("Detalle del pedido agregado correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un detalle de pedido existente.
        /// </summary>
        /// <param name="detallespedidos">Objeto con la información actualizada</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPut("PutDetallesPedidos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutComentarios([FromBody] DetallesPedidos detallespedidos)
        {
            try
            {
                var response = await _detalles.PutDetallesPedidos(detallespedidos);
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
        /// Elimina un detalle de pedido por ID.
        /// </summary>
        /// <param name="id">ID del detalle de pedido a eliminar</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpDelete("DeleteDetallesPedidos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteDetallesPedidos(int id)
        {
            try
            {
                // Obtiene la lista de detalles de pedidos
                var detallesPedidosList = await _detalles.GetDetallesPedidos();

                // Verifica si el detalle de pedido con el ID existe
                var exists = detallesPedidosList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llama al método de eliminación en el repositorio
                var response = await _detalles.DeleteDetallesPedidos(id);

                if (response)
                    return Ok("El detalle del pedido ha sido eliminado correctamente.");
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
