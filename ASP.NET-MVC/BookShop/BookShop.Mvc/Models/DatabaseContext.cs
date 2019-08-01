using Microsoft.EntityFrameworkCore;

namespace BookShop.Mvc.Models
{
    public class DatabaseContext
        : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Filename=BookShop.db");
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