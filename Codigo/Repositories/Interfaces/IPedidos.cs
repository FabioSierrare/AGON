using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define las operaciones para la gestión de pedidos en el sistema.
    /// </summary>
    public interface IPedidos
    {
        /// <summary>
        /// Obtiene la lista de todos los pedidos registrados.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Pedidos"/>.</returns>
        Task<List<Pedidos>> GetPedidos();

        /// <summary>
        /// Obtiene un pedido específico por su identificador.
        /// </summary>
        /// <param name="id">El identificador del pedido.</param>
        /// <returns>El objeto <see cref="Pedidos"/> correspondiente, o null si no existe.</returns>
        Task<Pedidos> GetPedidoById(int id);

        /// <summary>
        /// Registra un nuevo pedido en el sistema.
        /// </summary>
        /// <param name="pedidos">El objeto <see cref="Pedidos"/> a registrar.</param>
        /// <returns>El objeto <see cref="Pedidos"/> registrado con su ID asignado.</returns>
        Task<Pedidos> PostPedidos(Pedidos pedidos);

        /// <summary>
        /// Actualiza los datos de un pedido existente.
        /// </summary>
        /// <param name="pedidos">El objeto <see cref="Pedidos"/> con la información actualizada.</param>
        /// <returns>True si la operación fue exitosa, false en caso contrario.</returns>
        Task<bool> PutPedidos(Pedidos pedidos);

        /// <summary>
        /// Elimina un pedido a partir de su identificador.
        /// </summary>
        /// <param name="id">El identificador del pedido a eliminar.</param>
        /// <returns>True si se eliminó correctamente, false si no se encontró.</returns>
        Task<bool> DeletePedidos(int id);

        /// <summary>
        /// Obtiene una lista con los ingresos diarios agrupados por fecha.
        /// </summary>
        /// <returns>Una lista de objetos anónimos con la fecha y el total de ingresos.</returns>
        Task<List<object>> GetIngresosPorDia();

        /// <summary>
        /// Obtiene una lista con los productos más vendidos.
        /// </summary>
        /// <returns>Una lista de objetos anónimos con los productos y la cantidad vendida.</returns>
        Task<List<object>> GetProductosMasVendidos();
    }
}
