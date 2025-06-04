using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio que gestiona las operaciones CRUD y consultas adicionales para la entidad Pedidos.
    /// </summary>
    public class PedidosRepository : IPedidos
    {
        /// <summary>
        /// Contexto de base de datos.
        /// </summary>
        private readonly E_commerceContext context;

        /// <summary>
        /// Constructor que inicializa el repositorio con el contexto proporcionado.
        /// </summary>
        /// <param name="context">Instancia del contexto de la base de datos</param>
        public PedidosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene la lista de todos los pedidos.
        /// </summary>
        /// <returns>Lista de objetos Pedidos</returns>
        public async Task<List<Pedidos>> GetPedidos()
        {
            var data = await context.Pedidos.ToListAsync();
            return data;
        }

        /// <summary>
        /// Inserta un nuevo pedido y retorna el objeto completo con el ID generado.
        /// </summary>
        /// <param name="pedido">Objeto Pedido a insertar</param>
        /// <returns>Objeto Pedido con el ID asignado</returns>
        public async Task<Pedidos?> PostPedidos(Pedidos pedido)
        {
            context.Pedidos.Add(pedido);
            await context.SaveChangesAsync();
            return pedido;
        }

        /// <summary>
        /// Actualiza un pedido existente en la base de datos.
        /// </summary>
        /// <param name="pedidos">Objeto Pedido con los datos actualizados</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PutPedidos(Pedidos pedidos)
        {
            context.Pedidos.Update(pedidos);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Elimina un pedido por su ID.
        /// </summary>
        /// <param name="id">ID del pedido a eliminar</param>
        /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
        public async Task<bool> DeletePedidos(int id)
        {
            var pedidos = await context.Pedidos.FindAsync(id);
            if (pedidos == null) return false;

            context.Pedidos.Remove(pedidos);
            await context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Obtiene un pedido específico por su ID.
        /// </summary>
        /// <param name="id">ID del pedido</param>
        /// <returns>Objeto Pedido si se encuentra, null si no existe</returns>
        public async Task<Pedidos?> GetPedidoById(int id)
        {
            return await context.Pedidos.FindAsync(id);
        }

        /// <summary>
        /// Obtiene los ingresos diarios agrupados por fecha.
        /// </summary>
        /// <returns>Lista de objetos con fecha e ingresos totales por día</returns>
        public async Task<List<object>> GetIngresosPorDia()
        {
            var ingresos = await context.Pedidos
                .GroupBy(p => p.FechaPedido.Date)
                .Select(g => new
                {
                    Fecha = g.Key,
                    TotalIngresos = g.Sum(p => p.Total)
                })
                .OrderBy(g => g.Fecha)
                .ToListAsync();

            return ingresos
                .Select(g => new
                {
                    Fecha = g.Fecha.ToString("yyyy-MM-dd"),
                    TotalIngresos = g.TotalIngresos
                })
                .Cast<object>()
                .ToList();
        }

        /// <summary>
        /// Obtiene los 5 productos más vendidos con sus cantidades.
        /// </summary>
        /// <returns>Lista de objetos con ID, nombre del producto y cantidad vendida</returns>
        public async Task<List<object>> GetProductosMasVendidos()
        {
            var productos = await context.Pedidos
                .GroupBy(d => d.ProductoId)
                .Select(g => new
                {
                    ProductoID = g.Key,
                    Producto = context.Productos
                        .Where(p => p.Id == g.Key)
                        .Select(p => p.Nombre)
                        .FirstOrDefault(),
                    CantidadVendida = g.Sum(d => d.Cantidad)
                })
                .OrderByDescending(g => g.CantidadVendida)
                .Take(5)
                .ToListAsync();

            return productos.Cast<object>().ToList();
        }
    }
}
