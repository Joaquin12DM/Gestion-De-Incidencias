using Incidencias.Dominio.Entidades;
using Incidencias.Dominio.IRepositorio;
using Incidencias.Infraestructura.Data.Dbcontext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<IEnumerable<Alumno>> AlumnoInstitucion(int institucionId)
        {
            return await _context.Alumnos
                .Where(a => a.InstitucionId == institucionId)
                .ToListAsync();
        }
    }
}
