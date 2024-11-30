using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace E_Commerce.Repositories
{
    public class ImagenProductoRepository : IImagenProducto
    {
        private readonly E_commerceContext context;

        public ImagenProductoRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<ImagenProducto>> GetImagenProducto()
        {
            var data = await context.ImagenProducto.ToListAsync();
            return data;
        }

        public async Task<bool> PostImagenProducto(ImagenProducto imagenProducto)
        {
            await context.ImagenProducto.AddAsync(imagenProducto);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutImagenProducto(ImagenProducto imagenProducto)
        {
            context.ImagenProducto.Update(imagenProducto);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteImagenProducto(ImagenProducto imagenProducto)
        {
            context.ImagenProducto.Remove(imagenProducto);
            await context.SaveAsync();
            return true;
        }
    }
}
