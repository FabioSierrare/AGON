using E_Commerce.Models;

public interface ICategoria
{
    Task<List<Categoria>> GetCategoria();
    Task<bool> PostCategoria(Categoria categoria);
    Task<bool> PutCategoria(Categoria categoria);
    Task<bool> DeleteCategoria(int id);  // Este método debe estar aquí
}
