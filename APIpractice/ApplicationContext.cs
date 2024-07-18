using APIpractice.Models;
using Microsoft.EntityFrameworkCore;

namespace APIpractice
{
    public class ApplicationContext : DbContext {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Order> Orders { get; set; } 
        public DbSet<Product> Products { get; set; }

        public ApplicationContext() =>
            Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql("Host=192.168.98.78;Port=5433;Database=postgres;Username=postgres;Password=practice");
    }
}