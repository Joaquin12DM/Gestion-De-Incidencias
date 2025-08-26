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
    public class InstitucionConfiguracion : IEntityTypeConfiguration<Institucion>
    {
        public void Configure(EntityTypeBuilder<Institucion> builder)
        {
            builder.HasKey(i => i.IdInstitucion);
            // Institucion ↔ Alumno (1:N)
            builder.HasMany(i => i.Alumnos)
                   .WithOne(a => a.Institucion)
                   .HasForeignKey(a => a.InstitucionId);

            // Institucion ↔ Usuario (1:N)
            builder.HasMany(i => i.Usuarios)
                   .WithOne(u => u.Institucion)
                   .HasForeignKey(u => u.InstitucionId);
        }
    }
}