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
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly E_commerceContext _context;
        private readonly IUsuarios _usuariosRepository;  // Inyectamos el repositorio de usuarios
        private readonly IEmailService _emailService;

        public AuthController(IConfiguration configuration, E_commerceContext context, IUsuarios usuariosRepository, IEmailService emailService)
        {
            _configuration = configuration;
            _context = context;
            _usuariosRepository = usuariosRepository;
            _emailService = emailService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] Login login)
        {
            if (login == null || string.IsNullOrEmpty(login.Correo) || string.IsNullOrEmpty(login.Contraseña))
            {
                return BadRequest("Petición inválida");
            }

            // La contraseña ya viene encriptada desde el frontend
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Correo == login.Correo && u.Contraseña == login.Contraseña);

            if (usuario == null)
            {
                return Unauthorized("Correo o contraseña incorrectos");
            }

            // Crear token JWT
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

        // Metodo recuperar contraseña con el token
        [HttpPost("RecuperarContraseña")]
        public async Task<IActionResult> RecuperarContraseña([FromBody] RecuperarContraseñaDTO dto)
        {
            var usuario = await _usuariosRepository.GetUsuarioByCorreoAsync(dto.Correo);
            if (usuario == null)
            {
                return NotFound("Correo no encontrado.");
            }

            // Generar código numérico aleatorio de 6 dígitos
            var random = new Random();
            var codigo = random.Next(100000, 999999).ToString(); // Código de verificación de 6 dígitos

            usuario.CodigoVerificacion = codigo;
            usuario.CodigoExpira = DateTime.Now.AddMinutes(30);
            await _usuariosRepository.UpdateUsuarioAsync(usuario);

            // Contenido del correo con el código
            string contenidoCorreo = $@"
        <p>Has solicitado recuperar tu contraseña.</p>
        <p>Tu código de verificación es: <strong>{codigo}</strong></p>
        <p>Este código expirará en 30 minutos.</p>";

            await _emailService.EnviarCorreoAsync(usuario.Correo, "Código de Verificación - Recuperación de Contraseña", contenidoCorreo);

            return Ok("Se ha enviado un código de verificación a tu correo.");
        }

        [HttpPost("VerificarCodigo")]
        public async Task<IActionResult> VerificarCodigo([FromBody] VerificarCodigoDTO dto)
        {
            var usuario = await _usuariosRepository.GetUsuarioByCorreoAsync(dto.Correo);

            if (usuario == null || usuario.CodigoVerificacion != dto.Codigo || usuario.CodigoExpira < DateTime.Now)
            {
                return BadRequest("El código no es válido o ha expirado.");
            }

            return Ok("Código verificado correctamente.");
        }

        // Metodo para Restablecer Contraseña
        [HttpPost("RestablecerContraseña")]
        public async Task<IActionResult> RestablecerContraseña([FromBody] RestablecerContraseña model)
        {
            // Buscar usuario por código de verificación
            var usuario = await _usuariosRepository.GetUsuarioByCodigoAsync(model.Codigo);
            if (usuario == null || usuario.CodigoExpira < DateTime.Now)
            {
                var response = new RespuestaDTO
                {
                    Exito = false,
                    Mensaje = "El código no es válido o ha expirado."
                };
                return BadRequest(response);
            }

            if (model.NuevaContraseña != model.ConfirmarContraseña)
            {
                var response = new RespuestaDTO
                {
                    Exito = false,
                    Mensaje = "Las contraseñas no coinciden."
                };
                return BadRequest(response);
            }

            // Encriptar la nueva contraseña con SHA256
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(model.NuevaContraseña);
                var hashBytes = sha256.ComputeHash(bytes);
                var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

                usuario.Contraseña = hash;
            }

            // Limpiar el código de verificación
            usuario.CodigoVerificacion = null;
            usuario.CodigoExpira = null;

            await _usuariosRepository.UpdateUsuarioAsync(usuario);

            var successResponse = new RespuestaDTO
            {
                Exito = true,
                Mensaje = "Contraseña actualizada exitosamente."
            };

            return Ok(successResponse);
        }





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
}
public class Login
    {
        public string Correo { get; set; }
        public string Contraseña { get; set; }
    }

