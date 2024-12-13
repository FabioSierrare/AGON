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
        public async Task<bool> DeleteImagenProducto(int id)
        {
            var imagenProducto = await context.ImagenProducto.FindAsync(id); // Usar 'context' en lugar de '_context'
            if (imagenProducto == null) return false; // Si no existe, devolver 'false'

            context.ImagenProducto.Remove(imagenProducto); // Usar 'context'
            await context.SaveChangesAsync(); // Corregir 'SaveAsync' por 'SaveChangesAsync'
            return true;
        }
    }
}
