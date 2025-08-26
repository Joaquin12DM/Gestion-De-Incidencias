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
    public class ComentarioRepositorio: IComentarioRepositorio
    {
        private readonly IncidenciasDbContext _context;

        public ComentarioRepositorio(IncidenciasDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comentario>> ListarComentarioAsync(int incidenciaId)
        {
            return await _context.Comentarios
                .Where(c => c.IncidenciaId == incidenciaId)
                .Include(c => c.Incidencia.TecnicoId) // opcional: para traer datos del usuario que comentó
                .ToListAsync();
        }

        public async Task AgregarAsync(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();
        }
    }
}
