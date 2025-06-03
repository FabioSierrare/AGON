using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para operaciones relacionadas con estadísticas de ventas.
    /// </summary>
    [Route("api/Estadisticas")]
    [ApiController]
    public class EstadisticasController : ControllerBase
    {
        private readonly IEstadisticas _Estadisticas;

        /// <summary>
        /// Constructor que inyecta la dependencia del repositorio de estadísticas.
        /// </summary>
        /// <param name="estadisticas">Repositorio de estadísticas</param>
        public EstadisticasController(IEstadisticas estadisticas)
        {
            _Estadisticas = estadisticas;
        }

        /// <summary>
        /// Obtiene las ventas realizadas en las últimas semanas por un vendedor.
        /// </summary>
        /// <param name="idVendedor">ID del vendedor</param>
        /// <returns>Lista con las estadísticas de ventas por semana</returns>
        [HttpGet("GetVentasUltimasSemanas/{idVendedor}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetVentasUltimasSemanas(int idVendedor)
        {
            var response = await _Estadisticas.GetVentasUltimasSemanas(idVendedor);
            return Ok(response);
        }

        /// <summary>
        /// Obtiene los productos más vendidos de un vendedor.
        /// </summary>
        /// <param name="idVendedor">ID del vendedor</param>
        /// <returns>Lista de productos más vendidos</returns>
        [HttpGet("GetProductosMasVendidos/{idVendedor}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProductosMasVendidos(int idVendedor)
        {
            var response = await _Estadisticas.GetProductosMasVendidos(idVendedor);
            return Ok(response);
        }
    }
}
