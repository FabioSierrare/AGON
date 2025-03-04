using E_Commerce.Models; // Asegúrate de que este sea el namespace correcto de tu modelo
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Context;

namespace MicroServiceCRUD.Controllers
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
                return BadRequest("Invalid client request");
            }

            // Verificar si el usuario existe en la base de datos
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Correo == login.Correo);

            if (usuario == null || usuario.Contraseña != login.Contraseña)
            {
                return Unauthorized("Invalid email or password");
            }

            // Generación del token JWT
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Correo),  // Correo del usuario
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()), // Agregar el ID como Claim
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddSeconds(30),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new { Token = tokenString, UserId = usuario.Id });
        }
    }

    public class Login
    {
        public string Correo { get; set; }
        public string Contraseña { get; set; }
    }
}