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
            builder.ToTable("Incidencia");
            builder.HasKey(i => i.IdIncidencia);

            builder.Property(i => i.Tipo).HasMaxLength(50);
            builder.Property(i => i.Descripcion).HasMaxLength(500);
            builder.Property(i => i.Estado).HasMaxLength(20);
            builder.Property(i => i.FechaCreacion).IsRequired();

            builder.HasOne(i => i.Usuario)
                   .WithMany()
                   .HasForeignKey(i => i.UsuarioId)
                   .IsRequired();
        }

    }
}
