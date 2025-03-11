using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface IDescuentos
    {
        Task<List<Descuentos>> GetPromociones();
        Task<bool> PostPromociones(Descuentos descuentos);
        Task<bool> PutPromociones(Descuentos descuentos);
        Task<bool> DeletePromociones(int id);

    }
}
