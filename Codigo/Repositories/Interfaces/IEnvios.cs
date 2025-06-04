using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define las operaciones relacionadas con los envíos en el sistema.
    /// </summary>
    public interface IEnvios
    {
        /// <summary>
        /// Obtiene la lista de todos los envíos registrados.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Envios"/>.</returns>
        Task<List<Envios>> GetEnvios();

        /// <summary>
        /// Agrega un nuevo envío a la base de datos.
        /// </summary>
        /// <param name="detallesPedidos">La entidad <see cref="Envios"/> que representa el envío.</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa.</returns>
        Task<bool> PostEnvios(Envios detallesPedidos);

        /// <summary>
        /// Actualiza un envío existente.
        /// </summary>
        /// <param name="envios">La entidad <see cref="Envios"/> con los datos actualizados.</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa.</returns>
        Task<bool> PutEnvios(Envios envios);

        /// <summary>
        /// Elimina un envío de la base de datos.
        /// </summary>
        /// <param name="id">El identificador único del envío a eliminar.</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa.</returns>
        Task<bool> DeleteEnvios(int id);

        /// <summary>
        /// Obtiene los envíos asociados a un vendedor específico, con información detallada.
        /// </summary>
        /// <param name="idVendedor">El identificador del vendedor.</param>
        /// <returns>Una lista de objetos <see cref="Envio"/> con información filtrada por vendedor.</returns>
        Task<List<Envio>> GetEnviosFiltrados(int idVendedor);
    }
}
