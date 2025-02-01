using Prueba_JaramilloFabiana.Models;
using Prueba_JaramilloFabiana.Repositorys;

namespace Prueba_JaramilloFabiana.Services
{
    public class FormularioService
    {
        private readonly FormularioRepository _repository;

        public FormularioService(FormularioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Formulario>> GetAllFormulariosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Formulario> GetFormularioByIdAsync(int id)
        {
            var formulario = await _repository.GetByIdAsync(id);
            if (formulario == null)
                throw new KeyNotFoundException($"Formulario con ID {id} no encontrado.");
            return formulario;
        }

        public async Task<Formulario> CreateFormularioAsync(Formulario formulario)
        {
            if (string.IsNullOrEmpty(formulario.Nombre))
                throw new ArgumentException("El nombre del formulario es requerido.");

            return await _repository.CreateAsync(formulario);
        }

        public async Task<Formulario> UpdateFormularioAsync(int id, Formulario formulario)
        {
            if (id != formulario.Id)
                throw new ArgumentException("ID no coincide con el formulario a actualizar.");

            var existingFormulario = await _repository.GetByIdAsync(id);
            if (existingFormulario == null)
                throw new KeyNotFoundException($"Formulario con ID {id} no encontrado.");

            return await _repository.UpdateAsync(formulario);
        }

        public async Task DeleteFormularioAsync(int id)
        {
            var formulario = await _repository.GetByIdAsync(id);
            if (formulario == null)
                throw new KeyNotFoundException($"Formulario con ID {id} no encontrado.");

            await _repository.DeleteAsync(id);
        }
    }
}
