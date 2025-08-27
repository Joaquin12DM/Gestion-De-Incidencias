using Incidencias.Dominio.Entidades;
using Incidencias.Dominio.Enun;
using Incidencias.Dominio.IRepositorio;
using Incidencias.Infraestructura.Data.Dbcontext;
using Microsoft.EntityFrameworkCore;
using GestionIncidencia.Domain.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Incidencias.Infraestructura.Repositorio
{
    public class AlumnoRepositorio: IAlumnoRepositorio
    {
        private readonly IncidenciasDbContext _context;

        public AlumnoRepositorio(IncidenciasDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> Alumno(int id, RolUsuario rol)
        {
            return await _context.Usuarios
                .Where(a => a.IdUsuario == id && a.Rol == rol)
                .ToListAsync();
        }

        public async Task<IEnumerable<Alumno>> ListarTodosAsync()
        {
            return await _context.Alumnos.AsNoTracking().OrderBy(a => a.Apellidos).ThenBy(a => a.Nombre).ToListAsync();
        }

        public async Task<IEnumerable<Alumno>> ListarPorGradoAsync(string grado)
        {
            if (string.IsNullOrWhiteSpace(grado)) return Enumerable.Empty<Alumno>();
            grado = grado.Trim();
            return await _context.Alumnos.AsNoTracking()
                .Where(a => a.Grado == grado)
                .OrderBy(a => a.Apellidos).ThenBy(a => a.Nombre)
                .ToListAsync();
        }

        public async Task<Alumno> ObtenerPorIdAsync(int idAlumno)
        {
            return await _context.Alumnos.AsNoTracking().FirstOrDefaultAsync(a => a.IdAlumno == idAlumno);
        }
    }
}
