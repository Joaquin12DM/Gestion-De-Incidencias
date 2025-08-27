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
    public class DocenteConfiguracion : IEntityTypeConfiguration<Docente>
    {
        public void Configure(EntityTypeBuilder<Docente> builder)
        {
            builder.ToTable("Docente");
            builder.HasKey(d => d.IdDocente);

            builder.Property(d => d.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Apellidos).IsRequired().HasMaxLength(100);
            builder.Property(d => d.DNI).HasMaxLength(20);
            builder.Property(d => d.Email).HasMaxLength(100);
            builder.Property(d => d.Materia).HasMaxLength(100);

            builder.HasOne(d => d.Usuario)
                   .WithMany(u => u.Docentes)
                   .HasForeignKey(d => d.UsuarioId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
