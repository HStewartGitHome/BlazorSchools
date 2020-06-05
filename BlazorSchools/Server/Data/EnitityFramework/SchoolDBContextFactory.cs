using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BlazorSchools.Server.Data.EnitityFramework
{
    public class SchoolDBContextFactory : IDesignTimeDbContextFactory<SchoolDBContext>
    {
        public SchoolDBContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<SchoolDBContext>();
            string connectionString = @"Data Source = DESKTOP-BJK75NS\SQLEXPRESS;Database = SchoolDB; Integrated Security = True";


            options.UseSqlServer(connectionString, o =>

            {
                o.EnableRetryOnFailure();
            });

            return new SchoolDBContext(options.Options);
        }
    }
}
