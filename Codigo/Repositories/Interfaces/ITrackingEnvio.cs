using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define las operaciones CRUD para el seguimiento de envíos.
    /// </summary>
    public interface ITrackingEnvio
    {
        /// <summary>
        /// Obtiene una lista de todos los registros de seguimiento de envío.
        /// </summary>
        /// <returns>
        /// Una lista de objetos <see cref="TrackingEnvio"/>.
        /// </returns>
        Task<List<TrackingEnvio>> GetTrackingEnvio();

        /// <summary>
        /// Registra un nuevo seguimiento de envío.
        /// </summary>
        /// <param name="trackingEnvio">El objeto <see cref="TrackingEnvio"/> a registrar.</param>
        /// <returns>
        /// Verdadero si la operación fue exitosa; de lo contrario, falso.
        /// </returns>
        Task<bool> PostTrackingEnvio(TrackingEnvio trackingEnvio);

        /// <summary>
        /// Actualiza un registro existente de seguimiento de envío.
        /// </summary>
        /// <param name="trackingEnvio">El objeto <see cref="TrackingEnvio"/> con los datos actualizados.</param>
        /// <returns>
        /// Verdadero si la operación fue exitosa; de lo contrario, falso.
        /// </returns>
        Task<bool> PutTrackingEnvio(TrackingEnvio trackingEnvio);

        /// <summary>
        /// Elimina un registro de seguimiento de envío por su identificador.
        /// </summary>
        /// <param name="id">El ID del seguimiento de envío a eliminar.</param>
        /// <returns>
        /// Verdadero si el registro fue eliminado correctamente; de lo contrario, falso.
        /// </returns>
        Task<bool> DeleteTrackingEnvio(int id);
    }
}
