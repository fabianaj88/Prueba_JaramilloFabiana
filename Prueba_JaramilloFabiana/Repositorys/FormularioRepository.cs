using Microsoft.EntityFrameworkCore;
using Prueba_JaramilloFabiana.Models;
namespace Prueba_JaramilloFabiana.Repositorys
{
    public class FormularioRepository
    {
        private readonly FullStackContext _context;

        public FormularioRepository(FullStackContext context)
        {
            _context = context;
        }

        public async Task<List<Formulario>> GetAllAsync()
        {
            return await _context.Formularios
                .Include(f => f.Campos)
                .ToListAsync();
        }

        public async Task<Formulario> GetByIdAsync(int id)
        {
            return await _context.Formularios
                .Include(f => f.Campos)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Formulario> CreateAsync(Formulario formulario)
        {
            _context.Formularios.Add(formulario);
            await _context.SaveChangesAsync();
            return formulario;
        }

        public async Task<Formulario> UpdateAsync(Formulario formulario)
        {
            _context.Entry(formulario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return formulario;
        }

        public async Task DeleteAsync(int id)
        {
            var formulario = await _context.Formularios.FindAsync(id);
            if (formulario != null)
            {
                _context.Formularios.Remove(formulario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
