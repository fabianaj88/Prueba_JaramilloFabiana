using Microsoft.EntityFrameworkCore;
using Prueba_JaramilloFabiana.Models;

namespace Prueba_JaramilloFabiana.Repositorys
{
    public class RespuestaRepository
    {
        private readonly FullStackContext _context;

        public RespuestaRepository(FullStackContext context)
        {
            _context = context;
        }

        public async Task<List<Respuestum>> GetAllAsync()
        {
            return await _context.Respuesta
                .Include(r => r.Campo)
                .Include(r => r.Registro)
                .ToListAsync();
        }

        public async Task<List<Respuestum>> GetByRegistroIdAsync(int registroId)
        {
            return await _context.Respuesta
                .Include(r => r.Campo)
                .Where(r => r.RegistroId == registroId)
                .ToListAsync();
        }

        public async Task<Respuestum> GetByIdAsync(int id)
        {
            return await _context.Respuesta
                .Include(r => r.Campo)
                .Include(r => r.Registro)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Respuestum> CreateAsync(Respuestum respuesta)
        {
            _context.Respuesta.Add(respuesta);
            await _context.SaveChangesAsync();
            return respuesta;
        }

        public async Task<Respuestum> UpdateAsync(Respuestum respuesta)
        {
            _context.Entry(respuesta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return respuesta;
        }

        public async Task DeleteAsync(int id)
        {
            var respuesta = await _context.Respuesta.FindAsync(id);
            if (respuesta != null)
            {
                _context.Respuesta.Remove(respuesta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
