using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio para gestionar las operaciones CRUD sobre el seguimiento de envíos (TrackingEnvio).
    /// </summary>
    public class TrackingEnvioRepository : ITrackingEnvio
    {
        /// <summary>
        /// Contexto de base de datos del sistema de e-commerce.
        /// </summary>
        private readonly E_commerceContext context;

        /// <summary>
        /// Constructor del repositorio que recibe el contexto de base de datos.
        /// </summary>
        /// <param name="context">Contexto de base de datos inyectado</param>
        public TrackingEnvioRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene todos los registros de seguimiento de envíos.
        /// </summary>
        /// <returns>Lista de objetos TrackingEnvio</returns>
        public async Task<List<TrackingEnvio>> GetTrackingEnvio()
        {
            var data = await context.TrackingEnvio.ToListAsync();
            return data;
        }

        /// <summary>
        /// Inserta un nuevo registro de seguimiento de envío.
        /// </summary>
        /// <param name="trackingEnvio">Objeto TrackingEnvio a insertar</param>
        /// <returns>True si se insertó correctamente</returns>
        public async Task<bool> PostTrackingEnvio(TrackingEnvio trackingEnvio)
        {
            await context.TrackingEnvio.AddAsync(trackingEnvio);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Actualiza un registro existente de seguimiento de envío.
        /// </summary>
        /// <param name="trackingEnvio">Objeto TrackingEnvio con datos actualizados</param>
        /// <returns>True si se actualizó correctamente</returns>
        public async Task<bool> PutTrackingEnvio(TrackingEnvio trackingEnvio)
        {
            context.TrackingEnvio.Update(trackingEnvio);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Elimina un registro de seguimiento de envío por su ID.
        /// </summary>
        /// <param name="id">ID del registro a eliminar</param>
        /// <returns>True si se eliminó correctamente, False si no se encontró el registro</returns>
        public async Task<bool> DeleteTrackingEnvio(int id)
        {
            var notificacion = await context.TrackingEnvio.FindAsync(id);
            if (notificacion == null) return false;

            context.TrackingEnvio.Remove(notificacion);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
