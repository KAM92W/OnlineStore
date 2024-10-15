using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
        //public ApplicationContext() => Database.EnsureCreated();

        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Model> Models => Set<Model>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Property> Properties => Set<Property>();
    }
}