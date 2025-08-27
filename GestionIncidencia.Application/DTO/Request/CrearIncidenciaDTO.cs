using System;

namespace GestionIncidencia.Application.DTO.Request
{
    public class CrearIncidenciaDTO
    {
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
        public int UsuarioId { get; set; }
        public int? AlumnoId { get; set; }
    }
}
