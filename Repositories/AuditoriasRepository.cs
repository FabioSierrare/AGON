using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using E_Commerce.Context;
using Microsoft.EntityFrameworkCore;
namespace E_Commerce.Repositories
{
    public class AuditoriasRepository : IAuditorias
    {
        private readonly E_commerceContext context;

        public AuditoriasRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Auditorias>> GetAuditorias()
        {
            var data = await context.Auditorias.ToListAsync();
            return data;
        }

        public async Task<bool> PostAuditorias(Auditorias auditorias)
        {
            await context.Auditorias.AddAsync(auditorias);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> PutAuditorias(Auditorias auditorias)
        {
           context.Auditorias.Update(auditorias);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteAuditorias(Auditorias auditorias)
        {
            context.Auditorias.Remove(auditorias);
            await context.SaveAsync();
            return true;
        }
    }
}
