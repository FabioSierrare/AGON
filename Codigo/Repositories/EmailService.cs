using System.Net.Mail;
using System.Net;
using E_Commerce.Repositories.Interfaces;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Servicio para el envío de correos electrónicos utilizando configuración SMTP.
    /// </summary>
    public class EmailService : IEmailService
    {
        /// <summary>
        /// Configuración de la aplicación inyectada (para acceder a EmailSettings).
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor que recibe la configuración de la aplicación.
        /// </summary>
        /// <param name="configuration">Instancia de IConfiguration para acceder a EmailSettings</param>
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Envía un correo electrónico asincrónicamente a un destinatario específico.
        /// </summary>
        /// <param name="destinatario">Dirección de correo del destinatario</param>
        /// <param name="asunto">Asunto del correo</param>
        /// <param name="contenido">Contenido HTML del correo</param>
        /// <returns>Una tarea que representa la operación de envío</returns>
        public async Task EnviarCorreoAsync(string destinatario, string asunto, string contenido)
        {
            // Obtiene los valores de configuración desde appsettings.json
            var correo = _configuration["EmailSettings:Correo"];
            var contraseña = _configuration["EmailSettings:Contraseña"];
            var servidorSMTP = _configuration["EmailSettings:ServidorSMTP"];
            var puertoSMTP = int.Parse(_configuration["EmailSettings:PuertoSMTP"]);

            // Crea el mensaje de correo
            var mensaje = new MailMessage();
            mensaje.From = new MailAddress(correo);
            mensaje.To.Add(destinatario);
            mensaje.Subject = asunto;
            mensaje.Body = contenido;
            mensaje.IsBodyHtml = true; // Permite contenido HTML

            // Configura el cliente SMTP
            var cliente = new SmtpClient(servidorSMTP)
            {
                Port = puertoSMTP,
                Credentials = new NetworkCredential(correo, contraseña),
                EnableSsl = true
            };

            try
            {
                // Envía el correo de manera asincrónica
                await cliente.SendMailAsync(mensaje);
            }
            catch (Exception ex)
            {
                // Lanza una excepción si ocurre un error
                throw new Exception("No se pudo enviar el correo: " + ex.Message);
            }
        }
    }
}
