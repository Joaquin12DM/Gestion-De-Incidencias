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

        public async Task<Usuario?> ObtenerCredencialesAsync(string email, string contrasenaHash)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.ContrasenaHash == contrasenaHash);
        }
    }
}
