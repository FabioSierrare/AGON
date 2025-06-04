using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Interfaz para gestionar las operaciones CRUD de los detalles de pedidos.
    /// </summary>
    public interface IDetallesPedidos
    {
        /// <summary>
        /// Obtiene la lista completa de detalles de pedidos registrados.
        /// </summary>
        /// <returns>Lista de objetos <see cref="DetallesPedidos"/>.</returns>
        Task<List<DetallesPedidos>> GetDetallesPedidos();

        /// <summary>
        /// Inserta un nuevo detalle de pedido en la base de datos.
        /// </summary>
        /// <param name="detallesPedidos">Objeto <see cref="DetallesPedidos"/> que representa el detalle del pedido a agregar.</param>
        /// <returns>True si la operación fue exitosa; de lo contrario, false.</returns>
        Task<bool> PostDetallesPedidos(DetallesPedidos detallesPedidos);

        /// <summary>
        /// Actualiza un detalle de pedido existente.
        /// </summary>
        /// <param name="detallesPedidos">Objeto <see cref="DetallesPedidos"/> con la información actualizada.</param>
        /// <returns>True si se actualizó correctamente; de lo contrario, false.</returns>
        Task<bool> PutDetallesPedidos(DetallesPedidos detallesPedidos);

        /// <summary>
        /// Elimina un detalle de pedido según su ID.
        /// </summary>
        /// <param name="id">ID del detalle de pedido que se desea eliminar.</param>
        /// <returns>True si se eliminó correctamente; de lo contrario, false.</returns>
        Task<bool> DeleteDetallesPedidos(int id);
    }
}
