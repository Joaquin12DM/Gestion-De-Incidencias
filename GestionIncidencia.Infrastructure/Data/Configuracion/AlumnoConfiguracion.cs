using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionIncidencia.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionIncidencia.Infrastructure.Data.Configuracion
{
    public class AlumnoConfiguracion : IEntityTypeConfiguration<Alumno>
    {
        public void Configure(EntityTypeBuilder<Alumno> builder)
        {
            builder.ToTable("Alumno");
            builder.HasKey(a => a.IdAlumno);

            builder.Property(a => a.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Apellidos).IsRequired().HasMaxLength(100);
            builder.Property(a => a.DNI).HasMaxLength(20);
            builder.Property(a => a.Email).HasMaxLength(100);
            builder.Property(a => a.Grado).HasMaxLength(50);

            builder.HasOne(a => a.Usuario)
                   .WithMany(u => u.Alumnos)
                   .HasForeignKey(a => a.UsuarioId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
