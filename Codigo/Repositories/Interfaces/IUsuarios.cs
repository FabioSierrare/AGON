using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define las operaciones para gestionar usuarios en el sistema.
    /// </summary>
    public interface IUsuarios
    {
        /// <summary>
        /// Obtiene la lista de todos los usuarios registrados.
        /// </summary>
        /// <returns>
        /// Una lista de objetos <see cref="Usuarios"/>.
        /// </returns>
        Task<List<Usuarios>> GetUsuarios();

        /// <summary>
        /// Registra un nuevo usuario.
        /// </summary>
        /// <param name="usuarios">El objeto <see cref="Usuarios"/> que se va a registrar.</param>
        /// <returns>
        /// Verdadero si la operación fue exitosa; de lo contrario, falso.
        /// </returns>
        Task<bool> PostUsuarios(Usuarios usuarios);

        /// <summary>
        /// Actualiza la información de un usuario existente.
        /// </summary>
        /// <param name="usuarios">El objeto <see cref="Usuarios"/> con los datos actualizados.</param>
        /// <returns>
        /// Verdadero si la operación fue exitosa; de lo contrario, falso.
        /// </returns>
        Task<bool> PutUsuarios(Usuarios usuarios);

        /// <summary>
        /// Elimina un usuario por su identificador.
        /// </summary>
        /// <param name="id">El ID del usuario a eliminar.</param>
        /// <returns>
        /// Verdadero si el usuario fue eliminado correctamente; de lo contrario, falso.
        /// </returns>
        Task<bool> DeleteUsuarios(int id);

        /// <summary>
        /// Obtiene un usuario a partir de su correo electrónico.
        /// </summary>
        /// <param name="correo">El correo electrónico del usuario.</param>
        /// <returns>
        /// El objeto <see cref="Usuarios"/> correspondiente o null si no se encuentra.
        /// </returns>
        Task<Usuarios> GetUsuarioByCorreoAsync(string correo);

        /// <summary>
        /// Obtiene un usuario a partir de su código de verificación.
        /// </summary>
        /// <param name="codigo">El código de verificación del usuario.</param>
        /// <returns>
        /// El objeto <see cref="Usuarios"/> correspondiente o null si no se encuentra.
        /// </returns>
        Task<Usuarios> GetUsuarioByCodigoAsync(string codigo);

        /// <summary>
        /// Actualiza la información de un usuario (utilizado especialmente para recuperación de cuenta).
        /// </summary>
        /// <param name="usuario">El objeto <see cref="Usuarios"/> actualizado.</param>
        /// <returns>
        /// Verdadero si la operación fue exitosa; de lo contrario, falso.
        /// </returns>
        Task<bool> UpdateUsuarioAsync(Usuarios usuario);
    }
}
