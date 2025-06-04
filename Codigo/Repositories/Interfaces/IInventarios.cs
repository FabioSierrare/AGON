using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define las operaciones para gestionar el inventario de productos.
    /// </summary>
    public interface IInventarios
    {
        /// <summary>
        /// Obtiene la lista completa de registros de inventario.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Inventarios"/>.</returns>
        Task<List<Inventarios>> GetInventarios();

        /// <summary>
        /// Agrega un nuevo registro de inventario a la base de datos.
        /// </summary>
        /// <param name="inventarios">El objeto <see cref="Inventarios"/> que se desea agregar.</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa.</returns>
        Task<bool> PostInventarios(Inventarios inventarios);

        /// <summary>
        /// Actualiza un registro de inventario existente.
        /// </summary>
        /// <param name="inventarios">El objeto <see cref="Inventarios"/> con la información actualizada.</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa.</returns>
        Task<bool> PutInventarios(Inventarios inventarios);

        /// <summary>
        /// Elimina un registro de inventario según su identificador.
        /// </summary>
        /// <param name="id">El identificador único del registro de inventario a eliminar.</param>
        /// <returns>Un valor booleano que indica si la eliminación fue exitosa.</returns>
        Task<bool> DeleteInventarios(int id);
    }
}
