using Microsoft.EntityFrameworkCore;
using Prueba_JaramilloFabiana.Models;

namespace Prueba_JaramilloFabiana.Repositorys
{
    public class CampoRepository
    {
        private readonly FullStackContext _context;

        public CampoRepository(FullStackContext context)
        {
            _context = context;
        }

        public async Task<List<Campo>> GetAllAsync()
        {
            return await _context.Campos.ToListAsync();
        }

        public async Task<List<Campo>> GetByFormularioIdAsync(int formularioId)
        {
            return await _context.Campos
                .Where(c => c.FormularioId == formularioId)
                .ToListAsync();
        }

        public async Task<Campo> GetByIdAsync(int id)
        {
            return await _context.Campos.FindAsync(id);
        }

        public async Task<Campo> CreateAsync(Campo campo)
        {
            _context.Campos.Add(campo);
            await _context.SaveChangesAsync();
            return campo;
        }

        public async Task<Campo> UpdateAsync(Campo campo)
        {
            _context.Entry(campo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return campo;
        }


        public async Task DeleteAsync(int id)
        {
            var campo = await _context.Campos
                .Include(c => c.Respuesta)  
                .FirstOrDefaultAsync(c => c.Id == id);

            if (campo != null)
            {
                
                if (campo.Respuesta != null)
                {
                    _context.Respuesta.RemoveRange(campo.Respuesta);
                }

                
                _context.Campos.Remove(campo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
