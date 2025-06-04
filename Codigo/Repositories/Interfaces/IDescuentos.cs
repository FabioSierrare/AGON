using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Interfaz para gestionar operaciones CRUD relacionadas con los descuentos.
    /// </summary>
    public interface IDescuentos
    {
        /// <summary>
        /// Obtiene una lista de todos los descuentos registrados.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Descuentos"/></returns>
        Task<List<Descuentos>> GetDescuentos();

        /// <summary>
        /// Crea un nuevo descuento en la base de datos.
        /// </summary>
        /// <param name="descuentos">Objeto <see cref="Descuentos"/> que representa el descuento a registrar.</param>
        /// <returns>True si la operación fue exitosa; de lo contrario, false.</returns>
        Task<bool> PostDescuentos(Descuentos descuentos);

        /// <summary>
        /// Actualiza un descuento existente en la base de datos.
        /// </summary>
        /// <param name="descuentos">Objeto <see cref="Descuentos"/> con la información actualizada.</param>
        /// <returns>True si la operación fue exitosa; de lo contrario, false.</returns>
        Task<bool> PutDescuentos(Descuentos descuentos);

        /// <summary>
        /// Elimina un descuento por su ID.
        /// </summary>
        /// <param name="id">ID del descuento que se desea eliminar.</param>
        /// <returns>True si se eliminó correctamente; de lo contrario, false.</returns>
        Task<bool> DeleteDescuentos(int id);
    }
}
