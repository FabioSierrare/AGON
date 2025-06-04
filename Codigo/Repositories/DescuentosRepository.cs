using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio para manejar las operaciones CRUD de la entidad Descuentos.
    /// </summary>
    public class DescuentosRepository : IDescuentos
    {
        /// <summary>
        /// Contexto de base de datos de la aplicación.
        /// </summary>
        private readonly E_commerceContext context;

        /// <summary>
        /// Constructor que recibe el contexto de base de datos mediante inyección de dependencias.
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public DescuentosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene la lista completa de descuentos almacenados en la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos Descuentos</returns>
        public async Task<List<Descuentos>> GetDescuentos()
        {
            var data = await context.Descuentos.ToListAsync();
            return data;
        }

        /// <summary>
        /// Inserta un nuevo descuento en la base de datos.
        /// </summary>
        /// <param name="descuentos">Objeto de tipo Descuentos a insertar</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PostDescuentos(Descuentos descuentos)
        {
            await context.Descuentos.AddAsync(descuentos);
            await context.SaveAsync(); // Guarda los cambios usando método personalizado
            return true;
        }

        /// <summary>
        /// Actualiza un descuento existente en la base de datos.
        /// </summary>
        /// <param name="descuentos">Objeto de tipo Descuentos con los datos actualizados</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PutDescuentos(Descuentos descuentos)
        {
            context.Descuentos.Update(descuentos);
            await context.SaveAsync(); // Guarda los cambios usando método personalizado
            return true;
        }

        /// <summary>
        /// Elimina un descuento de la base de datos mediante su ID.
        /// </summary>
        /// <param name="id">ID del descuento a eliminar</param>
        /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
        public async Task<bool> DeleteDescuentos(int id)
        {
            var notificacion = await context.Descuentos.FindAsync(id);
            if (notificacion == null) return false;

            context.Descuentos.Remove(notificacion);
            await context.SaveChangesAsync(); // Guarda los cambios directamente
            return true;
        }
    }
}
