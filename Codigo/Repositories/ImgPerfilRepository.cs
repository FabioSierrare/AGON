using E_Commerce.Models;
using E_Commerce.Context;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Repositories.Interfaces;

public class ImgPerfilRepository : IImgPerfil
{
    private readonly E_commerceContext context;

    public ImgPerfilRepository(E_commerceContext context)
    {
        this.context = context;
    }

    public async Task<List<ImgPerfil>> GetImgPerfil()
    {
        var data = await context.ImgPerfil.ToListAsync();
        return data;
    }
    
    public async Task<bool> PostImgPerfil(ImgPerfil imgPerfil)
    {
        await context.ImgPerfil.AddAsync(imgPerfil);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> PutImgPerfil(ImgPerfil imgPerfil)
    {
        context.ImgPerfil.Update(imgPerfil);
        await context.SaveChangesAsync(); // <-- CORREGIDO
        return true;
    }


    // Implementación del método DeleteCategorias
    public async Task<bool> DeleteImgPerfil(int id)
    {
        var imgPerfil = await context.ImgPerfil.FindAsync(id);
        if (imgPerfil == null)
            return false;

        context.ImgPerfil.Remove(imgPerfil);
        await context.SaveChangesAsync();
        return true;
    }
}
