﻿using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    [Route("api/Pedidos")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidos _pedidos;
        public PedidosController(IPedidos pedidos)
        {
            _pedidos = pedidos;
        }

        [HttpGet("GetPedidos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetPedidos()
        {
            var response = await _pedidos.GetPedidos();
            return Ok(response);
        }

        [HttpPost("PostPedidos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostPedidos([FromBody] Pedidos pedidos)
        {
            try
            {
                var pedidoCreado = await _pedidos.PostPedidos(pedidos); // Devuelve el pedido, no un bool

                if (pedidoCreado != null)
                    return CreatedAtAction(nameof(GetPedidoById), new { id = pedidoCreado.Id }, pedidoCreado);

                return BadRequest("No se pudo crear el pedido");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPedidoById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPedidoById(int id)
        {
            var pedido = await _pedidos.GetPedidoById(id); // Este sí puede usar _pedidos porque estás usando el repositorio

            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }



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
                    return Ok("Comentario actualizado correctamente.");
                else
                    return NotFound("Comentario no encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeletePedidos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePedidos(int id)
        {
            try
            {
                // Obtener la lista de pedidos
                var pedidosList = await _pedidos.GetPedidos();
                var exists = pedidosList.Any(a => a.Id == id);

                // Verificar si el recurso existe
                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llamar al método de eliminación con solo el id
                var response = await _pedidos.DeletePedidos(id);

                // Verificar si la eliminación fue exitosa
                if (response)
                    return Ok("Pedido eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el pedido.");
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }

        [HttpGet("GetIngresosPorDia")]
        public async Task<IActionResult> GetIngresosPorDia()
        {
            var ingresos = await _pedidos.GetIngresosPorDia();
            return Ok(ingresos);
        }

        [HttpGet("GetProductosMasVendidos")]
        public async Task<IActionResult> GetProductosMasVendidos()
        {
            var productos = await _pedidos.GetProductosMasVendidos();
            return Ok(productos);
        }
    }
}
