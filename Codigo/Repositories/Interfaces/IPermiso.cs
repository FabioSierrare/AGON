using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define las operaciones para gestionar permisos dentro del sistema.
    /// </summary>
    public interface IPermiso
    {
        /// <summary>
        /// Obtiene una lista de todos los permisos registrados.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Permisos"/>.</returns>
        Task<List<Permisos>> GetPermiso();

        /// <summary>
        /// Registra un nuevo permiso en la base de datos.
        /// </summary>
        /// <param name="permiso">El objeto <see cref="Permisos"/> a agregar.</param>
        /// <returns>True si se registró correctamente, false en caso contrario.</returns>
        Task<bool> PostPermiso(Permisos permiso);

        /// <summary>
        /// Actualiza un permiso existente en la base de datos.
        /// </summary>
        /// <param name="permiso">El objeto <see cref="Permisos"/> con los datos actualizados.</param>
        /// <returns>True si se actualizó correctamente, false en caso contrario.</returns>
        Task<bool> PutPermiso(Permisos permiso);

        /// <summary>
        /// Elimina un permiso a partir de su identificador.
        /// </summary>
        /// <param name="id">El ID del permiso a eliminar.</param>
        /// <returns>True si se eliminó correctamente, false si no se encontró.</returns>
        Task<bool> DeletePermiso(int id);
    }
}
