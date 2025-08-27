using Incidencias.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Infraestructura.Data.Conficguracion
{
    public class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.IdUsuario);
            // Usuario ↔ Institucion (N:1)
            builder.HasOne(u => u.Institucion)
                   .WithMany(i => i.Usuarios)
                   .HasForeignKey(u => u.InstitucionId);

            // Usuario (Docente) ↔ Incidencias creadas (1:N)
            builder.HasMany(u => u.IncidenciasCreadas)
                   .WithOne(i => i.Docente)
                   .HasForeignKey(i => i.DocenteId);

            // Usuario (Técnico) ↔ Incidencias asignadas (1:N)
            builder.HasMany(u => u.IncidenciasAsignadas)
                   .WithOne(i => i.Tecnico)
                   .HasForeignKey(i => i.TecnicoId);
            // Usuario (Alumno) ↔ Incidencias (N:N)
            builder.HasMany(u => u.Incidencias)
                   .WithMany(i => i.Alumnos)
                   .UsingEntity(j => j.ToTable("IncidenciaAlumno")); // tabla de unión implícita

        }
    }
}
