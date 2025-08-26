using Incidencias.Dominio.Entidades;
using Incidencias.Dominio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Aplicacion.Service
{
    public class ComentarioService
    {
        private readonly IComentarioRepositorio _repositorio;

        public ComentarioService(IComentarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Task<IEnumerable<Comentario>> ListarPorIncidenciaAsync(int incidenciaId)
        {
            return _repositorio.ListarComentarioAsync(incidenciaId);
        }

        public Task AgregarAsync(Comentario comentario)
        {
            return _repositorio.AgregarAsync(comentario);
        }
    }
}
