using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define las operaciones para gestionar las valoraciones de productos por parte de los usuarios.
    /// </summary>
    public interface IValoraciones
    {
        /// <summary>
        /// Obtiene la lista de todas las valoraciones registradas.
        /// </summary>
        /// <returns>
        /// Una lista de objetos <see cref="Valoraciones"/>.
        /// </returns>
        Task<List<Valoraciones>> GetValoraciones();

        /// <summary>
        /// Registra una nueva valoración realizada por un usuario.
        /// </summary>
        /// <param name="valoraciones">El objeto <see cref="Valoraciones"/> a registrar.</param>
        /// <returns>
        /// Verdadero si la operación fue exitosa; de lo contrario, falso.
        /// </returns>
        Task<bool> PostValoraciones(Valoraciones valoraciones);

        /// <summary>
        /// Actualiza una valoración existente.
        /// </summary>
        /// <param name="valoraciones">El objeto <see cref="Valoraciones"/> con los datos actualizados.</param>
        /// <returns>
        /// Verdadero si la operación fue exitosa; de lo contrario, falso.
        /// </returns>
        Task<bool> PutValoraciones(Valoraciones valoraciones);

        /// <summary>
        /// Elimina una valoración según su identificador.
        /// </summary>
        /// <param name="id">El ID de la valoración a eliminar.</param>
        /// <returns>
        /// Verdadero si la valoración fue eliminada correctamente; de lo contrario, falso.
        /// </returns>
        Task<bool> DeleteValoraciones(int id);
    }
}
