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
            var pedidos = await context.Pedidos.FindAsync(id);
            if (pedidos == null) return false;

            context.Pedidos.Remove(pedidos);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
