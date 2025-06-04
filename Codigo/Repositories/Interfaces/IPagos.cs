using E_Commerce.Models;

/// <summary>
/// Define las operaciones para la gestión de pagos en el sistema.
/// </summary>
public interface IPagos
{
    /// <summary>
    /// Obtiene todos los pagos registrados.
    /// </summary>
    /// <returns>Una lista de objetos <see cref="Pagos"/>.</returns>
    Task<List<Pagos>> GetPagos();

    /// <summary>
    /// Registra un nuevo pago.
    /// </summary>
    /// <param name="pagos">El objeto <see cref="Pagos"/> que se desea registrar.</param>
    /// <returns>Un valor booleano que indica si la operación fue exitosa.</returns>
    Task<bool> PostPagos(Pagos pagos);

    /// <summary>
    /// Actualiza la información de un pago existente.
    /// </summary>
    /// <param name="pagos">El objeto <see cref="Pagos"/> con los datos actualizados.</param>
    /// <returns>Un valor booleano que indica si la operación fue exitosa.</returns>
    Task<bool> PutPagos(Pagos pagos);

    /// <summary>
    /// Elimina un pago a partir de su identificador.
    /// </summary>
    /// <param name="id">El identificador del pago que se desea eliminar.</param>
    /// <returns>Un valor booleano que indica si la operación fue exitosa.</returns>
    Task<bool> DeletePagos(int id);
}
