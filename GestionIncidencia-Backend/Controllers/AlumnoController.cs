using Incidencias.Aplicacion.Service;
using Microsoft.AspNetCore.Mvc;

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

        // GET api/usuario/alumno/{dni}
        [HttpGet("alumno/{id}")]
        public async Task<IActionResult> ObtenerAlumnoPorDni(int id)
        {
            if (id <= 0)
                return BadRequest("DNI inválido");

            var alumnos = await _alumnoService.Alumno(id);

            if (alumnos == null || !alumnos.Any())
                return NotFound("No se encontró ningún alumno con ese DNI");

            return Ok(alumnos);
        }
    }
}
