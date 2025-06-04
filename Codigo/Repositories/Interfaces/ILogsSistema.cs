using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define las operaciones para la gestión de registros del sistema (logs).
    /// </summary>
    public interface ILogsSistema
    {
        /// <summary>
        /// Obtiene todos los registros del sistema.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="LogsSistema"/>.</returns>
        Task<List<LogsSistema>> GetLogsSistema();

        /// <summary>
        /// Agrega un nuevo registro al sistema.
        /// </summary>
        /// <param name="logsSistema">El objeto <see cref="LogsSistema"/> que se va a agregar.</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa.</returns>
        Task<bool> PostLogsSistema(LogsSistema logsSistema);

        /// <summary>
        /// Actualiza un registro existente del sistema.
        /// </summary>
        /// <param name="logsSistema">El objeto <see cref="LogsSistema"/> con la información actualizada.</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa.</returns>
        Task<bool> PutLogsSistema(LogsSistema logsSistema);

        /// <summary>
        /// Elimina un registro del sistema según su identificador.
        /// </summary>
        /// <param name="id">El identificador único del registro a eliminar.</param>
        /// <returns>Un valor booleano que indica si la eliminación fue exitosa.</returns>
        Task<bool> DeleteLogsSistema(int id);
    }
}
