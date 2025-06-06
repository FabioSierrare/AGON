using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define las operaciones CRUD para la entidad TipoUsuarios.
    /// </summary>
    public interface ITipoUsuarios
    {
        /// <summary>
        /// Obtiene una lista de todos los tipos de usuario.
        /// </summary>
        /// <returns>
        /// Una lista de objetos <see cref="TipoUsuarios"/>.
        /// </returns>
        Task<List<TipoUsuarios>> GetTipoUsuarios();

        /// <summary>
        /// Registra un nuevo tipo de usuario.
        /// </summary>
        /// <param name="tipoUsuario">El objeto <see cref="TipoUsuarios"/> a registrar.</param>
        /// <returns>
        /// Verdadero si la operación fue exitosa; de lo contrario, falso.
        /// </returns>
        Task<bool> PostTipoUsuarios(TipoUsuarios tipoUsuario);

        /// <summary>
        /// Actualiza un tipo de usuario existente.
        /// </summary>
        /// <param name="tipoUsuario">El objeto <see cref="TipoUsuarios"/> con los datos actualizados.</param>
        /// <returns>
        /// Verdadero si la operación fue exitosa; de lo contrario, falso.
        /// </returns>
        Task<bool> PutTipoUsuarios(TipoUsuarios tipoUsuario);

        /// <summary>
        /// Elimina un tipo de usuario por su identificador.
        /// </summary>
        /// <param name="id">El ID del tipo de usuario a eliminar.</param>
        /// <returns>
        /// Verdadero si el registro fue eliminado correctamente; de lo contrario, falso.
        /// </returns>
        Task<bool> DeleteTipoUsuarios(int id);
    }
}
