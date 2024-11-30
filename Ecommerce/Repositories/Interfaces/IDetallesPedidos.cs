using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    public interface IDetallesPedidos
    {
        Task<List<DetallesPedidos>> GetDetallesPedidos();

        Task<bool> PostDetallesPedidos(DetallesPedidos detallesPedidos);
        Task<bool> PutDetallesPedidos(DetallesPedidos detallesPedidos);
        Task<bool> DeleteDetallesPedidos(DetallesPedidos detallesPedidos);
    }
}
