using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Dominio.Entidades
{
    public class Comentario
    {
        public int IdComentario { get; set; }
        public string Texto { get; set; }
        public DateTime FechaCreacion { get; set; }

        public int IncidenciaId { get; set; }
        public Incidencia Incidencia { get; set; }
    }
}
