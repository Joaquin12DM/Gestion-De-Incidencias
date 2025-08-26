using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Dominio.Entidades
{
    public class Alumno
    {
        public int IdAlumno { get; set; }
        public string NombreCompleto { get; set; }
        public string Grado { get; set; }
        public DateTime FechaNacimiento { get; set; }

        // Relación con Institución
        public int InstitucionId { get; set; }
        public Institucion Institucion { get; set; }

        // Relación con Incidencias
        public ICollection<Incidencia> Incidencias { get; set; }
    }
}
