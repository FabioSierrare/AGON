﻿using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    public interface IProductos
    {
        Task<List<Productos>> GetProductos();
        Task<List<Busquedas>> GetBusqueda(string palabra);
        Task<bool> PostProductos(Productos productos);
        Task<bool> PutProductos(Productos productos);
        Task<bool> DeleteProductos(int id);

        Task<Productos> GetProductoById(int id);
    }
}
