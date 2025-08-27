using Incidencias.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace GestionIncidencia.Domain.Entidades
{
    public class Docente
    {
        public int IdDocente { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Materia { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
