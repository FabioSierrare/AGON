using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    public interface IEstadisticasVentas
    {
        Task<List<EstadisticasVentas>> GetEstadisticasVentas();
        Task<bool> PostEstadisticasVentas(EstadisticasVentas estadisticasVentas);
        Task<bool> PutEstadisticasVentas(EstadisticasVentas estadisticasVentas);
        Task<bool> DeleteEstadisticasVentas(EstadisticasVentas estadisticasVentas);
    }
}
