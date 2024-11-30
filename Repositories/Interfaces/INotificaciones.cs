using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    public interface INotificaciones
    {
        Task<List<Notificaciones>> GetNotificaciones();
        Task<bool> PostNotificaciones(Notificaciones notificaciones);
        Task<bool> PutNotificaciones(Notificaciones notificaciones);
        Task<bool> DeleteNotificaciones(Notificaciones notificaciones);
    }
}
