using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface IUsuarios
    {
        Task<List<Usuarios>> GetUsuarios();
        Task<bool> PostUsuarios(Usuarios usuarios);
        Task<bool> PutUsuarios(Usuarios usuarios);
        Task<bool> DeleteUsuarios(int id);

        Task<Usuarios> GetUsuarioByCorreoAsync(string correo);  // Obtener un usuario por correo
        Task<Usuarios> GetUsuarioByCodigoAsync(string codigo); // Obtener un usuario por código de verificación
        Task<bool> UpdateUsuarioAsync(Usuarios usuario);       // Nuevo método para actualizar un usuario

    }
}
