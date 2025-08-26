using Incidencias.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Infraestructura.Data.Conficguracion
{
    public class AlunmoConfiguracion: IEntityTypeConfiguration<Alumno>
    {
        public void Configure(EntityTypeBuilder<Alumno> builder)
        {
            builder.HasKey(a => a.IdAlumno);
            // Alumno ↔ Institucion (N:1)
            builder.HasMany(a => a.Incidencias)
       .WithMany(i => i.Alumnos) // ojo, aquí la colección debe ser plural en Incidencia
       .UsingEntity<Dictionary<string, object>>(
            "AlumnoIncidencia",
            j => j.HasOne<Incidencia>()
                  .WithMany()
                  .HasForeignKey("IncidenciaId")
                  .OnDelete(DeleteBehavior.Restrict), 
            j => j.HasOne<Alumno>()
                  .WithMany()
                  .HasForeignKey("AlumnoId")
                  .OnDelete(DeleteBehavior.Cascade)
        );
        }
    }
}
