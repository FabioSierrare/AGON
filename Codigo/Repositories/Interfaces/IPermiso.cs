using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    public interface IPermiso
    {
        Task<List<Permisos>> GetPermiso();
        Task<bool> PostPermiso(Permisos permiso);
        Task<bool> PutPermiso(Permisos permiso);
        Task<bool> DeletePermiso(int id );
    }
}
