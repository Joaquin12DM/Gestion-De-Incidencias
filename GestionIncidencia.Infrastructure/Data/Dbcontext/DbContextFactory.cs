using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Infraestructura.Data.Dbcontext
{
    public class DbContextFactory: IDesignTimeDbContextFactory<IncidenciasDbContext>
    {
        public IncidenciasDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IncidenciasDbContext>();

            optionsBuilder.UseSqlServer("");

            return new IncidenciasDbContext(optionsBuilder.Options);
        }
    }
}
