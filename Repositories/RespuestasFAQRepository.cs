using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class RespuestasFAQRepository : IRespuestasFAQ
    {
        private readonly E_commerceContext context;

        public RespuestasFAQRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<RespuestasFAQ>> GetRespuestasFAQ()
        {
            var data = await context.RespuestasFAQ.ToListAsync();
            return data;
        }

        public async Task<bool> PostRespuestaFAQ(RespuestasFAQ respuestasFAQ)
        {
            await context.RespuestasFAQ.AddAsync(respuestasFAQ);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutRespuestasFAQ(RespuestasFAQ respuestasFAQ)
        {
            context.RespuestasFAQ.Update(respuestasFAQ);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteRespuestasFAQ(int id)
        {
            var notificacion = await context.RespuestasFAQ.FindAsync(id);
            if (notificacion == null) return false;

            context.RespuestasFAQ.Remove(notificacion);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
