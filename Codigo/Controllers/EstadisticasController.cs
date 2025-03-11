using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    [Route("api/Estadisticas")]
    [ApiController]
    public class EstadisticasController : ControllerBase
    {

        private readonly IEstadisticas _Estadisticas;
        public EstadisticasController(IEstadisticas estadisticas)
        {
            _Estadisticas = estadisticas;
        }

        [HttpGet("GetVentasUltimasSemanas/{idVendedor}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetVentasUltimasSemanas(int idVendedor)
        {
            var response = await _Estadisticas.GetVentasUltimasSemanas(idVendedor);
            return Ok(response);
        }

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
