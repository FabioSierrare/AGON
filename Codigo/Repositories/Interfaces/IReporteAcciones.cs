using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define las operaciones relacionadas con el manejo de reportes de acciones en el sistema.
    /// </summary>
    public interface IReporteAcciones
    {
        /// <summary>
        /// Obtiene una lista de todos los reportes de acciones registrados.
        /// </summary>
        /// <returns>
        /// Una lista de objetos <see cref="ReporteAcciones"/>.
        /// </returns>
        Task<List<ReporteAcciones>> GetReporteAcciones();

        /// <summary>
        /// Registra un nuevo reporte de acción en la base de datos.
        /// </summary>
        /// <param name="reporteAcciones">El objeto <see cref="ReporteAcciones"/> que se desea registrar.</param>
        /// <returns>
        /// Verdadero si el registro fue exitoso, falso en caso contrario.
        /// </returns>
        Task<bool> PostReporteAcciones(ReporteAcciones reporteAcciones);

        /// <summary>
        /// Actualiza un reporte de acción existente.
        /// </summary>
        /// <param name="reporteAcciones">El objeto <see cref="ReporteAcciones"/> con los datos actualizados.</param>
        /// <returns>
        /// Verdadero si la actualización fue exitosa, falso en caso contrario.
        /// </returns>
        Task<bool> PutReporteAcciones(ReporteAcciones reporteAcciones);

        /// <summary>
        /// Elimina un reporte de acción según su ID.
        /// </summary>
        /// <param name="id">El identificador único del reporte a eliminar.</param>
        /// <returns>
        /// Verdadero si se eliminó correctamente, falso si no se encontró.
        /// </returns>
        Task<bool> DeleteReporteAcciones(int id);
    }
}
