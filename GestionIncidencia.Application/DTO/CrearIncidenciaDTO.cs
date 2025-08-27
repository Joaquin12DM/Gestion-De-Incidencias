using Incidencias.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIncidencia.Application.DTO
{
    public class CreraIncidenciaDTO
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string Prioridad { get; set; }
        public string Tipo { get; set; }
        public int DocenteId { get; set; }

        public List<Usuario> Alumnso { get; set; } // Lista de IDs de alumnos asociados




    }
}
