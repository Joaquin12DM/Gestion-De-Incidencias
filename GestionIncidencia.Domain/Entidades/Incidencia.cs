using System;
using GestionIncidencia.Domain.Entidades;

namespace Incidencias.Dominio.Entidades
{
    public class Incidencia
    {
        public int IdIncidencia { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; private set; } = DateTime.UtcNow;
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int? AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
    }
}
