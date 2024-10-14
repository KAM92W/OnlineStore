using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Product> Brands => Set<Product>();
        public DbSet<Product> Categories => Set<Product>();
        public DbSet<Product> Models => Set<Product>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Product> Properties => Set<Product>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
    }
}
