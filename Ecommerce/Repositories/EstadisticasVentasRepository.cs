using E_Commerce.Context;
using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class EstadisticasVentasRepository : IEstadisticasVentas
    {
        private readonly E_commerceContext context;

        public EstadisticasVentasRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<EstadisticasVentas>> GetEstadisticasVentas()
        {
            var data = await context.EstadisticasVentas.ToListAsync();
            return data;
        }

        public async Task<bool> PostEstadisticasVentas(EstadisticasVentas estadisticasVentas)
        {
            await context.EstadisticasVentas.AddAsync(estadisticasVentas);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutEstadisticasVentas(EstadisticasVentas estadisticasVentas)
        {
            context.EstadisticasVentas.Update(estadisticasVentas);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteEstadisticasVentas(EstadisticasVentas estadisticasVentas)
        {
            context.EstadisticasVentas.Remove(estadisticasVentas);
            await context.SaveAsync();
            return true;
        }
    }
}
