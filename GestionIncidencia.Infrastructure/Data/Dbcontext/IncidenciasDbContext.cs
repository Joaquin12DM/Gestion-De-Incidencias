using Incidencias.Dominio.Entidades;
using Incidencias.Infraestructura.Data.Conficguracion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Infraestructura.Data.Dbcontext
{
    public class IncidenciasDbContext: DbContext
    {
        public IncidenciasDbContext(DbContextOptions<IncidenciasDbContext> options)
            : base(options)
        {
        }
       
        // DbSets para las entidades
        public DbSet<Incidencia> Incidencias { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Institucion> Instituciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new IncidenciaConfiguracion());
            modelBuilder.ApplyConfiguration(new ComentarioConfiguracion());
            modelBuilder.ApplyConfiguration(new InstitucionConfiguracion());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());



        }
    }
}
