using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class NotificacionesRepository : INotificaciones
    {
        private readonly E_commerceContext context;

        public NotificacionesRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Notificaciones>> GetNotificaciones()
        {
            var data = await context.Notificaciones.ToListAsync();
            return data;
        }

        public async Task<bool> PostNotificaciones(Notificaciones notificaciones)
        {
            await context.Notificaciones.AddAsync(notificaciones);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutNotificaciones(Notificaciones notificaciones)
        {
            context.Notificaciones.Update(notificaciones);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteNotificaciones(Notificaciones notificaciones)
        {
            context.Notificaciones.Remove(notificaciones);
            await context.SaveAsync();
            return true;
        }
    }
}
