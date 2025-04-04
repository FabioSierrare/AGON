﻿using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
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
