using GestionIncidencia.Application.Mapper;
using Incidencias.Aplicacion.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestionIncidencia_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoporteController : ControllerBase
    {
        private readonly IncidenciaService _incidenciaService;

        public SoporteController(IncidenciaService incidenciaService)
        {
            _incidenciaService = incidenciaService;
        }

        // POST api/Soporte/resolver/5
        [HttpPost("resolver/{id:int}")]
        public async Task<IActionResult> Resolver(int id)
        {
            if (id <= 0) return BadRequest("Id inválido");

            var incidencia = await _incidenciaService.ObtenerPorIdAsync(id);
            if (incidencia == null) return NotFound("Incidencia no encontrada");
            if (incidencia.Estado == "Resuelto")
                return BadRequest("La incidencia ya está resuelta");

            await _incidenciaService.ActualizarEstadoResueltoAsync(id);
            incidencia = await _incidenciaService.ObtenerPorIdAsync(id);
            return Ok(IncidenciaMapper.ToResponse(incidencia));
        }

        // GET api/Soporte/top-alumnos
        [HttpGet("top-alumnos")]
        public async Task<IActionResult> TopAlumnos()
        {
            var result = await _incidenciaService.TopAlumnosConMasIncidenciasAsync(3);
            return Ok(IncidenciaMapper.ToResponseList(result));
        }
    }
}
