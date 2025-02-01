using Microsoft.AspNetCore.Mvc;
using Prueba_JaramilloFabiana.Models;
using Prueba_JaramilloFabiana.Services;

namespace Prueba_JaramilloFabiana.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroController : ControllerBase
    {
        private readonly RegistroService _service;
        private readonly ILogger<RegistroController> _logger;

        public RegistroController(RegistroService service, ILogger<RegistroController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registro>>> GetAll()
        {
            try
            {
                var registros = await _service.GetAllAsync();
                return Ok(registros);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los registros");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Registro>> GetById(int id)
        {
            try
            {
                var registro = await _service.GetByIdAsync(id);
                if (registro == null)
                    return NotFound($"Registro con Id {id} no encontrado");

                return Ok(registro);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el registro {Id}", id);
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("formulario/{formularioId}")]
        public async Task<ActionResult<IEnumerable<Registro>>> GetByFormularioId(int formularioId)
        {
            try
            {
                var registros = await _service.GetByFormularioIdAsync(formularioId);
                return Ok(registros);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener registros para el formulario {FormularioId}", formularioId);
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Registro>> Create([FromBody] Registro registro)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var createdRegistro = await _service.CreateAsync(registro);
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = createdRegistro.Id },
                    createdRegistro);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el registro");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Registro>> Update(int id, [FromBody] Registro registro)
        {
            try
            {
                if (id != registro.Id)
                    return BadRequest("El Id de la ruta no coincide con el Id del registro");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var updatedRegistro = await _service.UpdateAsync(registro);
                return Ok(updatedRegistro);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el registro {Id}", id);
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                if (!result)
                    return NotFound($"Registro con Id {id} no encontrado");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el registro {Id}", id);
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
