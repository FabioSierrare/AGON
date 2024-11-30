using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class ValoracionesRepository : IValoraciones
    {
        private readonly E_commerceContext context;

        public ValoracionesRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Valoraciones>> GetValoraciones()
        {
            var data = await context.Valoraciones.ToListAsync();
            return data;
        }

        public async Task<bool> PostValoraciones(Valoraciones valoraciones)
        {
            await context.Valoraciones.AddAsync(valoraciones);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutValoraciones(Valoraciones valoraciones)
        {
            context.Valoraciones.Update(valoraciones);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteValoraciones(Valoraciones valoraciones)
        {
            context.Valoraciones.Remove(valoraciones);
            await context.SaveAsync();
            return true;
        }
    }
}
