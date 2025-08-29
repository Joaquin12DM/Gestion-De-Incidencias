using System;

namespace GestionIncidencia.Application.DTO.Response
{
    public class IncidenciaResponse
    {
        public int IdIncidencia { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioId { get; set; }
        public int? AlumnoId { get; set; }
        public AlumnoResponse Alumno { get; set; }
    }
}
