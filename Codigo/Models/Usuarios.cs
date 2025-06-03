using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    /// <summary>
    /// Modelo que representa un usuario dentro del sistema E-Commerce.
    /// </summary>
    public class Usuarios
    {
        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre completo del usuario.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Correo electrónico del usuario.
        /// </summary>
        public string Correo { get; set; }

        /// <summary>
        /// Contraseña del usuario (debe almacenarse de forma segura).
        /// </summary>
        public string Contraseña { get; set; }

        /// <summary>
        /// Número de teléfono del usuario.
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Dirección de residencia del usuario.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Tipo de documento del usuario (por ejemplo, CC, CE).
        /// </summary>
        public string TipoDocumento { get; set; }

        /// <summary>
        /// Número del documento de identidad del usuario.
        /// </summary>
        public string Documento { get; set; }

        /// <summary>
        /// Rol o perfil del usuario (por ejemplo, Cliente, Vendedor, Admin).
        /// </summary>
        public string TipoUsuario { get; set; }

        /// <summary>
        /// Fecha en que se registró el usuario en el sistema.
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Código de verificación enviado para restablecer contraseña o validar cuenta.
        /// </summary>
        public string? CodigoVerificacion { get; set; }

        /// <summary>
        /// Fecha de expiración del código de verificación.
        /// </summary>
        public DateTime? CodigoExpira { get; set; }
    }
}
