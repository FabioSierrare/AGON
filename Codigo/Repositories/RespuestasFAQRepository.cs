using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio encargado de gestionar las operaciones CRUD para las respuestas de las preguntas frecuentes (FAQ).
    /// </summary>
    public class RespuestasFAQRepository : IRespuestasFAQ
    {
        /// <summary>
        /// Contexto de base de datos inyectado.
        /// </summary>
        private readonly E_commerceContext context;

        /// <summary>
        /// Constructor que inicializa el repositorio con el contexto proporcionado.
        /// </summary>
        /// <param name="context">Instancia del contexto de base de datos</param>
        public RespuestasFAQRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene todas las respuestas de FAQ disponibles en la base de datos.
        /// </summary>
        /// <returns>Lista de objetos RespuestasFAQ</returns>
        public async Task<List<RespuestasFAQ>> GetRespuestasFAQ()
        {
            var data = await context.RespuestasFAQ.ToListAsync();
            return data;
        }

        /// <summary>
        /// Inserta una nueva respuesta de FAQ en la base de datos.
        /// </summary>
        /// <param name="respuestasFAQ">Objeto RespuestasFAQ a insertar</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PostRespuestaFAQ(RespuestasFAQ respuestasFAQ)
        {
            await context.RespuestasFAQ.AddAsync(respuestasFAQ);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Actualiza una respuesta de FAQ existente en la base de datos.
        /// </summary>
        /// <param name="respuestasFAQ">Objeto RespuestasFAQ con la información actualizada</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PutRespuestasFAQ(RespuestasFAQ respuestasFAQ)
        {
            context.RespuestasFAQ.Update(respuestasFAQ);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Elimina una respuesta de FAQ por su ID.
        /// </summary>
        /// <param name="id">ID de la respuesta FAQ a eliminar</param>
        /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
        public async Task<bool> DeleteRespuestasFAQ(int id)
        {
            var notificacion = await context.RespuestasFAQ.FindAsync(id);
            if (notificacion == null) return false;

            context.RespuestasFAQ.Remove(notificacion);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
