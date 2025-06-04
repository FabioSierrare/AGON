using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define las operaciones para la gestión de roles y sus permisos asociados en el sistema.
    /// </summary>
    public interface IRolesPermisos
    {
        /// <summary>
        /// Obtiene una lista de todos los registros de roles con sus permisos.
        /// </summary>
        /// <returns>
        /// Una lista de objetos <see cref="RolesPermisos"/>.
        /// </returns>
        Task<List<RolesPermisos>> GetRolesPermisos();

        /// <summary>
        /// Registra una nueva asociación de rol con permiso.
        /// </summary>
        /// <param name="rolesPermisos">El objeto <see cref="RolesPermisos"/> que se desea agregar.</param>
        /// <returns>
        /// Verdadero si la operación fue exitosa, falso en caso contrario.
        /// </returns>
        Task<bool> PostRolesPermisos(RolesPermisos rolesPermisos);

        /// <summary>
        /// Actualiza una asociación de rol con permiso existente.
        /// </summary>
        /// <param name="rolesPermisos">El objeto <see cref="RolesPermisos"/> con la información actualizada.</param>
        /// <returns>
        /// Verdadero si la actualización fue exitosa, falso en caso contrario.
        /// </returns>
        Task<bool> PutRolesPermisos(RolesPermisos rolesPermisos);

        /// <summary>
        /// Elimina una asociación de rol con permiso según su identificador.
        /// </summary>
        /// <param name="id">El ID de la asociación que se desea eliminar.</param>
        /// <returns>
        /// Verdadero si la eliminación fue exitosa, falso si no se encontró el registro.</returns>
        Task<bool> DeleteRolesPermisos(int id);
    }
}
