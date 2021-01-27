using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;

namespace BlazorSchools.Shared.Data.EnitityFramework
{
    public class SchoolDBContextFactory : IDesignTimeDbContextFactory<SchoolDBContext>
    {
        public string ConnectString { get; set; }
        public IConfiguration Configuration { get; set; }

        public SchoolDBContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;

            try
            {
                ConnectString = configuration.GetConnectionString("EFDB");
            }
            catch (Exception e)
            {
                Trace.TraceError("Exception get connection string", e);
            }
        }

        public SchoolDBContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<SchoolDBContext>();
            string connectionString = ConnectString;

            options.UseSqlServer(connectionString, o =>

            {
                o.EnableRetryOnFailure();
            });

            return new SchoolDBContext(options.Options);
        }
    }
}