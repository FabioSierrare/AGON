using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define las operaciones relacionadas con la obtención de productos en promoción.
    /// </summary>
    public interface IPromociones
    {
        /// <summary>
        /// Obtiene una lista de productos que tienen descuentos activos aplicados.
        /// </summary>
        /// <returns>
        /// Una lista de objetos <see cref="ProductosDescuentoDTO"/> que representan productos con sus respectivos descuentos.
        /// </returns>
        Task<List<ProductosDescuentoDTO>> GetProductosDescuento();
    }
}
