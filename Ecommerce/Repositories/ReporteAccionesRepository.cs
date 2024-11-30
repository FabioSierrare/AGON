using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class ReporteAccionesRepository : IReporteAcciones
    {
        private readonly E_commerceContext context;

        public ReporteAccionesRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<ReporteAcciones>> GetReporteAcciones()
        {
            var data = await context.ReporteAcciones.ToListAsync();
            return data;
        }

        public async Task<bool> PostReporteAcciones(ReporteAcciones reporteAcciones)
        {
            await context.ReporteAcciones.AddAsync(reporteAcciones);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutReporteAcciones(ReporteAcciones reporteAcciones)
        {
            context.ReporteAcciones.Update(reporteAcciones);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteReporteAcciones(ReporteAcciones reporteAcciones)
        {
            context.ReporteAcciones.Remove(reporteAcciones);
            await context.SaveAsync();
            return true;
        }
    }
}
