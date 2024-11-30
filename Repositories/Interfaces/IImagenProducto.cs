using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface IImagenProducto
    {
        Task<List<ImagenProducto>> GetImagenProducto();
        Task<bool> PostImagenProducto(ImagenProducto imagenProducto);
        Task<bool> PutImagenProducto(ImagenProducto imagenProducto);
        Task<bool> DeleteImagenProducto(ImagenProducto imagenProducto);
    }
}
