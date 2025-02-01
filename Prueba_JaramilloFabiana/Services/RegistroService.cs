using Prueba_JaramilloFabiana.Models;
using Prueba_JaramilloFabiana.Repositorys;

namespace Prueba_JaramilloFabiana.Services
{
    public class RegistroService
    {
        private readonly RegistroRepository _repository;

        public RegistroService(RegistroRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Registro>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Registro> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Registro>> GetByFormularioIdAsync(int formularioId)
        {
            return await _repository.GetByFormularioIdAsync(formularioId);
        }

        public async Task<Registro> CreateAsync(Registro registro)
        {
            // Aquí puedes agregar validaciones de negocio adicionales
            if (registro.FormularioId == null)
                throw new ArgumentException("FormularioId es requerido");

            return await _repository.CreateAsync(registro);
        }

        public async Task<Registro> UpdateAsync(Registro registro)
        {
            // Aquí puedes agregar validaciones de negocio adicionales
            var result = await _repository.UpdateAsync(registro);
            if (result == null)
                throw new KeyNotFoundException($"Registro con Id {registro.Id} no encontrado");

            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
