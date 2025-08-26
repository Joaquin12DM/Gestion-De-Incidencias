using Incidencias.Dominio.Entidades;
using Incidencias.Dominio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Task<IEnumerable<Incidencia>> ListarAsync()
        {
            return _repositorio.ListarIncidenciaAsync();
        }

        public Task<IEnumerable<Incidencia>> ListarNoResueltaAsync()
        {
            return _repositorio.ListarIncidenciaNoResueltaAsync();
        }

        public Task<IEnumerable<Incidencia>> ListarResueltaAsync()
        {
            return _repositorio.ListarIncidenciaResueltaAsync();
        }

        public Task<Incidencia> ObtenerPorIdAsync(int id)
        {
            return _repositorio.ObtenerPorIdAsync(id);
        }

        public Task AgregarAsync(Incidencia incidencia)
        {
            return _repositorio.AgregarAsync(incidencia);
        }

        public Task ActualizarAsync(Incidencia incidencia)
        {
            return _repositorio.ActualizarAsync(incidencia);
        }

        public async Task ActualizarEstadoResueltoAsync(int idIncidencia)
        {
            await _repositorio.ActualizarEstadoResueltoAsync(idIncidencia);
        }

        public Task<IEnumerable<Incidencia>> ListarPorTecnicoAsync(int tecnicoId)
        {
            return _repositorio.ListarPorTecnicoAsync(tecnicoId);
        }
    }
}

