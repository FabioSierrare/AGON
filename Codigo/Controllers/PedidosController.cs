using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para la gestión de pedidos dentro del sistema.
    /// </summary>
    [Route("api/Pedidos")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidos _pedidos;

        /// <summary>
        /// Constructor que inyecta el repositorio de pedidos.
        /// </summary>
        /// <param name="pedidos">Interfaz del repositorio de pedidos</param>
        public PedidosController(IPedidos pedidos)
        {
            _pedidos = pedidos;
        }

        /// <summary>
        /// Obtiene la lista de todos los pedidos registrados.
        /// </summary>
        /// <returns>Lista de pedidos</returns>
        [HttpGet("GetPedidos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetPedidos()
        {
            var response = await _pedidos.GetPedidos();
            return Ok(response);
        }

        /// <summary>
        /// Crea un nuevo pedido.
        /// </summary>
        /// <param name="pedidos">Objeto del pedido a crear</param>
        /// <returns>El pedido creado o mensaje de error</returns>
        [HttpPost("PostPedidos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostPedidos([FromBody] Pedidos pedidos)
        {
            try
            {
                var pedidoCreado = await _pedidos.PostPedidos(pedidos);

                if (pedidoCreado != null)
                    return CreatedAtAction(nameof(GetPedidoById), new { id = pedidoCreado.Id }, pedidoCreado);

                return BadRequest("No se pudo crear el pedido");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene un pedido específico por su ID.
        /// </summary>
        /// <param name="id">ID del pedido</param>
        /// <returns>El pedido encontrado o error 404</returns>
        [HttpGet("GetPedidoById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPedidoById(int id)
        {
            var pedido = await _pedidos.GetPedidoById(id);

            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        /// <summary>
        /// Actualiza un pedido existente.
        /// </summary>
        /// <param name="id">ID del pedido</param>
        /// <param name="pedidos">Objeto con los datos actualizados</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPut("PutPedidos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutNotificaciones(int id, [FromBody] Pedidos pedidos)
        {
            try
            {
                var response = await _pedidos.PutPedidos(pedidos);
                if (response)
                    return Ok("Pedido actualizado correctamente.");
                else
                    return NotFound("Pedido no encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Elimina un pedido por su ID.
        /// </summary>
        /// <param name="id">ID del pedido</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete("DeletePedidos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePedidos(int id)
        {
            try
            {
                var pedidosList = await _pedidos.GetPedidos();
                var exists = pedidosList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _pedidos.DeletePedidos(id);

                if (response)
                    return Ok("Pedido eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el pedido.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }

        /// <summary>
        /// Obtiene los ingresos generados por día.
        /// </summary>
        /// <returns>Lista de ingresos por día</returns>
        [HttpGet("GetIngresosPorDia")]
        public async Task<IActionResult> GetIngresosPorDia()
        {
            var ingresos = await _pedidos.GetIngresosPorDia();
            return Ok(ingresos);
        }

        /// <summary>
        /// Obtiene los productos más vendidos.
        /// </summary>
        /// <returns>Lista de productos más vendidos</returns>
        [HttpGet("GetProductosMasVendidos")]
        public async Task<IActionResult> GetProductosMasVendidos()
        {
            var productos = await _pedidos.GetProductosMasVendidos();
            return Ok(productos);
        }
    }
}
