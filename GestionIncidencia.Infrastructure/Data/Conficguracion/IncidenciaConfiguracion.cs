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
    public class IncidenciaConfiguracion: IEntityTypeConfiguration<Incidencia>
    {
        public void Configure(EntityTypeBuilder<Incidencia> builder)
        {
            builder.HasKey(i => i.IdIncidencia);
            // Incidencia ↔ Alumno (N:N)
            builder.HasMany(i => i.Alumnos)
                   .WithMany(a => a.Incidencias);

            // Incidencia ↔ Docente (N:1)
            builder.HasOne(i => i.Docente)
                   .WithMany(u => u.IncidenciasCreadas)
                   .HasForeignKey(i => i.DocenteId);

            // Incidencia ↔ Técnico (N:1)
            builder.HasOne(i => i.Tecnico)
                   .WithMany(u => u.IncidenciasAsignadas)
                   .HasForeignKey(i => i.TecnicoId);

            // Incidencia ↔ Comentarios (1:N)
            builder.HasMany(i => i.Comentarios)
                   .WithOne(c => c.Incidencia)
                   .HasForeignKey(c => c.IncidenciaId);
        }

    }
}
