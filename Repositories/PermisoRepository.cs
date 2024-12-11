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

        public async Task<List<Permiso>> GetPermiso() 
        {
            var data = await context.Permiso.ToListAsync();
            return data;
        }

        public async Task<bool> PostPermiso(Permiso permiso)
        {
            await context.Permiso.AddAsync(permiso);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutPermiso(Permiso permiso)
        {
            context.Permiso.Update(permiso);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeletePermiso(int id)
        {
            var Permiso = await context.Permiso.FindAsync(id);
            if (Permiso == null) return false;

            context.Permiso.Remove(Permiso);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
