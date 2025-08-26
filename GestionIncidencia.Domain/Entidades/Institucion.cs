using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Dominio.Entidades
{
    public class Institucion
    {
        public int IdInstitucion { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Contacto { get; set; }
        public DateTime FechaCreacion { get; set; }

        public ICollection<Alumno> Alumnos { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
