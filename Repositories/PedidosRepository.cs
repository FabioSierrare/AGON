using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class PedidosRepository : IPedidos
    {
        private readonly E_commerceContext context;

        public PedidosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Pedidos>> GetPedidos()
        {
            var data = await context.Pedidos.ToListAsync();
            return data;
        }

        public async Task<bool> PostPedidos(Pedidos pedidos)
        {
            await context.Pedidos.AddAsync(pedidos);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutPedidos(Pedidos pedidos)
        {
            context.Pedidos.Update(pedidos);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeletePedidos(int id)
        {
            var notificacion = await context.Notificaciones.FindAsync(id);
            if (notificacion == null) return false;

            context.Notificaciones.Remove(notificacion);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
