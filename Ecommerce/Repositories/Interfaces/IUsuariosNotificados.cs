using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface IUsuariosNotificados
    {
        Task<List<UsuariosNotificados>> GetUsuariosNotificados();
        Task<bool> PostUsuariosNotificados(UsuariosNotificados usuariosNotificados);
        Task<bool> PutUsuariosNotificados(UsuariosNotificados usuariosNotificados);
        Task<bool> DeleteUsuariosNotificados(UsuariosNotificados usuariosNotificados);
    }
}
