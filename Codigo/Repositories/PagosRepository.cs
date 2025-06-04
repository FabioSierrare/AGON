using E_Commerce.Models;
using E_Commerce.Context;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Repositories.Interfaces;

/// <summary>
/// Repositorio que gestiona las operaciones CRUD para la entidad Pagos.
/// </summary>
public class PagosRepository : IPagos
{
    /// <summary>
    /// Contexto de base de datos inyectado.
    /// </summary>
    private readonly E_commerceContext context;

    /// <summary>
    /// Constructor que inicializa el repositorio con el contexto proporcionado.
    /// </summary>
    /// <param name="context">Instancia del contexto de la base de datos</param>
    public PagosRepository(E_commerceContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Obtiene la lista de todos los pagos registrados.
    /// </summary>
    /// <returns>Lista de objetos Pagos</returns>
    public async Task<List<Pagos>> GetPagos()
    {
        var data = await context.Pagos.ToListAsync();
        return data;
    }

    /// <summary>
    /// Inserta un nuevo pago en la base de datos.
    /// </summary>
    /// <param name="pagos">Objeto Pagos a insertar</param>
    /// <returns>True si la operación fue exitosa</returns>
    public async Task<bool> PostPagos(Pagos pagos)
    {
        await context.Pagos.AddAsync(pagos);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Actualiza un pago existente en la base de datos.
    /// </summary>
    /// <param name="pagos">Objeto Pagos con los datos actualizados</param>
    /// <returns>True si la operación fue exitosa</returns>
    public async Task<bool> PutPagos(Pagos pagos)
    {
        context.Pagos.Update(pagos);
        await context.SaveAsync();
        return true;
    }

    /// <summary>
    /// Elimina un pago por su ID.
    /// </summary>
    /// <param name="id">ID del pago a eliminar</param>
    /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
    public async Task<bool> DeletePagos(int id)
    {
        var pagos = await context.Pagos.FindAsync(id);
        if (pagos == null)
            return false;

        context.Pagos.Remove(pagos);
        await context.SaveChangesAsync();
        return true;
    }
}
