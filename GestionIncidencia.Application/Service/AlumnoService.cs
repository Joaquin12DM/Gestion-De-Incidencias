using Incidencias.Dominio.Entidades;
using Incidencias.Dominio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Aplicacion.Service
{
    public class AlumnoService
    {
        private readonly IAlumnoRepositorio _repositorio;

        public AlumnoService(IAlumnoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Task<IEnumerable<Alumno>> ListarPorInstitucionAsync(int institucionId)
        {
            return _repositorio.AlumnoInstitucion(institucionId);
        }


    }
}
