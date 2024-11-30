using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface IReporteAcciones
    {
        Task<List<ReporteAcciones>> GetReporteAcciones();
        Task<bool> PostReporteAcciones(ReporteAcciones reporteAcciones);
        Task<bool> PutReporteAcciones(ReporteAcciones reporteAcciones);
        Task<bool> DeleteReporteAcciones(ReporteAcciones reporteAcciones);
    }
}
