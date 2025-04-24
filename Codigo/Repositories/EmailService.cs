using System.Net.Mail;
using System.Net;
using E_Commerce.Repositories.Interfaces;

namespace E_Commerce.Repositories
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task EnviarCorreoAsync(string destinatario, string asunto, string contenido)
        {
            var correo = _configuration["EmailSettings:Correo"];
            var contraseña = _configuration["EmailSettings:Contraseña"];
            var servidorSMTP = _configuration["EmailSettings:ServidorSMTP"];
            var puertoSMTP = int.Parse(_configuration["EmailSettings:PuertoSMTP"]);

            var mensaje = new MailMessage();
            mensaje.From = new MailAddress(correo);
            mensaje.To.Add(destinatario);
            mensaje.Subject = asunto;
            mensaje.Body = contenido;
            mensaje.IsBodyHtml = true;

            var cliente = new SmtpClient(servidorSMTP)
            {
                Port = puertoSMTP,
                Credentials = new NetworkCredential(correo, contraseña),
                EnableSsl = true
            };
            try
            {
                await cliente.SendMailAsync(mensaje);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo enviar el correo: " + ex.Message);
            }


        }
    }
}
