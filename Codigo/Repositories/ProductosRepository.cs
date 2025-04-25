using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class ProductosRepository : IProductos
    {
        private readonly E_commerceContext context;

        public ProductosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Productos>> GetProductos()
        {
            var data = await context.Productos.ToListAsync();
            return data;
        }

        public Task<List<Busquedas>> GetBusqueda(string palabra)
        {
            var palabras = palabra.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);


            var palabrasMinusculas = palabras.Select(p => p.ToLower()).ToList();

            var resultados = context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.ProductosDescuento)
                    .ThenInclude(pd => pd.Descuento)
                .AsEnumerable() // Cambia la evaluación a memoria (requerido para .ToLower y Contains)
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

        public async Task<bool> PostProductos(Productos productos)
        {
            await context.Productos.AddAsync(productos);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutProductos(Productos productos)
        {
            context.Productos.Update(productos);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteProductos(int id)
        {
            var productos = await context.Productos.FindAsync(id);
            if (productos == null) return false;

            context.Productos.Remove(productos);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<Productos> GetProductoById(int id)
        {
            return await context.Productos.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
