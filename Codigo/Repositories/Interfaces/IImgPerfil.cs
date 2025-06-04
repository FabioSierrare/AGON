using E_Commerce.Models;

/// <summary>
/// Define las operaciones para gestionar las imágenes de perfil de los usuarios.
/// </summary>
public interface IImgPerfil
{
    /// <summary>
    /// Obtiene la lista de todas las imágenes de perfil registradas.
    /// </summary>
    /// <returns>Una lista de objetos <see cref="ImgPerfil"/>.</returns>
    Task<List<ImgPerfil>> GetImgPerfil();

    /// <summary>
    /// Registra una nueva imagen de perfil en la base de datos.
    /// </summary>
    /// <param name="imgperfil">El objeto <see cref="ImgPerfil"/> que se desea registrar.</param>
    /// <returns>Un valor booleano que indica si la operación fue exitosa.</returns>
    Task<bool> PostImgPerfil(ImgPerfil imgperfil);

    /// <summary>
    /// Actualiza una imagen de perfil existente en la base de datos.
    /// </summary>
    /// <param name="imgperfil">El objeto <see cref="ImgPerfil"/> con los datos actualizados.</param>
    /// <returns>Un valor booleano que indica si la operación fue exitosa.</returns>
    Task<bool> PutImgPerfil(ImgPerfil imgperfil);

    /// <summary>
    /// Elimina una imagen de perfil con base en su identificador único.
    /// </summary>
    /// <param name="id">El identificador de la imagen de perfil que se desea eliminar.</param>
    /// <returns>Un valor booleano que indica si la eliminación fue exitosa.</returns>
    Task<bool> DeleteImgPerfil(int id);
}
