using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface ICategoria
    {
        Task<List<Categoria>> GetCategoria();
        Task<bool> PostCategoria(Categoria categoria);
        Task<bool> PutCategoria(Categoria categoria);
        Task<bool> DeleteCategoria(Categoria categoria);

    }
}
