using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    public interface IDescuentos
    {
        Task<List<Descuentos>> GetDescuentos();
        Task<bool> PostDescuentos(Descuentos descuentos);
        Task<bool> PutDescuentos(Descuentos descuentos);
        Task<bool> DeleteDescuentos(int id);

    }
}
