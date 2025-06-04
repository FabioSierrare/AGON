using E_Commerce.Context;
using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio que proporciona acceso a los productos con promociones activas (descuentos).
    /// </summary>
    public class PromocionesRepository : IPromociones
    {
        /// <summary>
        /// Contexto de base de datos inyectado.
        /// </summary>
        public readonly E_commerceContext context;

        /// <summary>
        /// Constructor que inicializa el repositorio con el contexto proporcionado.
        /// </summary>
        /// <param name="context">Instancia del contexto de base de datos</param>
        public PromocionesRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene una lista de productos que tienen promociones activas (descuentos).
        /// </summary>
        /// <returns>Lista de objetos ProductosDescuentoDTO con información del producto y su descuento</returns>
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
