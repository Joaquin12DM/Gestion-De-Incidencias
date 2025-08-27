using Incidencias.Dominio.Entidades;
using Incidencias.Dominio.Enun;
using Incidencias.Dominio.IRepositorio;
using System.Collections.Generic;
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

        public Task<IEnumerable<Usuario>> Alumno(int id)
        {
            var rol = RolUsuario.Alumno;
            return _repositorio.Alumno(id, rol);
        }

        public Task<IEnumerable<GestionIncidencia.Domain.Entidades.Alumno>> ListarTodosAsync() => _repositorio.ListarTodosAsync();
        public Task<IEnumerable<GestionIncidencia.Domain.Entidades.Alumno>> ListarPorGradoAsync(string grado) => _repositorio.ListarPorGradoAsync(grado);
        public Task<GestionIncidencia.Domain.Entidades.Alumno> ObtenerPorIdAsync(int idAlumno) => _repositorio.ObtenerPorIdAsync(idAlumno);
    }
}
