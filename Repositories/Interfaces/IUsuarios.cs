using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface IUsuarios
    {
        Task<List<Usuarios>> GetUsuarios();
        Task<bool> PostUsuarios(Usuarios usuarios);
        Task<bool> PutUsuarios(Usuarios usuarios);
        Task<bool> DeleteUsuarios(Usuarios usuarios);
    }
}
