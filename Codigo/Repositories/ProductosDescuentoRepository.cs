using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class ProductosDescuentoRepository : IProductosDescuento
    {
        private readonly E_commerceContext context;

        public ProductosDescuentoRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<ProductosDescuento>> GetProductosDescuento()
        {
            var data = await context.ProductosDescuento.ToListAsync();
            return data;
        }
        public async Task<List<ProductosDescuentoDTO>> GetProductosDescuentos()
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

        public async Task<bool> PostProductosDescuento(ProductosDescuento descuentos)
        {
            await context.ProductosDescuento.AddAsync(descuentos);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutProductosDescuento(ProductosDescuento descuentos)
        {
            context.ProductosDescuento.Update(descuentos);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteProductosDescuento(int id)
        {
            var notificacion = await context.ProductosDescuento.FindAsync(id);
            if (notificacion == null) return false;

            context.ProductosDescuento.Remove(notificacion);
            await context.SaveChangesAsync();
            return true;
        }
    }
}

