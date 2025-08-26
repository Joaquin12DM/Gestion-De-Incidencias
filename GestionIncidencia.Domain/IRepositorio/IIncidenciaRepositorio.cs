using Incidencias.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Dominio.IRepositorio
{
    public interface IIncidenciaRepositorio
    {
        Task<IEnumerable<Incidencia>> ListarIncidenciaAsync();
        Task<IEnumerable<Incidencia>> ListarIncidenciaNoResueltaAsync();
        Task<IEnumerable<Incidencia>> ListarIncidenciaResueltaAsync();
        Task<Incidencia> ObtenerPorIdAsync(int id);
        public void ActualizarEstadoResuelto(int idIncidencia);
        Task AgregarAsync(Incidencia incidencia);
        Task ActualizarAsync(Incidencia incidencia);
        Task<IEnumerable<Incidencia>> ListarPorTecnicoAsync(int tecnicoId);

        Task ActualizarEstadoResueltoAsync(int idIncidencia);
    }
}
