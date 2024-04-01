using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE4G1.AccesoADatos
{
    public class AppDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            const string conn = "Data Source=.;Initial Catalog=practica20240401db;Integrated Security=True";
            optionsBuilder.UseSqlServer(conn);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
