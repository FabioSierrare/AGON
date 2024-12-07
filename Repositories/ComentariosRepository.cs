using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class ComentariosRepository : IComentarios
    {
        public readonly E_commerceContext context; // Usar 'context' en lugar de '_context'

        public ComentariosRepository(E_commerceContext context)
        {
            this.context = context; // Se inyecta el contexto en el constructor
        }

        public async Task<List<Comentarios>> GetComentarios()
        {
            var data = await context.Comentarios.ToListAsync(); // Usar 'context'
            return data;
        }

        public async Task<bool> PostComentarios(Comentarios comentarios)
        {
            await context.Comentarios.AddAsync(comentarios); // Usar 'context'
            await context.SaveChangesAsync(); // Corregir 'SaveAsync' por 'SaveChangesAsync'
            return true;
        }

        public async Task<bool> PutComentarios(Comentarios comentarios)
        {
            context.Comentarios.Update(comentarios); // Usar 'context'
            await context.SaveChangesAsync(); // Corregir 'SaveAsync' por 'SaveChangesAsync'
            return true;
        }

        public async Task<bool> DeleteComentarios(int id)
        {
            var comentario = await context.Comentarios.FindAsync(id); // Usar 'context' en lugar de '_context'
            if (comentario == null) return false; // Si no existe, devolver 'false'

            context.Comentarios.Remove(comentario); // Usar 'context'
            await context.SaveChangesAsync(); // Corregir 'SaveAsync' por 'SaveChangesAsync'
            return true;
        }
    }
}
