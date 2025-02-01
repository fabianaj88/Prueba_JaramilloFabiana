using Microsoft.AspNetCore.Mvc;
using Prueba_JaramilloFabiana.Models;
using Prueba_JaramilloFabiana.Services;

namespace Prueba_JaramilloFabiana.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RespuestasController : ControllerBase
    {
        private readonly RespuestaService _service;

        public RespuestasController(RespuestaService service)
        {
            _service = service;
        }

        [HttpGet("registro/{registroId}")]
        public async Task<ActionResult<IEnumerable<Respuestum>>> GetRespuestasByRegistro(int registroId)
        {
            try
            {
                var respuestas = await _service.GetRespuestasByRegistroAsync(registroId);
                return Ok(respuestas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Respuestum>> GetRespuesta(int id)
        {
            try
            {
                var respuesta = await _service.GetRespuestaByIdAsync(id);
                return Ok(respuesta);
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
        public async Task<ActionResult<Respuestum>> CreateRespuesta(Respuestum respuesta)
        {
            try
            {
                var createdRespuesta = await _service.CreateRespuestaAsync(respuesta);
                return CreatedAtAction(nameof(GetRespuesta), new { id = createdRespuesta.Id }, createdRespuesta);
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
        public async Task<IActionResult> UpdateRespuesta(int id, Respuestum respuesta)
        {
            try
            {
                var updatedRespuesta = await _service.UpdateRespuestaAsync(id, respuesta);
                return Ok(updatedRespuesta);
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
        public async Task<IActionResult> DeleteRespuesta(int id)
        {
            try
            {
                await _service.DeleteRespuestaAsync(id);
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
