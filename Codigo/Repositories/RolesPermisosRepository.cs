using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio que gestiona las operaciones CRUD relacionadas con los RolesPermisos.
    /// </summary>
    public class RolesPermisosRepository : IRolesPermisos
    {
        /// <summary>
        /// Contexto de base de datos inyectado.
        /// </summary>
        private readonly E_commerceContext context;

        /// <summary>
        /// Constructor que inicializa el repositorio con el contexto proporcionado.
        /// </summary>
        /// <param name="context">Instancia del contexto de base de datos</param>
        public RolesPermisosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene todos los registros de RolesPermisos.
        /// </summary>
        /// <returns>Lista de objetos RolesPermisos</returns>
        public async Task<List<RolesPermisos>> GetRolesPermisos()
        {
            var data = await context.RolesPermisos.ToListAsync();
            return data;
        }

        /// <summary>
        /// Inserta un nuevo registro en RolesPermisos.
        /// </summary>
        /// <param name="rolesPermisos">Objeto RolesPermisos a insertar</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PostRolesPermisos(RolesPermisos rolesPermisos)
        {
            await context.RolesPermisos.AddAsync(rolesPermisos);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Actualiza un registro existente de RolesPermisos.
        /// </summary>
        /// <param name="rolesPermisos">Objeto RolesPermisos con los datos actualizados</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PutRolesPermisos(RolesPermisos rolesPermisos)
        {
            context.RolesPermisos.Update(rolesPermisos);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Elimina un registro de RolesPermisos por su ID.
        /// </summary>
        /// <param name="id">ID del registro a eliminar</param>
        /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
        public async Task<bool> DeleteRolesPermisos(int id)
        {
            var notificacion = await context.RolesPermisos.FindAsync(id);
            if (notificacion == null) return false;

            context.RolesPermisos.Remove(notificacion);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
