using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio que gestiona las operaciones CRUD para la entidad Permisos.
    /// </summary>
    public class PermisoRepository : IPermiso
    {
        /// <summary>
        /// Contexto de la base de datos inyectado.
        /// </summary>
        private readonly E_commerceContext context;

        /// <summary>
        /// Constructor que inicializa el repositorio con el contexto proporcionado.
        /// </summary>
        /// <param name="context">Instancia del contexto de la base de datos</param>
        public PermisoRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene la lista de todos los permisos existentes.
        /// </summary>
        /// <returns>Lista de objetos Permisos</returns>
        public async Task<List<Permisos>> GetPermiso()
        {
            var data = await context.Permisos.ToListAsync();
            return data;
        }

        /// <summary>
        /// Inserta un nuevo permiso en la base de datos.
        /// </summary>
        /// <param name="permiso">Objeto Permisos a insertar</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PostPermiso(Permisos permiso)
        {
            await context.Permisos.AddAsync(permiso);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Actualiza un permiso existente en la base de datos.
        /// </summary>
        /// <param name="permisos">Objeto Permisos a actualizar</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PutPermiso(Permisos permisos)
        {
            context.Permisos.Update(permisos);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Elimina un permiso por su ID.
        /// </summary>
        /// <param name="id">ID del permiso a eliminar</param>
        /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
        public async Task<bool> DeletePermiso(int id)
        {
            var Permiso = await context.Permisos.FindAsync(id);
            if (Permiso == null) return false;

            context.Permisos.Remove(Permiso);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
