using Incidencias.Aplicacion.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GestionIncidencia.Application.DTO.Request;
using GestionIncidencia.Application.Mapper;

namespace GestionIncidencia_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnoController : Controller
    {
        private readonly AlumnoService _alumnoService;

        public AlumnoController(AlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }

        // GET api/alumno/{idAlumno}
        [HttpGet("{idAlumno:int}")]
        public async Task<IActionResult> ObtenerPorId(int idAlumno)
        {
            if (idAlumno <= 0)
                return BadRequest("Id inválido");

            var alumno = await _alumnoService.ObtenerPorIdAsync(idAlumno);
            if (alumno == null) return NotFound();

            return Ok(AlumnoMapper.ToResponse(alumno));
        }

        // GET api/alumno/listar
        [HttpGet("listar")]
        public async Task<IActionResult> ListarTodos()
        {
            var lista = await _alumnoService.ListarTodosAsync();
            return Ok(AlumnoMapper.ToResponseList(lista));
        }

        // GET api/alumno/por-grado?grado=X
        [HttpGet("por-grado")]
        public async Task<IActionResult> ListarPorGrado([FromQuery] AlumnoFiltroRequest filtro)
        {
            if (filtro == null || string.IsNullOrWhiteSpace(filtro.Grado))
                return BadRequest("Grado requerido");

            var lista = await _alumnoService.ListarPorGradoAsync(filtro.Grado);
            return Ok(AlumnoMapper.ToResponseList(lista));
        }
    }
}
