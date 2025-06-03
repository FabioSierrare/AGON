namespace E_Commerce.Models
{
    /// <summary>
    /// DTO utilizado para la recuperación de contraseña mediante el correo electrónico del usuario.
    /// </summary>
    public class RecuperarContraseñaDTO
    {
        /// <summary>
        /// Dirección de correo electrónico asociada a la cuenta del usuario.
        /// </summary>
        public string Correo { get; set; }
    }
}
