using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class PermisoRepository : IPermiso
    {
        private readonly E_commerceContext context;

        public PermisoRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Permisos>> GetPermiso() 
        {
            var data = await context.Permisos.ToListAsync();
            return data;
        }

        public async Task<bool> PostPermiso(Permisos permiso)
        {
            await context.Permisos.AddAsync(permiso);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutPermiso(Permisos permisos)
        {
            context.Permisos.Update(permisos);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeletePermiso(int id)
        {
            var Permiso = await context.Permisos.FindAsync(id);
            if (Permiso == null) return false;

            context.Permisos.Remove(Permiso);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
