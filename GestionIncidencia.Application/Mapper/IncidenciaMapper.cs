using System;
using System.Collections.Generic;
using System.Linq;
using GestionIncidencia.Application.DTO.Request;
using GestionIncidencia.Application.DTO.Response;
using Incidencias.Dominio.Entidades;

namespace GestionIncidencia.Application.Mapper
{
    public static class IncidenciaMapper
    {
        private static readonly TimeZoneInfo _saPacific = ResolveSaPacific();

        private static TimeZoneInfo ResolveSaPacific()
        {
            string[] ids = new[] { "SA Pacific Standard Time", "America/Bogota", "America/Lima" };
            foreach (var id in ids)
            {
                try { return TimeZoneInfo.FindSystemTimeZoneById(id); } catch { }
            }
            return TimeZoneInfo.Utc;
        }

        public static IncidenciaResponse ToResponse(Incidencia entidad) =>
            entidad == null
                ? null
                : new IncidenciaResponse
                {
                    IdIncidencia = entidad.IdIncidencia,
                    Descripcion = entidad.Descripcion,
                    Estado = entidad.Estado,
                    Tipo = entidad.Tipo,
                    FechaCreacion = TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(entidad.FechaCreacion, DateTimeKind.Utc), _saPacific),
                    UsuarioId = entidad.UsuarioId,
                    AlumnoId = entidad.AlumnoId,
                    Alumno = entidad.Alumno != null ? AlumnoMapper.ToResponse(entidad.Alumno) : null
                };

        public static List<IncidenciaResponse> ToResponseList(IEnumerable<Incidencia> entidades) =>
            entidades?.Select(ToResponse).ToList() ?? new List<IncidenciaResponse>();

        public static Incidencia ToEntity(CrearIncidenciaDTO dto)
        {
            if (dto == null) return null;
            return new Incidencia
            {
                Descripcion = dto.Descripcion,
                Estado = string.IsNullOrWhiteSpace(dto.Estado) ? "Pendiente" : dto.Estado,
                Tipo = string.IsNullOrWhiteSpace(dto.Tipo) ? "General" : dto.Tipo,
                UsuarioId = dto.UsuarioId,
                AlumnoId = dto.AlumnoId
            };
        }

        public static AlumnoIncidenciaCountResponse ToResponse(AlumnoIncidenciaCount entidad) =>
            entidad == null ? null : new AlumnoIncidenciaCountResponse
            {
                AlumnoId = entidad.AlumnoId,
                NombreCompleto = entidad.NombreCompleto,
                TotalIncidencias = entidad.TotalIncidencias
            };

        public static List<AlumnoIncidenciaCountResponse> ToResponseList(IEnumerable<AlumnoIncidenciaCount> entidades) =>
            entidades?.Select(ToResponse).ToList() ?? new List<AlumnoIncidenciaCountResponse>();
    }
}
