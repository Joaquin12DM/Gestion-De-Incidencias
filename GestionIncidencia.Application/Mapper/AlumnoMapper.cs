using GestionIncidencia.Application.DTO.Response;
using GestionIncidencia.Domain.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace GestionIncidencia.Application.Mapper
{
    public static class AlumnoMapper
    {
        public static AlumnoResponse ToResponse(Alumno entidad)
        {
            if (entidad == null) return null;
            return new AlumnoResponse
            {
                IdAlumno = entidad.IdAlumno,
                Nombre = entidad.Nombre,
                Apellidos = entidad.Apellidos,
                DNI = entidad.DNI,
                Email = entidad.Email,
                Grado = entidad.Grado
            };
        }

        public static List<AlumnoResponse> ToResponseList(IEnumerable<Alumno> entidades)
            => entidades?.Select(ToResponse).ToList() ?? new List<AlumnoResponse>();
    }
}
