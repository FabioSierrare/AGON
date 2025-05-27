using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    public interface IPedidos
    {
        Task<List<Pedidos>> GetPedidos();
        Task<Pedidos> GetPedidoById(int id);
        Task<Pedidos> PostPedidos(Pedidos pedidos);
        Task<bool> PutPedidos(Pedidos pedidos);
        Task<bool> DeletePedidos(int id);
        Task<List<object>> GetIngresosPorDia(); // Nuevo método
        Task<List<object>> GetProductosMasVendidos(); // Nuevo método
    }
}
