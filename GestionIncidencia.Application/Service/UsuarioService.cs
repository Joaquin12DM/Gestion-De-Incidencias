using Incidencias.Dominio.Entidades;
using Incidencias.Dominio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Aplicacion.Service
{
    public class UsuarioService
    {
        private readonly IUsuarioRepositorio _repositorio;

        public UsuarioService(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Task<Usuario?> ValidarCredencialesAsync(string username, string contrasena)
        {
            return _repositorio.ObtenerCredencialesAsync(username, contrasena);
        }

       


    }
}
