using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Interfaz para manejar operaciones CRUD relacionadas con cupones de descuento.
    /// </summary>
    public interface ICupones
    {
        /// <summary>
        /// Obtiene todos los cupones disponibles en la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Cupones"/></returns>
        Task<List<Cupones>> GetCupones();

        /// <summary>
        /// Inserta un nuevo cupón en la base de datos.
        /// </summary>
        /// <param name="cupones">Objeto <see cref="Cupones"/> que representa el nuevo cupón</param>
        /// <returns>True si la operación fue exitosa, False si falló</returns>
        Task<bool> PostCupones(Cupones cupones);

        /// <summary>
        /// Actualiza los datos de un cupón existente.
        /// </summary>
        /// <param name="cupones">Objeto <see cref="Cupones"/> con la información actualizada</param>
        /// <returns>True si la actualización fue exitosa, False si falló</returns>
        Task<bool> PutCupones(Cupones cupones);

        /// <summary>
        /// Elimina un cupón de la base de datos usando su ID.
        /// </summary>
        /// <param name="id">ID del cupón a eliminar</param>
        /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
        Task<bool> DeleteCupones(int id);
    }
}
