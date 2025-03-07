using E_Commerce.Context;
using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace E_Commerce.Repositories
{
    public class EnviosRepository : IEnvios
    {
        public readonly E_commerceContext context;

        public EnviosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Envios>> GetEnvios()
        {
            var data = await context.Envios.ToListAsync();
            return data;
        }

        public async Task<bool> PostEnvios(Envios envios)
        {
            await context.Envios.AddAsync(envios);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutEnvios(Envios envios)
        {
            context.Envios.Update(envios);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteEnvios(int id)
        {
            var envios = await context.Envios.FindAsync(id); // Usar 'context' en lugar de '_context'
            if (envios == null) return false; // Si no existe, devolver 'false'

            context.Envios.Remove(envios); // Usar 'context'
            await context.SaveChangesAsync(); // Corregir 'SaveAsync' por 'SaveChangesAsync'
            return true;
        }

        public async Task<List<object>> GetEnviosFiltrados(int idVendedor)
        {
            var data = await context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Envio)
                .Where(p => p.VendedorId == idVendedor)
                .Select(p => (object)new
                {
                    ID_Pedido = p.Id,
                    Cliente = p.Cliente.Nombre,
                    Empresa_Transporte = p.Envio != null ? p.Envio.Empresa : "Sin Envío",
                    Tracking = p.Envio != null ? p.Envio.NumeroGuia : "N/A",
                    Estado_Del_Envio = p.Envio != null ? p.Envio.EstadoEnvio : "Pendiente",
                    FechaEnvio = p.Envio != null ? p.Envio.FechaEnvio : (DateTime?)null,
                    FechaEntrega = p.Envio != null ? p.Envio.FechaEntrega : (DateTime?)null
                })
                .ToListAsync();


            return data;
        }
    }
}
