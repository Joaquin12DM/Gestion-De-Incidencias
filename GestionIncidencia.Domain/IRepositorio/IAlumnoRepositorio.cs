using Incidencias.Dominio.Entidades;
using Incidencias.Dominio.Enun;
using GestionIncidencia.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Dominio.IRepositorio
{
    public interface IAlumnoRepositorio
    {
        // Método existente: devuelve usuarios con rol alumno filtrando por IdUsuario
        Task<IEnumerable<Usuario>> Alumno(int id, RolUsuario rol);

        // Nuevos métodos: listar entidades Alumno directamente
        Task<IEnumerable<Alumno>> ListarTodosAsync();
        Task<IEnumerable<Alumno>> ListarPorGradoAsync(string grado);
        Task<Alumno> ObtenerPorIdAsync(int idAlumno); // nuevo
    }
}
