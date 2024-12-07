using E_Commerce.Models;
using E_Commerce.Context;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Repositories.Interfaces;

public class CategoriaRepository : ICategoria
{
    private readonly E_commerceContext context;

    public CategoriaRepository(E_commerceContext context)
    {
        this.context = context;
    }

    public async Task<List<Categoria>> GetCategoria()
    {
        var data = await context.Categoria.ToListAsync();
        return data;
    }

    public async Task<bool> PostCategoria(Categoria categoria)
    {
        await context.Categoria.AddAsync(categoria);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> PutCategoria(Categoria categoria)
    {
        context.Categoria.Update(categoria);
        await context.SaveChangesAsync();
        return true;
    }

    // Implementación del método DeleteCategorias
    public async Task<bool> DeleteCategoria(int id)
    {
        var comentario = await context.Comentarios.FindAsync(id); // Usar 'context' en lugar de '_context'
        if (comentario == null) return false; // Si no existe, devolver 'false'

        context.Comentarios.Remove(comentario); // Usar 'context'
        await context.SaveChangesAsync(); // Corregir 'SaveAsync' por 'SaveChangesAsync'
        return true;
    }
}
