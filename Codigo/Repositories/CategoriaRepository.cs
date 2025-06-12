using E_Commerce.Models;
using E_Commerce.Context;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Repositories.Interfaces;

/// <summary>
/// Repositorio para manejar operaciones CRUD sobre la entidad Categorias.
/// </summary>
public class CategoriaRepository : ICategoria
{
    private readonly E_commerceContext context;

    /// <summary>
    /// Constructor que inyecta el contexto de la base de datos.
    /// </summary>
    /// <param name="context">Instancia del contexto E_commerceContext.</param>
    public CategoriaRepository(E_commerceContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Obtiene la lista de todas las categorías existentes en la base de datos.
    /// </summary>
    /// <returns>Lista de categorías.</returns>
    public async Task<List<Categorias>> GetCategoria()
    {
        var data = await context.Categorias.ToListAsync();
        return data;
    }

    /// <summary>
    /// Agrega una nueva categoría a la base de datos.
    /// </summary>
    /// <param name="categoria">Objeto de tipo Categorias a agregar.</param>
    /// <returns>True si se agregó correctamente.</returns>
    public async Task<bool> PostCategoria(Categorias categoria)
    {
        await context.Categorias.AddAsync(categoria);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Actualiza una categoría existente en la base de datos.
    /// </summary>
    /// <param name="categoria">Objeto de tipo Categorias con los nuevos datos.</param>
    /// <returns>True si se actualizó correctamente.</returns>
    public async Task<bool> PutCategoria(Categorias categoria)
    {
        context.Categorias.Update(categoria);
        await context.SaveAsync();
        return true;
    }

    /// <summary>
    /// Elimina una categoría de la base de datos por su ID.
    /// </summary>
    /// <param name="id">ID de la categoría a eliminar.</param>
    /// <returns>True si se eliminó correctamente; False si no se encontró.</returns>
    public async Task<bool> DeleteCategoria(int id)
    {
        var categoria = await context.Categorias.FindAsync(id);
        if (categoria == null)
            return false;

        context.Categorias.Remove(categoria);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Productos>> GetProductosPorCategoria(int id)
    {
        return await context.Productos
            .Include(p => p.Categoria)
            .Where(p => p.CategoriaId == id)
            .ToListAsync();
    }
}
