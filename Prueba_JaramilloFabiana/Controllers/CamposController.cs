using Microsoft.AspNetCore.Mvc;
using Prueba_JaramilloFabiana.Models;
using Prueba_JaramilloFabiana.Services;

namespace Prueba_JaramilloFabiana.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CamposController : ControllerBase
    {
        private readonly CampoService _service;

        public CamposController(CampoService service)
        {
            _service = service;
        }

        [HttpGet("formulario/{formularioId}")]
        public async Task<ActionResult<IEnumerable<Campo>>> GetCamposByFormulario(int formularioId)
        {
            try
            {
                var campos = await _service.GetCamposByFormularioAsync(formularioId);
                return Ok(campos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Campo>> GetCampo(int id)
        {
            try
            {
                var campo = await _service.GetCampoByIdAsync(id);
                return Ok(campo);
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
        public async Task<ActionResult<Campo>> CreateCampo(Campo campo)
        {
            try
            {
                var createdCampo = await _service.CreateCampoAsync(campo);
                return CreatedAtAction(nameof(GetCampo), new { id = createdCampo.Id }, createdCampo);
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
        public async Task<IActionResult> UpdateCampo(int id, Campo campo)
        {
            try
            {
                var updatedCampo = await _service.UpdateCampoAsync(id, campo);
                return Ok(updatedCampo);
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
        public async Task<IActionResult> DeleteCampo(int id)
        {
            try
            {
                await _service.DeleteCampoAsync(id);
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
