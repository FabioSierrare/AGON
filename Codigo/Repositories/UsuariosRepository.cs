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
        public async Task<bool> DeleteUsuarios(int id)
        {
            var usuario = await context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }

            context.Usuarios.Remove(usuario);
            await context.SaveChangesAsync();
            return true;
        }

        // Obtener un usuario por correo
        public async Task<Usuarios> GetUsuarioByCorreoAsync(string correo)
        {
            return await context.Usuarios.FirstOrDefaultAsync(u => u.Correo == correo);
        }

        // Obtener un usuario por el Codigo de Verificacion recuperación
        public async Task<Usuarios> GetUsuarioByCodigoAsync(string codigo)
        {
            return await context.Usuarios.FirstOrDefaultAsync(u => u.CodigoVerificacion == codigo);
        }

        // Actualizar un usuario
        public async Task<bool> UpdateUsuarioAsync(Usuarios usuario)
        {
            context.Usuarios.Update(usuario);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
