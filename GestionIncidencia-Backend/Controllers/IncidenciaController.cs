using GestionIncidencia.Application.Mapper;
using Incidencias.Aplicacion.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("findById")]
        public async Task<IActionResult> IncidenciaById(int id)
        {
            var incidencia = await incidenciaService.ObtenerPorIdAsync(id);
            return Ok(IncidenciaMapper.ToResponse(incidencia));
        }


    }
}
