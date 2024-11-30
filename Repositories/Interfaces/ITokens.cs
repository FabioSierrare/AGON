using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface ITokens
    {
        Task<List<Tokens>> GetTokens();
        Task<bool> PostTokens(Tokens tokens);
        Task<bool> PutTokens(Tokens tokens);
        Task<bool> DeleteTokens(Tokens tokens);
    }
}
