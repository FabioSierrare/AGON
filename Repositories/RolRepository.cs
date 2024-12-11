﻿using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class RolRepository : IRol
    {
        private readonly E_commerceContext context;

        public RolRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Rol>> GetRol()
        {
            var data = await context.Rol.ToListAsync();
            return data;
        }

        public async Task<bool> PostRol(Rol rol)
        {
            await context.Rol.AddAsync(rol);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutRol(Rol rol)
        {
            context.Rol.Update(rol);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteRol(int id)
        {
            var notificacion = await context.Rol.FindAsync(id);
            if (notificacion == null) return false;

            context.Rol.Remove(notificacion);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
