using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio que gestiona las operaciones CRUD relacionadas con los cupones.
    /// </summary>
    public class CuponesRepository : ICupones
    {
        /// <summary>
        /// Contexto de base de datos para acceder a las entidades.
        /// </summary>
        public readonly E_commerceContext context;

        /// <summary>
        /// Constructor que inyecta el contexto de base de datos.
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public CuponesRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene la lista de todos los cupones.
        /// </summary>
        /// <returns>Lista de cupones</returns>
        public async Task<List<Cupones>> GetCupones()
        {
            var data = await context.Cupones.ToListAsync();
            return data;
        }

        /// <summary>
        /// Agrega un nuevo cupón a la base de datos.
        /// </summary>
        /// <param name="cupones">Objeto cupón a agregar</param>
        /// <returns>True si se guardó correctamente</returns>
        public async Task<bool> PostCupones(Cupones cupones)
        {
            await context.Cupones.AddAsync(cupones);
            await context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Actualiza un cupón existente en la base de datos.
        /// </summary>
        /// <param name="cupones">Cupón con los datos actualizados</param>
        /// <returns>True si la actualización fue exitosa</returns>
        public async Task<bool> PutCupones(Cupones cupones)
        {
            context.Cupones.Update(cupones);
            await context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Elimina un cupón de la base de datos por su ID.
        /// </summary>
        /// <param name="id">ID del cupón a eliminar</param>
        /// <returns>True si se eliminó correctamente, false si no se encontró</returns>
        public async Task<bool> DeleteCupones(int id)
        {
            var cupones = await context.Cupones.FindAsync(id);
            if (cupones == null) return false;

            context.Cupones.Remove(cupones);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
