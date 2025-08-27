using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionIncidencia.Domain.Entidades;
using Incidencias.Dominio.Enun;

namespace Incidencias.Dominio.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public RolUsuario Rol { get; set; }

        public ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
        public ICollection<Docente> Docentes { get; set; } = new List<Docente>();
        public ICollection<Soporte> Soportes { get; set; } = new List<Soporte>();


    }

}

