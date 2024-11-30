using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    public interface IInventarios
    {
        Task<List<Inventarios>> GetInventarios();
        Task<bool> PostInventarios(Inventarios inventarios);
        Task<bool> PutInventarios(Inventarios inventarios);
        Task<bool> DeleteInventarios(Inventarios inventarios);
    }
}
