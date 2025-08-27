using Incidencias.Dominio.Enun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIncidencia.Application.DTO.Response
{
    public class LoginResponse
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
    }
}
