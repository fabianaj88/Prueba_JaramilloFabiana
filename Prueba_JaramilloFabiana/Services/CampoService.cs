using Prueba_JaramilloFabiana.Models;
using Prueba_JaramilloFabiana.Repositorys;

namespace Prueba_JaramilloFabiana.Services
{
    public class CampoService
    {
        private readonly CampoRepository _repository;

        public CampoService(CampoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Campo>> GetCamposByFormularioAsync(int formularioId)
        {
            return await _repository.GetByFormularioIdAsync(formularioId);
        }

        public async Task<Campo> GetCampoByIdAsync(int id)
        {
            var campo = await _repository.GetByIdAsync(id);
            if (campo == null)
                throw new KeyNotFoundException($"Campo con ID {id} no encontrado.");
            return campo;
        }

        public async Task<Campo> CreateCampoAsync(Campo campo)
        {
            if (string.IsNullOrEmpty(campo.Nombre))
                throw new ArgumentException("El nombre del campo es requerido.");

            if (string.IsNullOrEmpty(campo.Tipo))
                throw new ArgumentException("El tipo del campo es requerido.");

            return await _repository.CreateAsync(campo);
        }

        
        public async Task<Campo> UpdateCampoAsync(int id, Campo campo)
        {
            if (id != campo.Id)
                throw new ArgumentException("ID no coincide con el campo a actualizar.");

            var existingCampo = await _repository.GetByIdAsync(id);
            if (existingCampo == null)
                throw new KeyNotFoundException($"Campo con ID {id} no encontrado.");

            existingCampo.Nombre = campo.Nombre;
            existingCampo.Tipo = campo.Tipo;
            existingCampo.FormularioId = campo.FormularioId;

            return await _repository.UpdateAsync(existingCampo);
        }

        public async Task DeleteCampoAsync(int id)
        {
            var campo = await _repository.GetByIdAsync(id);
            if (campo == null)
                throw new KeyNotFoundException($"Campo con ID {id} no encontrado.");

            await _repository.DeleteAsync(id);
        }
    }
}
