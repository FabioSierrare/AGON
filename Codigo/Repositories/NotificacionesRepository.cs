using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio que gestiona las operaciones CRUD para la entidad Notificaciones.
    /// </summary>
    public class NotificacionesRepository : INotificaciones
    {
        /// <summary>
        /// Contexto de base de datos inyectado.
        /// </summary>
        private readonly E_commerceContext context;

        /// <summary>
        /// Constructor que inicializa el repositorio con el contexto proporcionado.
        /// </summary>
        /// <param name="context">Instancia del contexto de la base de datos</param>
        public NotificacionesRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene la lista de todas las notificaciones.
        /// </summary>
        /// <returns>Lista de objetos Notificaciones</returns>
        public async Task<List<Notificaciones>> GetNotificaciones()
        {
            var data = await context.Notificaciones.ToListAsync();
            return data;
        }

        /// <summary>
        /// Inserta una nueva notificación en la base de datos.
        /// </summary>
        /// <param name="notificaciones">Objeto Notificaciones a insertar</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PostNotificaciones(Notificaciones notificaciones)
        {
            await context.Notificaciones.AddAsync(notificaciones);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Actualiza una notificación existente en la base de datos.
        /// </summary>
        /// <param name="notificaciones">Objeto Notificaciones con los datos actualizados</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PutNotificaciones(Notificaciones notificaciones)
        {
            context.Notificaciones.Update(notificaciones);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Elimina una notificación por su ID.
        /// </summary>
        /// <param name="id">ID de la notificación a eliminar</param>
        /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
        public async Task<bool> DeleteNotificaciones(int id)
        {
            var notificaciones = await context.Notificaciones.FindAsync(id);
            if (notificaciones == null) return false;

            context.Notificaciones.Remove(notificaciones);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
