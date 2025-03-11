using E_Commerce.Models;

public interface IEstadisticas
{
    Task<List<object>> GetVentasUltimasSemanas(int IdVendedor);
    Task<List<object>> GetProductosMasVendidos(int IdVendedor);
}
