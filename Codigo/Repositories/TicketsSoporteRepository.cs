using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio que maneja las operaciones CRUD para los tickets de soporte.
    /// </summary>
    public class TicketsSoporteRepository : ITicketsSoporte
    {
        /// <summary>
        /// Contexto de base de datos inyectado.
        /// </summary>
        private readonly E_commerceContext context;

        /// <summary>
        /// Constructor que inicializa el repositorio con el contexto proporcionado.
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public TicketsSoporteRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene todos los tickets de soporte registrados en la base de datos.
        /// </summary>
        /// <returns>Lista de objetos TicketsSoporte</returns>
        public async Task<List<TicketsSoporte>> GetTicketsSoporte()
        {
            var data = await context.TicketsSoporte.ToListAsync();
            return data;
        }

        /// <summary>
        /// Inserta un nuevo ticket de soporte.
        /// </summary>
        /// <param name="ticketsSoporte">Objeto TicketsSoporte a insertar</param>
        /// <returns>True si se insertó correctamente</returns>
        public async Task<bool> PostTicketsSoporte(TicketsSoporte ticketsSoporte)
        {
            await context.TicketsSoporte.AddAsync(ticketsSoporte);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Actualiza un ticket de soporte existente.
        /// </summary>
        /// <param name="ticketsSoporte">Objeto TicketsSoporte con datos actualizados</param>
        /// <returns>True si se actualizó correctamente</returns>
        public async Task<bool> PutTicketsSoporte(TicketsSoporte ticketsSoporte)
        {
            context.TicketsSoporte.Update(ticketsSoporte);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Elimina un ticket de soporte por su ID.
        /// </summary>
        /// <param name="id">ID del ticket a eliminar</param>
        /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
        public async Task<bool> DeleteTicketsSoporte(int id)
        {
            var notificacion = await context.TicketsSoporte.FindAsync(id);
            if (notificacion == null) return false;

            context.TicketsSoporte.Remove(notificacion);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
