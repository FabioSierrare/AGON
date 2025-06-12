using E_Commerce.Models;


/// <summary>
/// Interfaz para definir las operaciones CRUD sobre la entidad Categorias.
/// </summary>
public interface ICategoria
{
    /// <summary>
    /// Obtiene la lista completa de categorías.
    /// </summary>
    /// <returns>Lista de objetos Categorias</returns>
    Task<List<Categorias>> GetCategoria();

    /// <summary>
    /// Inserta una nueva categoría en la base de datos.
    /// </summary>
    /// <param name="categoria">Objeto Categorias que se va a insertar</param>
    /// <returns>True si se insertó correctamente, False si falló</returns>
    Task<bool> PostCategoria(Categorias categoria);

    /// <summary>
    /// Actualiza una categoría existente.
    /// </summary>
    /// <param name="categoria">Objeto Categorias con los datos actualizados</param>
    /// <returns>True si se actualizó correctamente, False si falló</returns>
    Task<bool> PutCategoria(Categorias categoria);

    /// <summary>
    /// Elimina una categoría por su identificador único.
    /// </summary>
    /// <param name="id">ID de la categoría que se desea eliminar</param>
    /// <returns>True si fue eliminada, False si no se encontró</returns>
    Task<bool> DeleteCategoria(int id);

    Task<List<Productos>> GetProductosPorCategoria(int id);
}
