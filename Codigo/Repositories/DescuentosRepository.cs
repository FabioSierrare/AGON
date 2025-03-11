using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class DescuentosRepository : IDescuentos
    {
        private readonly E_commerceContext context;

        public DescuentosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Descuentos>> GetDescuentos()
        {
            var data = await context.Descuentos.ToListAsync();
            return data;
        }

        public async Task<bool> PostDescuentos(Descuentos descuentos)
        {
            await context.Descuentos.AddAsync(descuentos);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutDescuentos(Descuentos descuentos)
        {
            context.Descuentos.Update(descuentos);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteDescuentos(int id)
        {
            var notificacion = await context.Descuentos.FindAsync(id);
            if (notificacion == null) return false;

            context.Descuentos.Remove(notificacion);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
