using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Context;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly E_commerceContext _context;

        public AuthController(IConfiguration configuration, E_commerceContext context)
        {
            _configuration = configuration;
            _context = context;
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

