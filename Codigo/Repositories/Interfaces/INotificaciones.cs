using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define las operaciones para la gestión de notificaciones dentro del sistema.
    /// </summary>
    public interface INotificaciones
    {
        /// <summary>
        /// Obtiene todas las notificaciones disponibles.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Notificaciones"/>.</returns>
        Task<List<Notificaciones>> GetNotificaciones();

        /// <summary>
        /// Crea una nueva notificación en el sistema.
        /// </summary>
        /// <param name="notificaciones">El objeto <see cref="Notificaciones"/> a agregar.</param>
        /// <returns>Un valor booleano indicando si la operación fue exitosa.</returns>
        Task<bool> PostNotificaciones(Notificaciones notificaciones);

        /// <summary>
        /// Actualiza una notificación existente.
        /// </summary>
        /// <param name="notificaciones">El objeto <see cref="Notificaciones"/> con los datos actualizados.</param>
        /// <returns>Un valor booleano indicando si la actualización fue exitosa.</returns>
        Task<bool> PutNotificaciones(Notificaciones notificaciones);

        /// <summary>
        /// Elimina una notificación específica por su identificador.
        /// </summary>
        /// <param name="id">El identificador de la notificación a eliminar.</param>
        /// <returns>Un valor booleano indicando si la eliminación fue exitosa.</returns>
        Task<bool> DeleteNotificaciones(int id);
    }
}
