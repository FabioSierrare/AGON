using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    public interface IEnvios
    {
        Task<List<Envios>> GetEnvios();

        Task<bool> PostEnvios(Envios detallesPedidos);
        Task<bool> PutEnvios(Envios envios);
        Task<bool> DeleteEnvios(Envios envios);
    }
}
