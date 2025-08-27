using Incidencias.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Incidencias.Dominio.IRepositorio
{
    public interface IIncidenciaRepositorio
    {
        Task<IEnumerable<Incidencia>> ListarIncidenciaAsync();
        Task<IEnumerable<Incidencia>> ListarIncidenciaNoResueltaAsync();
        Task<IEnumerable<Incidencia>> ListarIncidenciaResueltaAsync();
        Task<IEnumerable<Incidencia>> ListarPorFechaCreacionAsync(DateTime fechaInicio, DateTime? fechaFin = null);
        Task<Incidencia> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Incidencia incidencia);
        Task ActualizarAsync(Incidencia incidencia);
        Task ActualizarEstadoResueltoAsync(int idIncidencia);
        Task<IEnumerable<AlumnoIncidenciaCount>> TopAlumnosConMasIncidenciasAsync(int top);
    }
}
