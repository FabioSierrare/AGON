using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio encargado de gestionar las operaciones CRUD para los reportes de acciones del sistema.
    /// </summary>
    public class ReporteAccionesRepository : IReporteAcciones
    {
        /// <summary>
        /// Contexto de base de datos inyectado.
        /// </summary>
        private readonly E_commerceContext context;

        /// <summary>
        /// Constructor que inicializa el repositorio con el contexto proporcionado.
        /// </summary>
        /// <param name="context">Instancia del contexto de base de datos</param>
        public ReporteAccionesRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene una lista de todos los reportes de acciones.
        /// </summary>
        /// <returns>Lista de objetos ReporteAcciones</returns>
        public async Task<List<ReporteAcciones>> GetReporteAcciones()
        {
            var data = await context.ReporteAcciones.ToListAsync();
            return data;
        }

        /// <summary>
        /// Inserta un nuevo registro de reporte de acción en la base de datos.
        /// </summary>
        /// <param name="reporteAcciones">Objeto ReporteAcciones a insertar</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PostReporteAcciones(ReporteAcciones reporteAcciones)
        {
            await context.ReporteAcciones.AddAsync(reporteAcciones);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Actualiza un reporte de acción existente en la base de datos.
        /// </summary>
        /// <param name="reporteAcciones">Objeto ReporteAcciones con la información actualizada</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PutReporteAcciones(ReporteAcciones reporteAcciones)
        {
            context.ReporteAcciones.Update(reporteAcciones);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Elimina un reporte de acción por su ID.
        /// </summary>
        /// <param name="id">ID del reporte de acción a eliminar</param>
        /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
        public async Task<bool> DeleteReporteAcciones(int id)
        {
            var notificacion = await context.ReporteAcciones.FindAsync(id);
            if (notificacion == null) return false;

            context.ReporteAcciones.Remove(notificacion);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
