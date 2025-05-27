using E_Commerce.Models;

public interface IPagos
{
    Task<List<Pagos>> GetPagos();
    Task<bool> PostPagos(Pagos pagos);
    Task<bool> PutPagos(Pagos pagos);
    Task<bool> DeletePagos(int id);  // Este método debe estar aquí
}
