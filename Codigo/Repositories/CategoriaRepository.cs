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

    public async Task<List<Categorias>> GetCategoria()
    {
        var data = await context.Categorias.ToListAsync();
        return data;
    }

    public async Task<bool> PostCategoria(Categorias categoria)
    {
        await context.Categorias.AddAsync(categoria);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> PutCategoria(Categorias categoria)
    {
        context.Categorias.Update(categoria);
        await context.SaveAsync();
        return true;
    }

    // Implementación del método DeleteCategorias
    public async Task<bool> DeleteCategoria(int id)
    {
        var categoria = await context.Categorias.FindAsync(id);
        if (categoria == null)
            return false;

        context.Categorias.Remove(categoria);
        await context.SaveChangesAsync();
        return true;
    }
}
