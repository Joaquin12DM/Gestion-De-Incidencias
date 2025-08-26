using Incidencias.Dominio.Enun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Aplicacion.DTO
{
    public class LoginResponse
    {
        public string NombreUsuario { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
    }
}
