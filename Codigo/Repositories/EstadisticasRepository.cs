using E_Commerce.Models;
using E_Commerce.Context;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Repositories.Interfaces;

/// <summary>
/// Repositorio encargado de obtener estadísticas relacionadas con las ventas y productos.
/// </summary>
public class EstadisticasRepository : IEstadisticas
{
    /// <summary>
    /// Contexto de base de datos.
    /// </summary>
    private readonly E_commerceContext context;

    /// <summary>
    /// Constructor que recibe el contexto de la base de datos.
    /// </summary>
    /// <param name="context">Instancia de E_commerceContext</param>
    public EstadisticasRepository(E_commerceContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Obtiene las ventas de las últimas 4 semanas para un vendedor específico, agrupadas por semana.
    /// </summary>
    /// <param name="idVendedor">ID del vendedor</param>
    /// <returns>Lista de objetos con la semana, año, total de ventas y productos vendidos</returns>
    public async Task<List<object>> GetVentasUltimasSemanas(int idVendedor)
    {
        var cuatroSemanasAtras = DateTime.Now.AddDays(-28);

        var data = await (from p in context.Pedidos
                          where p.FechaPedido >= cuatroSemanasAtras && p.VendedorId == idVendedor
                          group p by new
                          {
                              Semana = EF.Functions.DateDiffWeek(DateTime.MinValue, p.FechaPedido),
                              Año = p.FechaPedido.Year
                          }
                          into grupo
                          select new
                          {
                              Semana = grupo.Key.Semana,
                              Año = grupo.Key.Año,
                              TotalVentas = grupo.Sum(p => p.Total),
                              ProductosVendidos = grupo.Sum(p => p.Cantidad)
                          })
                          .OrderByDescending(x => x.Año)
                          .ThenByDescending(x => x.Semana)
                          .ToListAsync();

        return data.Cast<object>().ToList();
    }

    /// <summary>
    /// Obtiene los productos más vendidos por un vendedor, ordenados por cantidad.
    /// </summary>
    /// <param name="idVendedor">ID del vendedor</param>
    /// <returns>Lista de objetos con nombre del producto y total vendido</returns>
    public async Task<List<object>> GetProductosMasVendidos(int idVendedor)
    {
        var data = await (from pd in context.Pedidos
                          join p in context.Productos on pd.ProductoId equals p.Id
                          where pd.VendedorId == idVendedor
                          group pd by p.Nombre into grupo
                          select new
                          {
                              Producto = grupo.Key,
                              TotalVendido = grupo.Sum(pd => pd.Cantidad)
                          })
                          .OrderByDescending(x => x.TotalVendido)
                          .ToListAsync();

        return data.Cast<object>().ToList();
    }
}
