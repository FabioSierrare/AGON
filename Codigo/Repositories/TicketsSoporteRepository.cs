using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class TicketsSoporteRepository : ITicketsSoporte
    {
        private readonly E_commerceContext context;

        public TicketsSoporteRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<TicketsSoporte>> GetTicketsSoporte()
        {
            var data = await context.TicketsSoporte.ToListAsync();
            return data;
        }

        public async Task<bool> PostTicketsSoporte(TicketsSoporte ticketsSoporte)
        {
            await context.TicketsSoporte.AddAsync(ticketsSoporte);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutTicketsSoporte(TicketsSoporte ticketsSoporte)
        {
            context.TicketsSoporte.Update(ticketsSoporte);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteTicketsSoporte(int id)
        {
            var notificacion = await context.TicketsSoporte.FindAsync(id);
            if (notificacion == null) return false;

            context.TicketsSoporte.Remove(notificacion);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
