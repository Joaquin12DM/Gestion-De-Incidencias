using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionIncidencia.Application.DTO;
using GestionIncidencia.Application.DTO.Response;
using Incidencias.Dominio.Entidades;

namespace GestionIncidencia.Application.Mapper
{
    public static class IncidenciaMapper
    {
        public static IncidenciaResponse ToResponse(Incidencia entidad)
        {
            if (entidad == null) return null;

            return new IncidenciaResponse
            {
                IdIncidencia = entidad.IdIncidencia,
                Titulo = entidad.Titulo,
                Descripcion = entidad.Descripcion,
                Estado = entidad.Estado,
                Prioridad = entidad.Prioridad,
                Tipo = entidad.Tipo,
                FechaCreacion = entidad.FechaCreacion,
                FechaActualizacion = entidad.FechaActualizacion
            };
        }

        public static List<IncidenciaResponse> ToResponseList(IEnumerable<Incidencia> entidades)
        {
            if (entidades == null) return new List<IncidenciaResponse>();
            return entidades.Select(ToResponse).ToList();
        }

        public static Incidencia ToEntity(CreraIncidenciaDTO dto)
        {
            if (dto == null) return null;

            return new Incidencia
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                Estado = dto.Estado ?? "Pendiente",
                Prioridad = dto.Prioridad ?? "Media",
                Tipo = dto.Tipo ?? "General",
                FechaCreacion = DateTime.Now,
                FechaActualizacion = DateTime.Now,
                DocenteId = dto.DocenteId,
                Alumnos = dto.Alumnso

            };
        }


    }
}
