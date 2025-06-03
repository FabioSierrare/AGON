using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    /// <summary>
    /// Representa un comentario hecho por un usuario sobre un producto.
    /// </summary>
    public class Comentarios
    {
        /// <summary>
        /// Identificador único del comentario.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del usuario que realizó el comentario.
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Identificador del producto al que pertenece el comentario.
        /// </summary>
        public int ProductoId { get; set; }

        /// <summary>
        /// Texto del comentario realizado por el usuario.
        /// </summary>
        public string ComentarioTexto { get; set; }

        /// <summary>
        /// Fecha y hora en que se realizó el comentario.
        /// </summary>
        public DateTime FechaComentario { get; set; }
    }
}
