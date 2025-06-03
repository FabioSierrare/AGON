using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio que gestiona las operaciones CRUD relacionadas con los comentarios.
    /// </summary>
    public class ComentariosRepository : IComentarios
    {
        /// <summary>
        /// Contexto de base de datos para acceder a las entidades.
        /// </summary>
        public readonly E_commerceContext context;

        /// <summary>
        /// Constructor que inyecta el contexto de base de datos.
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public ComentariosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene la lista de todos los comentarios.
        /// </summary>
        /// <returns>Lista de comentarios</returns>
        public async Task<List<Comentarios>> GetComentarios()
        {
            var data = await context.Comentarios.ToListAsync();
            return data;
        }

        /// <summary>
        /// Agrega un nuevo comentario a la base de datos.
        /// </summary>
        /// <param name="comentarios">Objeto comentario a agregar</param>
        /// <returns>True si se guardó correctamente</returns>
        public async Task<bool> PostComentarios(Comentarios comentarios)
        {
            await context.Comentarios.AddAsync(comentarios);
            await context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Actualiza un comentario existente en la base de datos.
        /// </summary>
        /// <param name="comentarios">Comentario con los datos actualizados</param>
        /// <returns>True si la actualización fue exitosa</returns>
        public async Task<bool> PutComentarios(Comentarios comentarios)
        {
            context.Comentarios.Update(comentarios);
            await context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Elimina un comentario de la base de datos por su ID.
        /// </summary>
        /// <param name="id">ID del comentario a eliminar</param>
        /// <returns>True si se eliminó correctamente, false si no se encontró</returns>
        public async Task<bool> DeleteComentarios(int id)
        {
            var comentario = await context.Comentarios.FindAsync(id);
            if (comentario == null) return false;

            context.Comentarios.Remove(comentario);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
