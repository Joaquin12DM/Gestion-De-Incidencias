using Incidencias.Aplicacion.DTO;
using Incidencias.Aplicacion.Service;
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
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                return BadRequest("Debe enviar Email y Password");

            var user = await _usuarioServicio.ValidarCredencialesAsync(request.Email, request.Password);

            if (user == null)
                return Unauthorized("Credenciales inválidas");

            var response = new LoginResponse
            {
                IdUsuario = user.IdUsuario,
                NombreUsuario = user.NombreUsuario,
                Email = user.Email,
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
