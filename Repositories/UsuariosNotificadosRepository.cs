using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class UsuariosNotificadosRepository : IUsuariosNotificados
    {
        private readonly E_commerceContext context;
        
        public UsuariosNotificadosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<UsuariosNotificados>> GetUsuariosNotificados()
        {
            var data = await context.UsuariosNotificados.ToListAsync();
            return data;
        }

        public async Task<bool> PostUsuariosNotificados(UsuariosNotificados usuariosNotificados)
        {
            await context.UsuariosNotificados.AddAsync(usuariosNotificados);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutUsuariosNotificados(UsuariosNotificados usuariosNotificados)
        {
            context.UsuariosNotificados.Update(usuariosNotificados);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteUsuariosNotificados(UsuariosNotificados usuariosNotificados)
        {
            context.UsuariosNotificados.Remove(usuariosNotificados);
            await context.SaveAsync();
            return true;
        }
    }
}
