using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;

namespace BlazorSchools.Server.Data.EnitityFramework
{
    public class SchoolDBContextFactory : IDesignTimeDbContextFactory<SchoolDBContext>
    {
        public string _connectString { get; set; }
        public IConfiguration _configuration { get; set; }

        public SchoolDBContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;

            try
            {
                _connectString = configuration.GetConnectionString("EFDB");
            }
            catch( Exception e )
            {
                Trace.TraceError("Exception get connection string", e);
            }
        }

        public SchoolDBContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<SchoolDBContext>();
            string connectionString = _connectString;

            options.UseSqlServer(connectionString, o =>

            {
                o.EnableRetryOnFailure();
            });

            return new SchoolDBContext(options.Options);
        }
    }
}
