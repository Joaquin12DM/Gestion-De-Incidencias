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
    public class ComentarioConfiguracion : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.HasKey(c => c.IdComentario);
            // Comentario ↔ Incidencia (N:1)
            builder.HasOne(c => c.Incidencia)
                   .WithMany(i => i.Comentarios)
                   .HasForeignKey(c => c.IncidenciaId);
        }
    }
}