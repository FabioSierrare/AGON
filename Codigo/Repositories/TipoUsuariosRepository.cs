using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio para gestionar las operaciones CRUD sobre la entidad TipoUsuarios.
    /// </summary>
    public class TipoUsuariosRepository : ITipoUsuarios
    {
        private readonly E_commerceContext _context;

        public TipoUsuariosRepository(E_commerceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los tipos de usuario registrados en la base de datos.
        /// </summary>
        public async Task<List<TipoUsuarios>> GetTipoUsuarios()
        {
            return await _context.TipoUsuarios
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        /// <summary>
        /// Inserta un nuevo tipo de usuario.
        /// </summary>
        public async Task<bool> PostTipoUsuarios(TipoUsuarios tipoUsuario)
        {
            await _context.TipoUsuarios.AddAsync(tipoUsuario);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Actualiza un tipo de usuario existente.
        /// </summary>
        public async Task<bool> PutTipoUsuarios(TipoUsuarios tipoUsuario)
        {
            var existente = await _context.TipoUsuarios.FindAsync(tipoUsuario.Id);
            if (existente == null)
                return false;

            existente.Nombre = tipoUsuario.Nombre;
            // Si agregaste más columnas a TipoUsuarios, asígnalas aquí.

            _context.TipoUsuarios.Update(existente);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Elimina un tipo de usuario por su ID.
        /// </summary>
        public async Task<bool> DeleteTipoUsuarios(int id)
        {
            var entidad = await _context.TipoUsuarios.FindAsync(id);
            if (entidad == null)
                return false;

            _context.TipoUsuarios.Remove(entidad);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
