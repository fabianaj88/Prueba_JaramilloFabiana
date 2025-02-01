using Microsoft.EntityFrameworkCore;
using Prueba_JaramilloFabiana.Models;

namespace Prueba_JaramilloFabiana.Repositorys
{
    public class RegistroRepository
    {
        private readonly FullStackContext _context;

        public RegistroRepository(FullStackContext context)
        {
            _context = context;
        }

        public async Task<List<Registro>> GetAllAsync()
        {
            return await _context.Registros
                .Include(r => r.Respuesta)
                .ToListAsync();
        }

        public async Task<Registro> GetByIdAsync(int id)
        {
            return await _context.Registros
                .Include(r => r.Respuesta)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Registro>> GetByFormularioIdAsync(int formularioId)
        {
            return await _context.Registros
                .Include(r => r.Respuesta)
                .Where(r => r.FormularioId == formularioId)
                .ToListAsync();
        }

        public async Task<Registro> CreateAsync(Registro registro)
        {
            registro.FechaCreacion = DateTime.Now;
            _context.Registros.Add(registro);
            await _context.SaveChangesAsync();
            return registro;
        }

        public async Task<Registro> UpdateAsync(Registro registro)
        {
            var existingRegistro = await _context.Registros.FindAsync(registro.Id);
            if (existingRegistro == null)
                return null;

            _context.Entry(existingRegistro).CurrentValues.SetValues(registro);
            await _context.SaveChangesAsync();
            return existingRegistro;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var registro = await _context.Registros.FindAsync(id);
            if (registro == null)
                return false;

            _context.Registros.Remove(registro);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
