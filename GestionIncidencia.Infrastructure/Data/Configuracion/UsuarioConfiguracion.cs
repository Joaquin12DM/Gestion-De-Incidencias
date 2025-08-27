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
            builder.ToTable("Usuario");
            builder.HasKey(u => u.IdUsuario);

            builder.Property(u => u.NombreUsuario).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Rol).IsRequired();
        }
    }
}
