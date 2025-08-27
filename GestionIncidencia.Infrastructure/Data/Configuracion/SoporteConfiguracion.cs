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
    public class SoporteConfiguracion : IEntityTypeConfiguration<Soporte>
    {
        public void Configure(EntityTypeBuilder<Soporte> builder)
        {
            builder.ToTable("Soporte");
            builder.HasKey(s => s.IdSoporte);

            builder.Property(s => s.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Apellidos).IsRequired().HasMaxLength(100);
            builder.Property(s => s.DNI).HasMaxLength(20);
            builder.Property(s => s.Email).HasMaxLength(100);

            builder.HasOne(s => s.Usuario)
                   .WithMany(u => u.Soportes)
                   .HasForeignKey(s => s.UsuarioId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
