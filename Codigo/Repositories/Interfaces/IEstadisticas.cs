using E_Commerce.Models;

/// <summary>
/// Define los métodos para obtener estadísticas relacionadas con ventas y productos.
/// </summary>
public interface IEstadisticas
{
    /// <summary>
    /// Obtiene el total de ventas y cantidad de productos vendidos en las últimas 4 semanas agrupados por semana.
    /// </summary>
    /// <param name="IdVendedor">El identificador del vendedor para filtrar los datos.</param>
    /// <returns>Una lista de objetos anónimos que representan las estadísticas semanales de ventas.</returns>
    Task<List<object>> GetVentasUltimasSemanas(int IdVendedor);

    /// <summary>
    /// Obtiene los productos más vendidos por un vendedor específico.
    /// </summary>
    /// <param name="IdVendedor">El identificador del vendedor para filtrar los productos vendidos.</param>
    /// <returns>Una lista de objetos anónimos que representan los productos más vendidos.</returns>
    Task<List<object>> GetProductosMasVendidos(int IdVendedor);
}
