using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    public interface IRolesPermisos
    {
        Task<List<RolesPermisos>> GetRolesPermisos();
        Task<bool> PostRolesPermisos(RolesPermisos rolesPermisos);
        Task<bool> PutRolesPermisos(RolesPermisos rolesPermisos);
        Task<bool> DeleteRolesPermisos(RolesPermisos rolesPermisos);
    }
}
