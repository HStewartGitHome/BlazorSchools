using BlazorSchools.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorSchools.Shared.Data.EnitityFramework
{
    public class SchoolDBContext : DbContext
    {
        public DbSet<SchoolModel> SchoolModels { get; set; }

        public SchoolDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}