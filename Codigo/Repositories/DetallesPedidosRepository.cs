using E_Commerce.Context;
using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio para manejar las operaciones CRUD de la entidad DetallesPedidos.
    /// </summary>
    public class DetallesPedidosRepository : IDetallesPedidos
    {
        /// <summary>
        /// Contexto de base de datos inyectado.
        /// </summary>
        public readonly E_commerceContext context;

        /// <summary>
        /// Constructor que inicializa el repositorio con el contexto proporcionado.
        /// </summary>
        /// <param name="context">Instancia del contexto de la base de datos</param>
        public DetallesPedidosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene la lista de todos los detalles de pedidos.
        /// </summary>
        /// <returns>Lista de objetos DetallesPedidos</returns>
        public async Task<List<DetallesPedidos>> GetDetallesPedidos()
        {
            var data = await context.DetallesPedidos.ToListAsync();
            return data;
        }

        /// <summary>
        /// Inserta un nuevo detalle de pedido en la base de datos.
        /// </summary>
        /// <param name="detallesPedidos">Objeto DetallesPedidos a insertar</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PostDetallesPedidos(DetallesPedidos detallesPedidos)
        {
            await context.DetallesPedidos.AddAsync(detallesPedidos);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Actualiza un detalle de pedido existente en la base de datos.
        /// </summary>
        /// <param name="detallesPedidos">Objeto DetallesPedidos con la información actualizada</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PutDetallesPedidos(DetallesPedidos detallesPedidos)
        {
            context.DetallesPedidos.Update(detallesPedidos);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Elimina un detalle de pedido por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de pedido a eliminar</param>
        /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
        public async Task<bool> DeleteDetallesPedidos(int id)
        {
            var detalle = await context.DetallesPedidos.FindAsync(id);
            if (detalle == null) return false;

            context.DetallesPedidos.Remove(detalle);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
