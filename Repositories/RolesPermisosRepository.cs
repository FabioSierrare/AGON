using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class RolesPermisosRepository : IRolesPermisos
    {
        private readonly E_commerceContext context;

        public RolesPermisosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<RolesPermisos>> GetRolesPermisos()
        {
            var data = await context.RolesPermisos.ToListAsync();
            return data;
        }

        public async Task<bool> PostRolesPermisos(RolesPermisos rolesPermisos)
        {
            await context.RolesPermisos.AddAsync(rolesPermisos);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutRolesPermisos(RolesPermisos rolesPermisos)
        {
            context.RolesPermisos.Update(rolesPermisos);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteRolesPermisos(RolesPermisos rolesPermisos)
        {
            context.RolesPermisos.Remove(rolesPermisos);
            await context.SaveAsync();
            return true;
        }
    }
}
