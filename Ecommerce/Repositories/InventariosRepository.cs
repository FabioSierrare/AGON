using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class InventariosRepository : IInventarios
    {
        private readonly E_commerceContext context;

        public InventariosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Inventarios>> GetInventarios()
        {
            var data = await context.Inventarios.ToListAsync();
            return data;
        }

        public async Task<bool> PostInventarios(Inventarios inventarios)
        {
            await context.Inventarios.AddAsync(inventarios);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutInventarios(Inventarios inventarios)
        {
            context.Inventarios.Update(inventarios);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteInventarios(Inventarios inventarios)
        {
            context.Inventarios.Remove(inventarios);
            await context.SaveAsync();
            return true;
        }
    }
}
