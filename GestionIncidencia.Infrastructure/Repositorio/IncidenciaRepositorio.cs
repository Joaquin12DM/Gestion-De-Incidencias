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
    public class IncidenciaRepositorio: IIncidenciaRepositorio
    {
        private readonly IncidenciasDbContext _context;

        public IncidenciaRepositorio(IncidenciasDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Incidencia>> ListarIncidenciaAsync()
        {
            return await _context.Incidencias
                .Include(i => i.Tecnico) // si tienes relación con Usuario o Técnico
                .ToListAsync();
        }

        public async Task<Incidencia> ObtenerPorIdAsync(int id)
        {
            return await _context.Incidencias
                .Include(i => i.Tecnico)
                .FirstOrDefaultAsync(i => i.IdIncidencia == id);
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

        public async Task<IEnumerable<Incidencia>> ListarPorTecnicoAsync(int tecnicoId)
        {
            return await _context.Incidencias
                .Where(i => i.TecnicoId == tecnicoId)
                .ToListAsync();
        }
    }
}
