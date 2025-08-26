using Incidencias.Dominio.Enun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Dominio.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ContrasenaHash { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public RolUsuario Rol { get; set; }
        public DateTime FechaCreacion { get; set; }

        public int InstitucionId { get; set; }
        public Institucion Institucion { get; set; }

        // Relación con incidencias creadas (docente)
        public ICollection<Incidencia> IncidenciasCreadas { get; set; }

        // Relación con incidencias asignadas (técnico)
        public ICollection<Incidencia> IncidenciasAsignadas { get; set; }
    }

}

