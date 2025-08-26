using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Dominio.Entidades
{
    public class Incidencia
    {
        public int IdIncidencia { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string Prioridad { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        // Relación con Alumnos (opcional)
        public ICollection<Alumno>? Alumnos { get; set; }
        // Usuario que crea la incidencia (Docente)
        public int DocenteId { get; set; }
        public Usuario Docente { get; set; }

        // Usuario técnico que atiende la incidencia (puede ser null si aún no asignan técnico)
        public int? TecnicoId { get; set; }
        public Usuario Tecnico { get; set; }

        // Relación con Comentarios
        public ICollection<Comentario> Comentarios { get; set; }
    }
}
