using Incidencias.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Dominio.IRepositorio
{
    public interface IAlumnoRepositorio
    {
        Task<IEnumerable<Alumno>> AlumnoInstitucion(int institucionId);
    }
}
