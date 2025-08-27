using GestionIncidencia.Application.DTO;
using GestionIncidencia.Application.Mapper;
using Incidencias.Aplicacion.Service;
using Microsoft.AspNetCore.Mvc;

namespace GestionIncidencia_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocenteController : Controller
    {


        private readonly IncidenciaService _incidenciaService;

        public DocenteController(IncidenciaService incidenciaService)
        {
            _incidenciaService = incidenciaService;
        }

        [HttpPost("crearIncidencia")]
        public async Task<IActionResult> CrearIncidencia([FromBody] CreraIncidenciaDTO dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos");

            var incidencia = IncidenciaMapper.ToEntity(dto);

            await _incidenciaService.AgregarAsync(incidencia);

            return Ok(new { mensaje = "Incidencia creada correctamente", incidencia });
        }
    }
}
