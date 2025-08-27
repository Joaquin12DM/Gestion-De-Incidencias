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
    public class UsuarioRepositorio: IUsuarioRepositorio
    {
        private readonly IncidenciasDbContext _context;

        public UsuarioRepositorio(IncidenciasDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObtenerCredencialesAsync(string username, string contrasena)
        {
            return await _context.Usuarios
                .Include(u => u.Alumnos)
                .Include(u => u.Docentes)
                .Include(u => u.Soportes)
                .FirstOrDefaultAsync(p => p.NombreUsuario == username && p.Password == contrasena);
        }

    }
}
