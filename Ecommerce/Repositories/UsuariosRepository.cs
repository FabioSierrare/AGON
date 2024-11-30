using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class UsuariosRepository : IUsuarios
    {
        private readonly E_commerceContext context;

        public UsuariosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Usuarios>> GetUsuarios()
        {
            var data = await context.Usuarios.ToListAsync();
            return data;
        }

        public async Task<bool> PostUsuarios(Usuarios usuarios)
        {
            await context.Usuarios.AddAsync(usuarios);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutUsuarios(Usuarios usuarios)
        {
            context.Usuarios.Update(usuarios);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteUsuarios(Usuarios usuarios)
        {
            context.Usuarios.Remove(usuarios);
            await context.SaveAsync();
            return true;
        }
    }
}
