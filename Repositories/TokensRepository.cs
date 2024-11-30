using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace E_Commerce.Repositories
{
    public class TokensRepository : ITokens
    {
        private readonly E_commerceContext context;

        public TokensRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Tokens>> GetTokens()
        {
            var data = await context.Tokens.ToListAsync();
            return data;
        }

        public async Task<bool> PostTokens(Tokens tokens)
        {
            await context.Tokens.AddAsync(tokens);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> PutTokens(Tokens tokens)
        {
            context.Tokens.Update(tokens);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteTokens(Tokens tokens)
        {
            context.Tokens.Remove(tokens);
            await context.SaveAsync();
            return true;
        }
    }
}
