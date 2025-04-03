using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class PedidosRepository : IPedidos
    {
        private readonly E_commerceContext context;

        public PedidosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Pedidos>> GetPedidos()
        {
            var data = await context.Pedidos.ToListAsync();
            return data;
        }

        public async Task<bool> PostPedidos(Pedidos pedidos)
        {
            await context.Pedidos.AddAsync(pedidos);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutPedidos(Pedidos pedidos)
        {
            context.Pedidos.Update(pedidos);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeletePedidos(int id)
        {
            var pedidos = await context.Pedidos.FindAsync(id);
            if (pedidos == null) return false;

            context.Pedidos.Remove(pedidos);
            await context.SaveChangesAsync();
            return true;
        }

        // ✅ Obtener ingresos por día
        public async Task<List<object>> GetIngresosPorDia()
        {
            var ingresos = await context.Pedidos
        .GroupBy(p => p.FechaPedido.Date)
        .Select(g => new
        {
            Fecha = g.Key,
            TotalIngresos = g.Sum(p => p.Total)
        })
        .OrderBy(g => g.Fecha)
        .ToListAsync(); // ✅ CORRECTO: Usa 'await' aquí

            return ingresos
                .Select(g => new
                {
                    Fecha = g.Fecha.ToString("yyyy-MM-dd"), // ✅ Convertimos en memoria
                    TotalIngresos = g.TotalIngresos
                })
                .Cast<object>()
                .ToList();
        }

        // ✅ Obtener productos más vendidos
        public async Task<List<object>> GetProductosMasVendidos()
        {
            var productos = await context.Pedidos
                .GroupBy(d => d.ProductoId)
                .Select(g => new
                {
                    ProductoID = g.Key,
                    Producto = context.Productos
                                .Where(p => p.Id == g.Key)
                                .Select(p => p.Nombre)
                                .FirstOrDefault(),
                    CantidadVendida = g.Sum(d => d.Cantidad)
                })
                .OrderByDescending(g => g.CantidadVendida)
                .Take(5)
                .ToListAsync();

            return productos.Cast<object>().ToList();
        }
    }
}
