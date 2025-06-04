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
        /// Realiza una búsqueda de productos según palabras clave en el nombre o descripción.
        /// </summary>
        /// <param name="palabra">Palabra o frase a buscar</param>
        /// <returns>Lista de resultados personalizados con descuentos aplicados</returns>
        public Task<List<Busquedas>> GetBusqueda(string palabra)
        {
            var palabras = palabra.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var palabrasMinusculas = palabras.Select(p => p.ToLower()).ToList();

            var resultados = context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.ProductosDescuento)
                    .ThenInclude(pd => pd.Descuento)
                .AsEnumerable()
                .Where(p => palabrasMinusculas.Any(palabra =>
                    p.Nombre.ToLower().Contains(palabra) ||
                    p.Descripcion.ToLower().Contains(palabra)))
                .Select(p => new Busquedas
                {
                    NombreProducto = p.Nombre,
                    Categoria = p.Categoria.Nombre,
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
                })
                .ToList();

            return Task.FromResult(resultados);
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
