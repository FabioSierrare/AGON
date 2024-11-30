using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface IValoraciones
    {
        Task<List<Valoraciones>> GetValoraciones();
        Task<bool> PostValoraciones(Valoraciones valoraciones);
        Task<bool> PutValoraciones(Valoraciones valoraciones);
        Task<bool> DeleteValoraciones(Valoraciones valoraciones);
    }
}
