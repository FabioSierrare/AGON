using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define las operaciones relacionadas con los descuentos aplicados a productos.
    /// </summary>
    public interface IProductosDescuento
    {
        /// <summary>
        /// Obtiene la lista completa de relaciones entre productos y sus descuentos.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="ProductosDescuento"/>.</returns>
        Task<List<ProductosDescuento>> GetProductosDescuento();

        /// <summary>
        /// Obtiene una lista detallada de productos con sus descuentos actuales.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="ProductosDescuentoDTO"/> con información del producto y el descuento.</returns>
        Task<List<ProductosDescuentoDTO>> GetProductosDescuentos();

        /// <summary>
        /// Agrega un nuevo registro de descuento para un producto.
        /// </summary>
        /// <param name="descuentos">El objeto <see cref="ProductosDescuento"/> a registrar.</param>
        /// <returns>True si el registro se realizó correctamente, false en caso contrario.</returns>
        Task<bool> PostProductosDescuento(ProductosDescuento descuentos);

        /// <summary>
        /// Actualiza un registro de descuento de un producto existente.
        /// </summary>
        /// <param name="descuentos">El objeto <see cref="ProductosDescuento"/> con la información actualizada.</param>
        /// <returns>True si la actualización fue exitosa, false en caso contrario.</returns>
        Task<bool> PutProductosDescuento(ProductosDescuento descuentos);

        /// <summary>
        /// Elimina un registro de descuento asociado a un producto.
        /// </summary>
        /// <param name="id">ID del registro de descuento a eliminar.</param>
        /// <returns>True si el registro fue eliminado correctamente, false si no se encontró.</returns>
        Task<bool> DeleteProductosDescuento(int id);
    }
}
