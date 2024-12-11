using E_Commerce.Context;
using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class EmpresasEnvioRepository : IEmpresasEnvio
    {
        public readonly E_commerceContext context;

        public EmpresasEnvioRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<EmpresasEnvio>> GetEmpresasEnvios()
        {
            var data = await context.EmpresasEnvios.ToListAsync();
            return data;
        }

        public async Task<bool> PostEmpresasEnvios(EmpresasEnvio empresasEnvio)
        {
            await context.EmpresasEnvios.AddAsync(empresasEnvio);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutEmpresasEnvios(EmpresasEnvio empresasEnvio)
        {
            context.EmpresasEnvios.Update(empresasEnvio);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteEmpresasEnvios(int id)
        {
            var empresasEnvios = await context.EmpresasEnvios.FindAsync(id); // Usar 'context' en lugar de '_context'
            if (empresasEnvios == null) return false; // Si no existe, devolver 'false'

            context.EmpresasEnvios.Remove(empresasEnvios); // Usar 'context'
            await context.SaveChangesAsync(); // Corregir 'SaveAsync' por 'SaveChangesAsync'
            return true;
        }
    }
}
