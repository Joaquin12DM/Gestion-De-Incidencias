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
        Task<Incidencia> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Incidencia incidencia);
        Task ActualizarAsync(Incidencia incidencia);
        Task<IEnumerable<Incidencia>> ListarPorTecnicoAsync(int tecnicoId);
    }
}
