using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio que gestiona las operaciones CRUD relacionadas con los descuentos aplicados a productos.
    /// </summary>
    public class ProductosDescuentoRepository : IProductosDescuento
    {
        /// <summary>
        /// Contexto de base de datos inyectado.
        /// </summary>
        private readonly E_commerceContext context;

        /// <summary>
        /// Constructor que inicializa el repositorio con el contexto proporcionado.
        /// </summary>
        /// <param name="context">Instancia del contexto de base de datos</param>
        public ProductosDescuentoRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene todos los registros de descuentos de productos.
        /// </summary>
        /// <returns>Lista de objetos ProductosDescuento</returns>
        public async Task<List<ProductosDescuento>> GetProductosDescuento()
        {
            var data = await context.ProductosDescuento.ToListAsync();
            return data;
        }

        /// <summary>
        /// Obtiene una lista de productos con sus respectivos descuentos como DTO.
        /// </summary>
        /// <returns>Lista de objetos ProductosDescuentoDTO con información del producto y su descuento</returns>
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

        /// <summary>
        /// Inserta un nuevo descuento de producto.
        /// </summary>
        /// <param name="descuentos">Objeto ProductosDescuento a insertar</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PostProductosDescuento(ProductosDescuento descuentos)
        {
            await context.ProductosDescuento.AddAsync(descuentos);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Actualiza un descuento de producto existente.
        /// </summary>
        /// <param name="descuentos">Objeto ProductosDescuento con la información actualizada</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PutProductosDescuento(ProductosDescuento descuentos)
        {
            context.ProductosDescuento.Update(descuentos);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Elimina un descuento de producto por su ID.
        /// </summary>
        /// <param name="id">ID del registro a eliminar</param>
        /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
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
