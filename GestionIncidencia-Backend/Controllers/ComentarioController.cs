using GestionIncidencia.Application.DTO.Request;
using GestionIncidencia.Application.Mapper;
using Incidencias.Aplicacion.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionIncidencia_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly ComentarioService _comentarioService;
        private readonly IncidenciaService _incidenciaService;


        //Aca al momento de comentar una incidencia, habra el boton de resolver y al comentar y enviar , automaticamnte cambiara el estado
        //por Realizado
        [HttpPost("save")]
        public async Task<IActionResult> SaveComentario(ComentarioRequest comentarioRequest)
        {
            try
            {
                var comentario = _comentarioService.AgregarAsync(ComentarioMapper.ToDomain(comentarioRequest));
                await _incidenciaService.ActualizarEstadoResueltoAsync(comentarioRequest.IncidenciaId);
                return Ok(new { success = true, message = "Comentario agregado y estado actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Error al procesar la solicitud", error = ex.Message });
            }
        }
    }
}
