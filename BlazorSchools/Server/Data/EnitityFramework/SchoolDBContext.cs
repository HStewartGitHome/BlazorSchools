using BlazorSchools.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorSchools.Server.Data.EnitityFramework
{
    public class SchoolDBContext : DbContext
    {
        public DbSet<SchoolModel> SchoolModels { get; set; }

        public SchoolDBContext(DbContextOptions options) : base(options) { }
    }
}
