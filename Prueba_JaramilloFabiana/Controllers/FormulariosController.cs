using Microsoft.AspNetCore.Mvc;
using Prueba_JaramilloFabiana.Models;
using Prueba_JaramilloFabiana.Services;

namespace Prueba_JaramilloFabiana.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormulariosController : ControllerBase
    {
        private readonly FormularioService _service;

        public FormulariosController(FormularioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Formulario>>> GetFormularios()
        {
            try
            {
                var formularios = await _service.GetAllFormulariosAsync();
                return Ok(formularios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Formulario>> GetFormulario(int id)
        {
            try
            {
                var formulario = await _service.GetFormularioByIdAsync(id);
                return Ok(formulario);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Formulario>> CreateFormulario(Formulario formulario)
        {
            try
            {
                var createdFormulario = await _service.CreateFormularioAsync(formulario);
                return CreatedAtAction(nameof(GetFormulario), new { id = createdFormulario.Id }, createdFormulario);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFormulario(int id, Formulario formulario)
        {
            try
            {
                var updatedFormulario = await _service.UpdateFormularioAsync(id, formulario);
                return Ok(updatedFormulario);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormulario(int id)
        {
            try
            {
                await _service.DeleteFormularioAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
