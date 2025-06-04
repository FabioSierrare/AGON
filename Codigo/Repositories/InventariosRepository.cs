using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio que gestiona las operaciones CRUD para la entidad Inventarios.
    /// </summary>
    public class InventariosRepository : IInventarios
    {
        /// <summary>
        /// Contexto de base de datos inyectado.
        /// </summary>
        private readonly E_commerceContext context;

        /// <summary>
        /// Constructor que inicializa el repositorio con el contexto proporcionado.
        /// </summary>
        /// <param name="context">Instancia del contexto de base de datos</param>
        public InventariosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene la lista completa de inventarios.
        /// </summary>
        /// <returns>Lista de objetos Inventarios</returns>
        public async Task<List<Inventarios>> GetInventarios()
        {
            var data = await context.Inventarios.ToListAsync();
            return data;
        }

        /// <summary>
        /// Inserta un nuevo registro de inventario en la base de datos.
        /// </summary>
        /// <param name="inventarios">Objeto Inventarios a insertar</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PostInventarios(Inventarios inventarios)
        {
            await context.Inventarios.AddAsync(inventarios);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Actualiza un registro de inventario existente.
        /// </summary>
        /// <param name="inventarios">Objeto Inventarios a actualizar</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PutInventarios(Inventarios inventarios)
        {
            context.Inventarios.Update(inventarios);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Elimina un registro de inventario por su ID.
        /// </summary>
        /// <param name="id">ID del inventario a eliminar</param>
        /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
        public async Task<bool> DeleteInventarios(int id)
        {
            var inventaios = await context.Inventarios.FindAsync(id);
            if (inventaios == null) return false;

            context.Inventarios.Remove(inventaios);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
