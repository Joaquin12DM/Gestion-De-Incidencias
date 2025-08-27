using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incidencias.Dominio.Entidades;

namespace GestionIncidencia.Domain.Entidades
{
    public class Soporte
    {
        public int IdSoporte { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }


    }
}
