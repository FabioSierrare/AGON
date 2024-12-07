using E_Commerce.Context;
using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace E_Commerce.Repositories
{
    public class EnviosRepository : IEnvios
    {
        public readonly E_commerceContext context;

        public EnviosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Envios>> GetEnvios()
        {
            var data = await context.Envios.ToListAsync();
            return data;
        }

        public async Task<bool> PostEnvios(Envios envios)
        {
            await context.Envios.AddAsync(envios);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutEnvios(Envios envios)
        {
            context.Envios.Update(envios);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteEnvios(int id)
        {
            var comentario = await context.Comentarios.FindAsync(id); // Usar 'context' en lugar de '_context'
            if (comentario == null) return false; // Si no existe, devolver 'false'

            context.Comentarios.Remove(comentario); // Usar 'context'
            await context.SaveChangesAsync(); // Corregir 'SaveAsync' por 'SaveChangesAsync'
            return true;
        }
    }
}
