using E_Commerce.Context;
using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio que gestiona las operaciones CRUD para la entidad Envios.
    /// </summary>
    public class EnviosRepository : IEnvios
    {
        /// <summary>
        /// Contexto de base de datos de E-Commerce.
        /// </summary>
        public readonly E_commerceContext context;

        /// <summary>
        /// Constructor que inyecta el contexto de base de datos.
        /// </summary>
        /// <param name="context">Instancia de E_commerceContext</param>
        public EnviosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene todos los registros de envíos.
        /// </summary>
        /// <returns>Lista de objetos Envios</returns>
        public async Task<List<Envios>> GetEnvios()
        {
            var data = await context.Envios.ToListAsync();
            return data;
        }

        /// <summary>
        /// Inserta un nuevo registro de envío.
        /// </summary>
        /// <param name="envios">Objeto Envios a agregar</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PostEnvios(Envios envios)
        {
            await context.Envios.AddAsync(envios);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Actualiza un registro de envío existente.
        /// </summary>
        /// <param name="envios">Objeto Envios con los datos actualizados</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PutEnvios(Envios envios)
        {
            context.Envios.Update(envios);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Elimina un registro de envío por su ID.
        /// </summary>
        /// <param name="id">ID del envío a eliminar</param>
        /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
        public async Task<bool> DeleteEnvios(int id)
        {
            var envios = await context.Envios.FindAsync(id);
            if (envios == null) return false;

            context.Envios.Remove(envios);
            await context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Obtiene los envíos relacionados con pedidos filtrados por el ID del vendedor.
        /// </summary>
        /// <param name="idVendedor">ID del vendedor</param>
        /// <returns>Lista de objetos Envio personalizados con información combinada</returns>
        public async Task<List<Envio>> GetEnviosFiltrados(int idVendedor)
        {
            var data = await context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Envio)
                .Where(p => p.VendedorId == idVendedor)
                .Select(p => new Envio
                {
                    ID_Pedido = p.Id,
                    Cliente = p.Cliente.Nombre,
                    Empresa_Transporte = p.Envio != null ? p.Envio.Empresa : "Sin Envío",
                    Tracking = p.Envio != null ? p.Envio.NumeroGuia : "N/A",
                    EstadoEnvio = p.Envio != null ? p.Envio.EstadoEnvio : "Pendiente",
                    FechaEnvio = p.Envio != null ? p.Envio.FechaEnvio : (DateTime?)null,
                    FechaEntrega = p.Envio != null ? p.Envio.FechaEntrega : (DateTime?)null
                })
                .ToListAsync();

            return data;
        }
    }
}
