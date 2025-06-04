using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio que gestiona las operaciones CRUD para los registros del sistema (LogsSistema).
    /// </summary>
    public class LogsSistemaRepository : ILogsSistema
    {
        /// <summary>
        /// Contexto de base de datos inyectado.
        /// </summary>
        private readonly E_commerceContext context;

        /// <summary>
        /// Constructor que recibe el contexto de base de datos.
        /// </summary>
        /// <param name="context">Instancia del contexto de la base de datos</param>
        public LogsSistemaRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene todos los registros del sistema (logs).
        /// </summary>
        /// <returns>Lista de objetos LogsSistema</returns>
        public async Task<List<LogsSistema>> GetLogsSistema()
        {
            var data = await context.LogsSistema.ToListAsync();
            return data;
        }

        /// <summary>
        /// Inserta un nuevo log en la base de datos.
        /// </summary>
        /// <param name="logsSistema">Objeto LogsSistema a insertar</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PostLogsSistema(LogsSistema logsSistema)
        {
            await context.LogsSistema.AddAsync(logsSistema);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Actualiza un registro existente de logs del sistema.
        /// </summary>
        /// <param name="logsSistema">Objeto LogsSistema con los datos actualizados</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PutLogsSistema(LogsSistema logsSistema)
        {
            context.LogsSistema.Update(logsSistema);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Elimina un log del sistema según su ID.
        /// </summary>
        /// <param name="id">ID del log a eliminar</param>
        /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
        public async Task<bool> DeleteLogsSistema(int id)
        {
            var logsSistema = await context.LogsSistema.FindAsync(id);
            if (logsSistema == null) return false;

            context.LogsSistema.Remove(logsSistema);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
