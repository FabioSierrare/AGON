using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio para gestionar las operaciones relacionadas con los usuarios.
    /// </summary>
    public class UsuariosRepository : IUsuarios
    {
        private readonly E_commerceContext context;

        /// <summary>
        /// Constructor que recibe el contexto de la base de datos.
        /// </summary>
        /// <param name="context">Contexto de la base de datos</param>
        public UsuariosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene la lista completa de usuarios.
        /// </summary>
        /// <returns>Lista de objetos Usuarios</returns>
        public async Task<List<Usuarios>> GetUsuarios()
        {
            var data = await context.Usuarios.ToListAsync();
            return data;
        }

        /// <summary>
        /// Inserta un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="usuarios">Objeto de tipo Usuarios</param>
        /// <returns>True si se guardó correctamente</returns>
        public async Task<bool> PostUsuarios(Usuarios usuarios)
        {
            await context.Usuarios.AddAsync(usuarios);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        /// <param name="usuarios">Objeto Usuarios con los datos actualizados</param>
        /// <returns>True si la actualización fue exitosa</returns>
        public async Task<bool> PutUsuarios(Usuarios usuarios)
        {
            context.Usuarios.Update(usuarios);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Elimina un usuario por su ID.
        /// </summary>
        /// <param name="id">ID del usuario a eliminar</param>
        /// <returns>True si se eliminó, False si no se encontró</returns>
        public async Task<bool> DeleteUsuarios(int id)
        {
            var usuario = await context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }

            context.Usuarios.Remove(usuario);
            await context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Obtiene un usuario por su correo electrónico.
        /// </summary>
        /// <param name="correo">Correo del usuario</param>
        /// <returns>Objeto Usuarios si se encuentra, null si no</returns>
        public async Task<Usuarios> GetUsuarioByCorreoAsync(string correo)
        {
            return await context.Usuarios.FirstOrDefaultAsync(u => u.Correo == correo);
        }

        /// <summary>
        /// Obtiene un usuario a través del código de verificación.
        /// </summary>
        /// <param name="codigo">Código de verificación de recuperación</param>
        /// <returns>Objeto Usuarios si se encuentra, null si no</returns>
        public async Task<Usuarios> GetUsuarioByCodigoAsync(string codigo)
        {
            return await context.Usuarios.FirstOrDefaultAsync(u => u.CodigoVerificacion == codigo);
        }

        /// <summary>
        /// Actualiza un usuario en la base de datos.
        /// </summary>
        /// <param name="usuario">Objeto Usuarios a actualizar</param>
        /// <returns>True si se guardaron los cambios</returns>
        public async Task<bool> UpdateUsuarioAsync(Usuarios usuario)
        {
            context.Usuarios.Update(usuario);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
