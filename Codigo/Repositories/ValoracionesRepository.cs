using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio para gestionar operaciones CRUD sobre la entidad Valoraciones.
    /// </summary>
    public class ValoracionesRepository : IValoraciones
    {
        private readonly E_commerceContext context;

        /// <summary>
        /// Constructor que inicializa el contexto de base de datos.
        /// </summary>
        /// <param name="context">Contexto de base de datos inyectado</param>
        public ValoracionesRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene todas las valoraciones registradas en la base de datos.
        /// </summary>
        /// <returns>Lista de valoraciones</returns>
        public async Task<List<Valoraciones>> GetValoraciones()
        {
            var data = await context.Valoraciones.ToListAsync();
            return data;
        }

        /// <summary>
        /// Inserta una nueva valoración en la base de datos.
        /// </summary>
        /// <param name="valoraciones">Objeto Valoraciones a insertar</param>
        /// <returns>True si se insertó correctamente</returns>
        public async Task<bool> PostValoraciones(Valoraciones valoraciones)
        {
            await context.Valoraciones.AddAsync(valoraciones);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Actualiza una valoración existente.
        /// </summary>
        /// <param name="valoraciones">Objeto Valoraciones con datos actualizados</param>
        /// <returns>True si se actualizó correctamente</returns>
        public async Task<bool> PutValoraciones(Valoraciones valoraciones)
        {
            context.Valoraciones.Update(valoraciones);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Elimina una valoración por su ID.
        /// </summary>
        /// <param name="id">ID de la valoración a eliminar</param>
        /// <returns>True si fue eliminada, false si no existe</returns>
        public async Task<bool> DeleteValoraciones(int id)
        {
            var valoracion = await context.Valoraciones.FindAsync(id);
            if (valoracion == null)
                return false;

            context.Valoraciones.Remove(valoracion);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
