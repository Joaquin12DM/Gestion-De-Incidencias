using GestionIncidencia.Application.DTO.Request;
using GestionIncidencia.Application.Mapper;
using Incidencias.Aplicacion.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace GestionIncidencia_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidenciaController : ControllerBase
    {
        private readonly IncidenciaService incidenciaService;

        public IncidenciaController(IncidenciaService incidenciaService)
        {
            this.incidenciaService = incidenciaService;
        }

        [HttpGet("listaIncidencias")]
        public async Task<IActionResult> ListaIncidencias()
        {
            var incidencias = await incidenciaService.ListarAsync();
            return Ok(IncidenciaMapper.ToResponseList(incidencias));
        }

        [HttpGet("listaIncidenciasNoResueltas")]
        public async Task<IActionResult> ListaIncidenciasNoResueltas()
        {
            var incidencias = await incidenciaService.ListarNoResueltaAsync();
            return Ok(IncidenciaMapper.ToResponseList(incidencias));
        }

        [HttpGet("listaIncidenciasResueltas")]
        public async Task<IActionResult> ListaIncidenciasResueltas()
        {
            var incidencias = await incidenciaService.ListarResueltaAsync();
            return Ok(IncidenciaMapper.ToResponseList(incidencias));
        }

        [HttpGet("listaPorFecha")]
        public async Task<IActionResult> ListaPorFecha([FromQuery] DateTime fechaInicio, [FromQuery] DateTime? fechaFin = null)
        {
            if (fechaInicio == default)
                return BadRequest("fechaInicio es requerido");
            var incidencias = await incidenciaService.ListarPorFechaCreacionAsync(fechaInicio, fechaFin);
            return Ok(IncidenciaMapper.ToResponseList(incidencias));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] CrearIncidenciaDTO dto)
        {
            if (dto == null) return BadRequest("Payload nulo.");
            if (string.IsNullOrWhiteSpace(dto.Descripcion)) return BadRequest("Descripcion requerida.");
            if (dto.UsuarioId <= 0) return BadRequest("UsuarioId inválido.");

            var entidad = IncidenciaMapper.ToEntity(dto);
            await incidenciaService.AgregarAsync(entidad);

            var response = IncidenciaMapper.ToResponse(entidad);
            return CreatedAtAction(nameof(IncidenciaById), new { id = entidad.IdIncidencia }, response);
        }

        [HttpGet("findById")]
        public async Task<IActionResult> IncidenciaById(int id)
        {
            var incidencia = await incidenciaService.ObtenerPorIdAsync(id);
            if (incidencia == null) return NotFound();
            return Ok(IncidenciaMapper.ToResponse(incidencia));
        }

        
    }
}
