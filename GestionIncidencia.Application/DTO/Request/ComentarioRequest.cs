using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incidencias.Dominio.Entidades;

namespace GestionIncidencia.Application.DTO.Request
{
    public class ComentarioRequest
    {
        public string Texto { get; set; }
        public DateTime FechaCreacion { get; set; }

        public int IncidenciaId { get; set; }
    }
}
