using Prueba_JaramilloFabiana.Models;
using Prueba_JaramilloFabiana.Repositorys;

namespace Prueba_JaramilloFabiana.Services
{
    public class RespuestaService
    {
        private readonly RespuestaRepository _repository;

        public RespuestaService(RespuestaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Respuestum>> GetRespuestasByRegistroAsync(int registroId)
        {
            return await _repository.GetByRegistroIdAsync(registroId);
        }

        public async Task<Respuestum> GetRespuestaByIdAsync(int id)
        {
            var respuesta = await _repository.GetByIdAsync(id);
            if (respuesta == null)
                throw new KeyNotFoundException($"Respuesta con ID {id} no encontrada.");
            return respuesta;
        }

        public async Task<Respuestum> CreateRespuestaAsync(Respuestum respuesta)
        {
            if (string.IsNullOrEmpty(respuesta.Valor))
                throw new ArgumentException("El valor de la respuesta es requerido.");

            return await _repository.CreateAsync(respuesta);
        }

        public async Task<Respuestum> UpdateRespuestaAsync(int id, Respuestum respuesta)
        {
            if (id != respuesta.Id)
                throw new ArgumentException("ID no coincide con la respuesta a actualizar.");

            var existingRespuesta = await _repository.GetByIdAsync(id);
            if (existingRespuesta == null)
                throw new KeyNotFoundException($"Respuesta con ID {id} no encontrada.");

            return await _repository.UpdateAsync(respuesta);
        }

        public async Task DeleteRespuestaAsync(int id)
        {
            var respuesta = await _repository.GetByIdAsync(id);
            if (respuesta == null)
                throw new KeyNotFoundException($"Respuesta con ID {id} no encontrada.");

            await _repository.DeleteAsync(id);
        }
    }
}
