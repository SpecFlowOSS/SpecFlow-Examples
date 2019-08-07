using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BookShop.Mvc.Models
{
    public interface IDatabaseContext : IDisposable
    {
        DbSet<Order> Orders { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<OrderLine> OrderLines { get; set; }
        DatabaseFacade Database { get; }
        int SaveChanges();
    }

    public class DatabaseContext
        : DbContext, IDatabaseContext
    {
        private readonly IConfiguration _config;

        public DatabaseContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_config.GetConnectionString("BookShop"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderLine>()
                .HasKey(ol => new {ol.BookId, ol.OrderId});
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }
    }
}