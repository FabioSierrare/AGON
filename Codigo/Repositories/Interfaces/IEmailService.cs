namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define un contrato para el servicio de envío de correos electrónicos.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Envía un correo electrónico de forma asíncrona.
        /// </summary>
        /// <param name="destinatario">Dirección de correo del destinatario.</param>
        /// <param name="asunto">Asunto del mensaje de correo.</param>
        /// <param name="contenido">Contenido o cuerpo del mensaje de correo (puede ser HTML o texto plano).</param>
        /// <returns>Una tarea que representa la operación asíncrona de envío de correo.</returns>
        Task EnviarCorreoAsync(string destinatario, string asunto, string contenido);
    }
}
