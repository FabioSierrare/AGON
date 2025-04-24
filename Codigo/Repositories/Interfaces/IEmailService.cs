namespace E_Commerce.Repositories.Interfaces
{
    public interface IEmailService
    {
        Task EnviarCorreoAsync(string destinatario, string asunto, string contenido);
    }
}
