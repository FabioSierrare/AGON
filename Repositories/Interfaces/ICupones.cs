using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    public interface ICupones
    {
        Task<List<Cupones>> GetCupones();
        Task<bool> PostCupones(Cupones cupones);
        Task<bool> PutCupones(Cupones cupones);
        Task<bool> DeleteCupones(Cupones cupones);

    }
}
