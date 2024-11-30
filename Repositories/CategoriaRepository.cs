using E_Commerce.Models;
using E_Commerce.Context;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Repositories.Interfaces;
namespace E_Commerce.Repositories
{
    public class CategoriaRepository : ICategoria
    {
        private readonly E_commerceContext context;

        public CategoriaRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Categoria>> GetCategoria()
        {
            var data = await context.Categoria.ToListAsync();
            return data;
        }

        public async Task<bool> PostCategoria(Categoria categoria)
        {
            await context.Categoria.AddAsync(categoria);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutCategoria(Categoria categoria)
        {
            context.Categoria.Update(categoria);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteCategoria(Categoria categoria)
        {
            context.Categoria.Remove(categoria);
            await context.SaveAsync();
            return true;
        }
    }
}
