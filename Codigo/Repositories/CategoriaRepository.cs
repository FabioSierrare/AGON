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
        await context.SaveAsync();
        return true;
    }

    // Implementación del método DeleteCategorias
    public async Task<bool> DeleteCategoria(int id)
    {
        var categoria = await context.Categoria.FindAsync(id);
        if (categoria == null)
            return false;

        context.Categoria.Remove(categoria);
        await context.SaveChangesAsync();
        return true;
    }
}
