using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class ComentariosRepository : IComentarios
    {
        public readonly E_commerceContext context;

        public ComentariosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Comentarios>> GetComentarios()
        {
            var data = await context.Comentarios.ToListAsync();
            return data;
        }

        public async Task<bool> PostComentarios(Comentarios comentarios)
        {
            await context.Comentarios.AddAsync(comentarios);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutComentarios(Comentarios comentarios)
        {
            context.Comentarios.Update(comentarios);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteComentarios(Comentarios comentarios)
        {
            context.Comentarios.Remove(comentarios);
            await context.SaveAsync();
            return true;
        }
    }
}
