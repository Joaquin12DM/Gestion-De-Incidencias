using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionIncidencia.Domain.Entidades;

namespace Incidencias.Dominio.Entidades
{
    public class Incidencia
    {
        public int IdIncidencia { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Usuario (Docente / quien crea la incidencia)
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Relación opcional con un Alumno
        public int? AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
    }
}
