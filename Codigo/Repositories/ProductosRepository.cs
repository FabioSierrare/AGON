using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio para manejar operaciones CRUD y búsquedas sobre productos.
    /// </summary>
    public class ProductosRepository : IProductos
    {
        /// <summary>
        /// Contexto de la base de datos.
        /// </summary>
        private readonly E_commerceContext context;

        /// <summary>
        /// Constructor que recibe el contexto de base de datos.
        /// </summary>
        /// <param name="context">Instancia de E_commerceContext</param>
        public ProductosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene todos los productos registrados.
        /// </summary>
        /// <returns>Lista de productos</returns>
        public async Task<List<Productos>> GetProductos()
        {
            var data = await context.Productos.ToListAsync();
            return data;
        }

        /// <summary>
        /// Realiza una búsqueda de productos según palabras clave en el nombre o descripción, tambien segun el numero de categoria y el precio tanto minimo como maximo.
        /// </summary>
        /// <param name="palabra">Palabra o frase a buscar</param>
        /// <param name="categoriaId">}Numero de categoria a buscar</param>
        /// <param name="descripcion">descripcion o frase a buscar</param>
        /// <param name="precioMin">Precio minimo a buscar</param>
        /// <param name="precioMax">Precio Maximo  a buscar</param>
        /// <returns>Lista de resultados personalizados con descuentos aplicados</returns>
        public async Task<List<Busquedas>> GetBusqueda(string? palabra, int? categoriaId, string? descripcion, decimal? precioMin, decimal? precioMax)
        {
            var palabras = palabra?.ToLower()?.Split(' ', StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();

            var query = context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.ProductosDescuento)
                    .ThenInclude(pd => pd.Descuento)
                .AsQueryable();

            // Filtro por categoría
            if (categoriaId.HasValue)
                query = query.Where(p => p.CategoriaId == categoriaId);

            // Filtro por descripción
            if (!string.IsNullOrWhiteSpace(descripcion))
                query = query.Where(p => p.Descripcion.ToLower().Contains(descripcion.ToLower()));

            // Filtro por precio
            if (precioMin.HasValue)
                query = query.Where(p => p.Precio >= precioMin.Value);

            if (precioMax.HasValue)
                query = query.Where(p => p.Precio <= precioMax.Value);

            // 🔍 Filtro por palabras clave directamente en base de datos
            if (palabras.Length > 0)
            {
                foreach (var pal in palabras)
                {
                    var palabraLocal = pal; // Evitar cierre incorrecto en EF
                    query = query.Where(p =>
                        p.Nombre.ToLower().Contains(palabraLocal) ||
                        p.Descripcion.ToLower().Contains(palabraLocal));
                }
            }

            var productos = await query.ToListAsync();

            // Proyección a modelo de búsqueda
            var resultados = productos.Select(p => new Busquedas
            {
                NombreProducto = p.Nombre,
                ProductoId = p.Id,
                Descripcion = p.Descripcion,
                Categoria = p.Categoria?.Nombre,
                CategoriaId = p.CategoriaId,
                Precio = p.Precio,
                PrecioConDescuento = p.ProductosDescuento
                    .Where(pd => pd.Descuento != null && pd.Descuento.FechaFin > DateTime.Now)
                    .Select(pd => (decimal?)Math.Round(p.Precio - (p.Precio * pd.Descuento.Descuento / 100), 2))
                    .FirstOrDefault() ?? p.Precio,
                UrlImagen = p.UrlImagen,
                Descuento = p.ProductosDescuento
                    .Where(pd => pd.Descuento != null)
                    .Select(pd => (decimal?)pd.Descuento.Descuento)
                    .FirstOrDefault()
            }).ToList();

            return resultados;
        }

        /// <summary>
        /// Inserta un nuevo producto en la base de datos.
        /// </summary>
        /// <param name="productos">Producto a insertar</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PostProductos(Productos productos)
        {
            await context.Productos.AddAsync(productos);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Actualiza los datos de un producto existente.
        /// </summary>
        /// <param name="productos">Producto actualizado</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PutProductos(Productos productos)
        {
            context.Productos.Update(productos);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Elimina un producto según su ID.
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
        public async Task<bool> DeleteProductos(int id)
        {
            var productos = await context.Productos.FindAsync(id);
            if (productos == null) return false;

            context.Productos.Remove(productos);
            await context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Obtiene un producto por su ID.
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <returns>Objeto producto si se encuentra, null si no</returns>
        public async Task<Productos> GetProductoById(int id)
        {
            return await context.Productos.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
