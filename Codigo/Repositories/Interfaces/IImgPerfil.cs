using E_Commerce.Models;

public interface IImgPerfil
{
    Task<List<ImgPerfil>> GetImgPerfil();
    Task<bool> PostImgPerfil(ImgPerfil imgperfil);
    Task<bool> PutImgPerfil(ImgPerfil imgperfil);
    Task<bool> DeleteImgPerfil(int id);  // Este método debe estar aquí
}
