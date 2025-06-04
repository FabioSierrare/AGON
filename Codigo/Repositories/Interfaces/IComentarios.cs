using E_Commerce.Models;

/// <summary>
/// Interfaz para gestionar operaciones CRUD sobre comentarios de productos.
/// </summary>
public interface IComentarios
{
    /// <summary>
    /// Obtiene la lista de todos los comentarios registrados.
    /// </summary>
    /// <returns>Lista de objetos Comentarios</returns>
    Task<List<Comentarios>> GetComentarios();

    /// <summary>
    /// Agrega un nuevo comentario a la base de datos.
    /// </summary>
    /// <param name="comentarios">Objeto Comentarios que contiene los datos del comentario</param>
    /// <returns>True si se guardó correctamente, False si falló</returns>
    Task<bool> PostComentarios(Comentarios comentarios);

    /// <summary>
    /// Actualiza un comentario existente.
    /// </summary>
    /// <param name="comentarios">Objeto Comentarios con los datos actualizados</param>
    /// <returns>True si se actualizó correctamente, False si falló</returns>
    Task<bool> PutComentarios(Comentarios comentarios);

    /// <summary>
    /// Elimina un comentario por su ID.
    /// </summary>
    /// <param name="id">Identificador del comentario a eliminar</param>
    /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
    Task<bool> DeleteComentarios(int id);
}
