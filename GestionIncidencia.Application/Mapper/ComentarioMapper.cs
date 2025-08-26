using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionIncidencia.Application.DTO.Request;
using Incidencias.Dominio.Entidades;

namespace GestionIncidencia.Application.Mapper
{
    public static class ComentarioMapper
    {
        public static Comentario ToDomain(ComentarioRequest request)
        {
            return new Comentario
            {
                Texto = request.Texto,
                FechaCreacion = request.FechaCreacion,
                IncidenciaId = request.IncidenciaId
            };
        }
    }
}
