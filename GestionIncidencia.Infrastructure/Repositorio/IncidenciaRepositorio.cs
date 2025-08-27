using Incidencias.Dominio.Entidades;
using Incidencias.Dominio.IRepositorio;
using Incidencias.Infraestructura.Data.Dbcontext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Incidencias.Infraestructura.Repositorio
{
    public class IncidenciaRepositorio: IIncidenciaRepositorio
    {
        private readonly IncidenciasDbContext _context;

        public IncidenciaRepositorio(IncidenciasDbContext context)
        {
            _context = context;
        }

        public async Task AgregarAsync(Incidencia incidencia)
        {
            _context.Incidencias.Add(incidencia);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Incidencia incidencia)
        {
            _context.Incidencias.Update(incidencia);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarEstadoResueltoAsync(int idIncidencia)
        {
            var incidencia = await _context.Incidencias.FirstOrDefaultAsync(i => i.IdIncidencia == idIncidencia);
            if (incidencia != null)
            {
                incidencia.Estado = "Resuelto";
                await _context.SaveChangesAsync();
            }
        }

        private IQueryable<Incidencia> BaseQuery(bool tracking = false)
        {
            var query = _context.Incidencias.Include(i => i.Alumno) as IQueryable<Incidencia>;
            if (!tracking) query = query.AsNoTracking();
            return query;
        }

        public async Task<IEnumerable<Incidencia>> ListarIncidenciaAsync()
        {
            return await BaseQuery().OrderByDescending(i => i.FechaCreacion).ToListAsync();
        }

        public async Task<IEnumerable<Incidencia>> ListarIncidenciaNoResueltaAsync()
        {
            return await BaseQuery().Where(i => i.Estado != "Resuelto").OrderByDescending(i => i.FechaCreacion).ToListAsync();
        }

        public async Task<IEnumerable<Incidencia>> ListarIncidenciaResueltaAsync()
        {
            return await BaseQuery().Where(i => i.Estado == "Resuelto").OrderByDescending(i => i.FechaCreacion).ToListAsync();
        }

        public async Task<IEnumerable<Incidencia>> ListarPorFechaCreacionAsync(DateTime fechaInicio, DateTime? fechaFin = null)
        {
            var fin = fechaFin ?? fechaInicio;
            var inicioNorm = fechaInicio.Date;
            var finNorm = fin.Date.AddDays(1).AddTicks(-1);
            return await BaseQuery()
                .Where(i => i.FechaCreacion >= inicioNorm && i.FechaCreacion <= finNorm)
                .OrderByDescending(i => i.FechaCreacion)
                .ToListAsync();
        }

        public async Task<Incidencia> ObtenerPorIdAsync(int id)
        {
            return await BaseQuery().FirstOrDefaultAsync(i => i.IdIncidencia == id);
        }

        public async Task<IEnumerable<AlumnoIncidenciaCount>> TopAlumnosConMasIncidenciasAsync(int top)
        {
            return await _context.Incidencias
                .Where(i => i.AlumnoId != null)
                .GroupBy(i => new { i.AlumnoId, i.Alumno.Nombre, i.Alumno.Apellidos })
                .Select(g => new AlumnoIncidenciaCount
                {
                    AlumnoId = g.Key.AlumnoId.Value,
                    NombreCompleto = (g.Key.Nombre + " " + g.Key.Apellidos).Trim(),
                    TotalIncidencias = g.Count()
                })
                .OrderByDescending(x => x.TotalIncidencias)
                .ThenBy(x => x.NombreCompleto)
                .Take(top)
                .ToListAsync();
        }
    }
}
