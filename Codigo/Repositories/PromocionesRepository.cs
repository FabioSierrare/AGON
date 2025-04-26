using E_Commerce.Context;
using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class PromocionesRepository : IPromociones
    {
        public readonly E_commerceContext context;

        public PromocionesRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<ProductosDescuentoDTO>> GetProductosDescuento()
        {
            return await context.ProductosDescuento
                .Include(p => p.Producto)
                .Include(p => p.Descuento)
                .Select(pd => new ProductosDescuentoDTO
                {
                    ProductoId = pd.Producto.Id,
                    Nombre = pd.Producto.Nombre,
                    PrecioOriginal = pd.Producto.Precio,
                    UrlImagen = pd.Producto.UrlImagen,
                    PorcentajeDescuento = pd.Descuento.Descuento
                })
                .ToListAsync();
        }
    }
}
