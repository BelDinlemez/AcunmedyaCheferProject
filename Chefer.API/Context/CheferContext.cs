using Chefer.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chefer.API.Context
{
    public class CheferContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=OSCAR; database=CheferDb;integrated security=true; trustServerCertificate=true");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
