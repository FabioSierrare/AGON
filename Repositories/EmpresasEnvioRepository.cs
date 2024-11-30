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
        public async Task<bool> DeleteEmpresasEnvios(EmpresasEnvio empresasEnvio)
        {
            context.EmpresasEnvios.Remove(empresasEnvio);
            await context.SaveAsync();
            return true;
        }
    }
}
