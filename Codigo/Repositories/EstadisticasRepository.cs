using E_Commerce.Models;
using E_Commerce.Context;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Repositories.Interfaces;

public class EstadisticasRepository : IEstadisticas
{
    private readonly E_commerceContext context;

    public EstadisticasRepository(E_commerceContext context)
    {
        this.context = context;
    }

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
