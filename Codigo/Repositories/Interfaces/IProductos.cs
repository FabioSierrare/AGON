using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define las operaciones relacionadas con la gestión de productos.
    /// </summary>
    public interface IProductos
    {
        /// <summary>
        /// Obtiene una lista de todos los productos registrados.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Productos"/>.</returns>
        Task<List<Productos>> GetProductos();

        /// <summary>
        /// Busca productos que coincidan con una o más palabras clave.
        /// </summary>
        /// <param name="palabra">Palabra o conjunto de palabras clave para la búsqueda.</param>
        /// <returns>Una lista de objetos <see cref="Busquedas"/> con los productos coincidentes.</returns>
        Task<List<Busquedas>> GetBusqueda(string palabra);

        /// <summary>
        /// Agrega un nuevo producto a la base de datos.
        /// </summary>
        /// <param name="productos">El objeto <see cref="Productos"/> a registrar.</param>
        /// <returns>True si el producto se registró correctamente, false en caso contrario.</returns>
        Task<bool> PostProductos(Productos productos);

        /// <summary>
        /// Actualiza los datos de un producto existente.
        /// </summary>
        /// <param name="productos">El objeto <see cref="Productos"/> con la información actualizada.</param>
        /// <returns>True si el producto se actualizó correctamente, false en caso contrario.</returns>
        Task<bool> PutProductos(Productos productos);

        /// <summary>
        /// Elimina un producto a partir de su identificador.
        /// </summary>
        /// <param name="id">ID del producto a eliminar.</param>
        /// <returns>True si el producto fue eliminado correctamente, false si no se encontró.</returns>
        Task<bool> DeleteProductos(int id);

        /// <summary>
        /// Obtiene un producto específico por su identificador.
        /// </summary>
        /// <param name="id">ID del producto a buscar.</param>
        /// <returns>El objeto <see cref="Productos"/> correspondiente, o null si no se encuentra.</returns>
        Task<Productos> GetProductoById(int id);
    }
}
