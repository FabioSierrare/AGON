using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    public interface IProductosDescuento
    {
        Task<List<ProductosDescuento>> GetProductosDescuento();
        Task<bool> PostProductosDescuento(ProductosDescuento descuentos);
        Task<bool> PutProductosDescuento(ProductosDescuento descuentos);
        Task<bool> DeleteProductosDescuento(int id);

    }
}
