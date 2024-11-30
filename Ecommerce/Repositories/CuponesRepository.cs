using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class CuponesRepository : ICupones
    {
        public readonly E_commerceContext context;

        public CuponesRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Cupones>> GetCupones()
        {
            var data = await context.Cupones.ToListAsync();
            return data;
        }

        public async Task<bool> PostCupones(Cupones cupones)
        {
            await context.Cupones.AddAsync(cupones);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutCupones(Cupones cupones)
        {
            context.Cupones.Update(cupones);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteCupones(Cupones cupones)
        {
            context.Cupones.Remove(cupones);
            await context.SaveAsync();
            return true;
        }
    }
}
