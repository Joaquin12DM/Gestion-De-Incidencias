using GestionIncidencia.Application.DTO.Request;
using GestionIncidencia.Application.DTO.Response;
using Incidencias.Aplicacion.Service;
using Incidencias.Dominio.Enun;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Incidencias.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly UsuarioService _usuarioServicio;

        public LoginController(UsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Debe enviar username y password");

            var user = await _usuarioServicio.ValidarCredencialesAsync(request.Username, request.Password);
            if (user == null)
                return Unauthorized("Credenciales inválidas");

            string apellidos = string.Empty;
            string dni = string.Empty;

            switch (user.Rol)
            {
                case RolUsuario.Alumno:
                    var alumno = user.Alumnos.FirstOrDefault();
                    if (alumno != null)
                    {
                        apellidos = alumno.Apellidos;
                        dni = alumno.DNI;
                    }
                    break;

                case RolUsuario.Docente:
                    var docente = user.Docentes.FirstOrDefault();
                    if (docente != null)
                    {
                        apellidos = docente.Apellidos;
                        dni = docente.DNI;
                    }
                    break;

                case RolUsuario.Soporte:
                    var soporte = user.Soportes.FirstOrDefault();
                    if (soporte != null)
                    {
                        apellidos = soporte.Apellidos;
                        dni = soporte.DNI;
                    }
                    break;
            }

            var response = new LoginResponse
            {
                IdUsuario = user.IdUsuario,
                NombreUsuario = user.NombreUsuario,
                Apellidos = apellidos,
                DNI = dni,
                Email = user.NombreUsuario,
                Rol = user.Rol.ToString()
            };

            return Ok(new
            {
                user = response,
                rol = user.Rol.ToString()
            });
        }
    }
}
