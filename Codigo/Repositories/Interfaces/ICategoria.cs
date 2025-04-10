using E_Commerce.Models;

public interface ICategoria
{
    Task<List<Categorias>> GetCategoria();
    Task<bool> PostCategoria(Categorias categoria);
    Task<bool> PutCategoria(Categorias categoria);
    Task<bool> DeleteCategoria(int id);  // Este método debe estar aquí
}
