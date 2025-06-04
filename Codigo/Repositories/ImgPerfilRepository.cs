using E_Commerce.Models;
using E_Commerce.Context;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Repositories.Interfaces;

/// <summary>
/// Repositorio que gestiona las operaciones CRUD de imágenes de perfil de los usuarios.
/// </summary>
public class ImgPerfilRepository : IImgPerfil
{
    /// <summary>
    /// Contexto de base de datos inyectado.
    /// </summary>
    private readonly E_commerceContext context;

    /// <summary>
    /// Constructor que inicializa el repositorio con el contexto proporcionado.
    /// </summary>
    /// <param name="context">Instancia del contexto de base de datos</param>
    public ImgPerfilRepository(E_commerceContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Obtiene la lista completa de imágenes de perfil.
    /// </summary>
    /// <returns>Lista de objetos ImgPerfil</returns>
    public async Task<List<ImgPerfil>> GetImgPerfil()
    {
        var data = await context.ImgPerfil.ToListAsync();
        return data;
    }

    /// <summary>
    /// Inserta una nueva imagen de perfil en la base de datos.
    /// </summary>
    /// <param name="imgPerfil">Objeto ImgPerfil a insertar</param>
    /// <returns>True si la operación fue exitosa</returns>
    public async Task<bool> PostImgPerfil(ImgPerfil imgPerfil)
    {
        await context.ImgPerfil.AddAsync(imgPerfil);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Actualiza una imagen de perfil existente.
    /// </summary>
    /// <param name="imgPerfil">Objeto ImgPerfil a actualizar</param>
    /// <returns>True si la operación fue exitosa</returns>
    public async Task<bool> PutImgPerfil(ImgPerfil imgPerfil)
    {
        context.ImgPerfil.Update(imgPerfil);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Elimina una imagen de perfil por su ID.
    /// </summary>
    /// <param name="id">ID de la imagen de perfil a eliminar</param>
    /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
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
