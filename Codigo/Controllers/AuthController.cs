using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Context;
using E_Commerce.Repositories;
using E_Commerce.Repositories.Interfaces;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador de autenticación para el sistema E-Commerce.
    /// Maneja login, recuperación y restablecimiento de contraseñas, y generación de tokens.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly E_commerceContext _context;
        private readonly IUsuarios _usuariosRepository;
        private readonly IEmailService _emailService;

        /// <summary>
        /// Constructor que inyecta dependencias requeridas por el controlador.
        /// </summary>
        public AuthController(IConfiguration configuration, E_commerceContext context, IUsuarios usuariosRepository, IEmailService emailService)
        {
            _configuration = configuration;
            _context = context;
            _usuariosRepository = usuariosRepository;
            _emailService = emailService;
        }

        /// <summary>
        /// Realiza la autenticación del usuario y genera un token JWT.
        /// </summary>
        /// <param name="login">Objeto con correo y contraseña.</param>
        /// <returns>Token JWT si las credenciales son válidas.</returns>
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Login login)
        {
            if (login == null || string.IsNullOrEmpty(login.Correo) || string.IsNullOrEmpty(login.Contraseña))
                return BadRequest("Petición inválida");

            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Correo == login.Correo && u.Contraseña == login.Contraseña);

            if (usuario == null)
                return Unauthorized("Correo o contraseña incorrectos");

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Correo),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim("TipoUsuario", usuario.TipoUsuario)
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new { Token = tokenString, UserId = usuario.Id, TipoUsuario = usuario.TipoUsuario });
        }

        /// <summary>
        /// Envía un código de verificación al correo para recuperar la contraseña.
        /// </summary>
        [HttpPost("RecuperarContraseña")]
        public async Task<IActionResult> RecuperarContraseña([FromBody] RecuperarContraseñaDTO dto)
        {
            var usuario = await _usuariosRepository.GetUsuarioByCorreoAsync(dto.Correo);
            if (usuario == null)
                return NotFound("Correo no encontrado.");

            var random = new Random();
            var codigo = random.Next(100000, 999999).ToString();

            usuario.CodigoVerificacion = codigo;
            usuario.CodigoExpira = DateTime.Now.AddMinutes(30);
            await _usuariosRepository.UpdateUsuarioAsync(usuario);

            string contenidoCorreo = $@"
                <p>Has solicitado recuperar tu contraseña.</p>
                <p>Tu código de verificación es: <strong>{codigo}</strong></p>
                <p>Este código expirará en 30 minutos.</p>";

            await _emailService.EnviarCorreoAsync(usuario.Correo, "Código de Verificación - Recuperación de Contraseña", contenidoCorreo);

            return Ok("Se ha enviado un código de verificación a tu correo.");
        }

        /// <summary>
        /// Verifica si el código enviado al correo es válido.
        /// </summary>
        [HttpPost("VerificarCodigo")]
        public async Task<IActionResult> VerificarCodigo([FromBody] VerificarCodigoDTO dto)
        {
            var usuario = await _usuariosRepository.GetUsuarioByCorreoAsync(dto.Correo);

            if (usuario == null || usuario.CodigoVerificacion != dto.Codigo || usuario.CodigoExpira < DateTime.Now)
                return BadRequest("El código no es válido o ha expirado.");

            return Ok("Código verificado correctamente.");
        }

        /// <summary>
        /// Restablece la contraseña del usuario si el código es válido.
        /// </summary>
        [HttpPost("RestablecerContraseña")]
        public async Task<IActionResult> RestablecerContraseña([FromBody] RestablecerContraseña model)
        {
            var usuario = await _usuariosRepository.GetUsuarioByCodigoAsync(model.Codigo);
            if (usuario == null || usuario.CodigoExpira < DateTime.Now)
            {
                return BadRequest(new RespuestaDTO { Exito = false, Mensaje = "El código no es válido o ha expirado." });
            }

            if (model.NuevaContraseña != model.ConfirmarContraseña)
            {
                return BadRequest(new RespuestaDTO { Exito = false, Mensaje = "Las contraseñas no coinciden." });
            }

            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(model.NuevaContraseña);
                var hashBytes = sha256.ComputeHash(bytes);
                var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                usuario.Contraseña = hash;
            }

            usuario.CodigoVerificacion = null;
            usuario.CodigoExpira = null;

            await _usuariosRepository.UpdateUsuarioAsync(usuario);

            return Ok(new RespuestaDTO { Exito = true, Mensaje = "Contraseña actualizada exitosamente." });
        }

        /// <summary>
        /// Devuelve el hash SHA256 de un texto plano para pruebas.
        /// </summary>
        [HttpGet("TestHash/{plainText}")]
        public IActionResult TestHash(string plainText)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(plainText);
                var hashBytes = sha256.ComputeHash(bytes);
                var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                return Ok(hash);
            }
        }
    }

    /// <summary>
    /// Modelo de datos para el login del usuario.
    /// </summary>
    public class Login
    {
        /// <summary>Correo del usuario.</summary>
        public string Correo { get; set; }

        /// <summary>Contraseña del usuario (ya encriptada).</summary>
        public string Contraseña { get; set; }
    }
}
