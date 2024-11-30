using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class LogsSistemaRepository : ILogsSistema
    {
        private readonly E_commerceContext context;

        public LogsSistemaRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<LogsSistema>> GetLogsSistema()
        {
            var data = await context.LogsSistema.ToListAsync();
            return data;
        }

        public async Task<bool> PostLogsSistema(LogsSistema logsSistema)
        {
            await context.LogsSistema.AddAsync(logsSistema);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutLogsSistema(LogsSistema logsSistema)
        {
            context.LogsSistema.Update(logsSistema);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteLogsSistema(LogsSistema logsSistema)
        {
            context.LogsSistema.Remove(logsSistema);
            await context.SaveAsync();
            return true;
        }
    }
}
