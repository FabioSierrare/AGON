using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define las operaciones para la gestión de tickets de soporte en el sistema.
    /// </summary>
    public interface ITicketsSoporte
    {
        /// <summary>
        /// Obtiene una lista de todos los tickets de soporte registrados.
        /// </summary>
        /// <returns>
        /// Una lista de objetos <see cref="TicketsSoporte"/>.
        /// </returns>
        Task<List<TicketsSoporte>> GetTicketsSoporte();

        /// <summary>
        /// Registra un nuevo ticket de soporte.
        /// </summary>
        /// <param name="ticketsSoporte">El objeto <see cref="TicketsSoporte"/> a registrar.</param>
        /// <returns>
        /// Verdadero si la operación fue exitosa; falso en caso contrario.
        /// </returns>
        Task<bool> PostTicketsSoporte(TicketsSoporte ticketsSoporte);

        /// <summary>
        /// Actualiza un ticket de soporte existente.
        /// </summary>
        /// <param name="ticketsSoporte">El objeto <see cref="TicketsSoporte"/> con los datos actualizados.</param>
        /// <returns>
        /// Verdadero si la actualización fue exitosa; falso en caso contrario.
        /// </returns>
        Task<bool> PutTicketsSoporte(TicketsSoporte ticketsSoporte);

        /// <summary>
        /// Elimina un ticket de soporte según su identificador.
        /// </summary>
        /// <param name="id">El ID del ticket de soporte a eliminar.</param>
        /// <returns>
        /// Verdadero si se eliminó correctamente; falso si no se encontró el registro.</returns>
        Task<bool> DeleteTicketsSoporte(int id);
    }
}
