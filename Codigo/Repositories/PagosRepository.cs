using E_Commerce.Models;
using E_Commerce.Context;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Repositories.Interfaces;

public class PagosRepository : IPagos
{
    private readonly E_commerceContext context;

    public PagosRepository(E_commerceContext context)
    {
        this.context = context;
    }

    public async Task<List<Pagos>> GetPagos()
    {
        var data = await context.Pagos.ToListAsync();
        return data;
    }

    public async Task<bool> PostPagos(Pagos pagos)
    {
        await context.Pagos.AddAsync(pagos);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> PutPagos(Pagos pagos)
    {
        context.Pagos.Update(pagos);
        await context.SaveAsync();
        return true;
    }

    // Implementación del método DeleteCategorias
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
