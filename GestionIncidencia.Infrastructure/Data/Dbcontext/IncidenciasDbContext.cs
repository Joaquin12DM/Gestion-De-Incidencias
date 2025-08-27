using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionIncidencia.Domain.Entidades;
using GestionIncidencia.Infrastructure.Data.Configuracion;
using Incidencias.Dominio.Entidades;
using Incidencias.Infraestructura.Data.Conficguracion;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Soporte> Soportes { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IncidenciaConfiguracion());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());
            modelBuilder.ApplyConfiguration(new DocenteConfiguracion());
            modelBuilder.ApplyConfiguration(new SoporteConfiguracion());
            modelBuilder.ApplyConfiguration(new AlumnoConfiguracion());
        }
    }
}
