using Incidencias.Dominio.Entidades;
using Incidencias.Dominio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Incidencias.Aplicacion.Service
{
    public class IncidenciaService
    {
        private readonly IIncidenciaRepositorio _repositorio;

        public IncidenciaService(IIncidenciaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Task<IEnumerable<Incidencia>> ListarAsync() => _repositorio.ListarIncidenciaAsync();
        public Task<IEnumerable<Incidencia>> ListarNoResueltaAsync() => _repositorio.ListarIncidenciaNoResueltaAsync();
        public Task<IEnumerable<Incidencia>> ListarResueltaAsync() => _repositorio.ListarIncidenciaResueltaAsync();
        public Task<IEnumerable<Incidencia>> ListarPorFechaCreacionAsync(DateTime inicio, DateTime? fin = null) => _repositorio.ListarPorFechaCreacionAsync(inicio, fin);
        public Task<Incidencia> ObtenerPorIdAsync(int id) => _repositorio.ObtenerPorIdAsync(id);
        public Task AgregarAsync(Incidencia incidencia) => _repositorio.AgregarAsync(incidencia);
        public Task ActualizarAsync(Incidencia incidencia) => _repositorio.ActualizarAsync(incidencia);
        public Task ActualizarEstadoResueltoAsync(int idIncidencia) => _repositorio.ActualizarEstadoResueltoAsync(idIncidencia);
        public Task<IEnumerable<AlumnoIncidenciaCount>> TopAlumnosConMasIncidenciasAsync(int top = 3) => _repositorio.TopAlumnosConMasIncidenciasAsync(top);
    }
}

