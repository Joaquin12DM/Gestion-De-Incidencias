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

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-AR47FB7\\SQLEXPRESS;Initial Catalog=Incidencias;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

            return new IncidenciasDbContext(optionsBuilder.Options);
        }
    }
}
