using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Mvc.Models
{
    public class DatabaseContext
        : DbContext, IDatabaseContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Bookshop");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderLine>()
                .HasKey(ol => new {ol.BookId, ol.OrderId});


            //Seed Data
            var books = new List<Book>
            {
                new Book { Id = 1, Author = "Gojko Adzic", Title = "Bridging the Communication Gap", Price = 12.20M },
                new Book { Id = 2, Author = "Gojko Adzic", Title = "Specification By Example", Price = 15.30M },
                new Book { Id = 3, Author = "Lisa Crispin and Janet Gregory", Title = "Agile Testing", Price = 20.20M },
                new Book { Id = 4, Author = "Mitch Lacey", Title = "The Scrum Field Guide", Price = 15.31M },
                new Book { Id = 5, Author = "Martin Fowler", Title = "Refactoring", Price = 29.55M },
                new Book { Id = 6, Author = "Esther Derby and Diana Larsen", Title = "Agile Retrospectives", Price = 16.99M },
                new Book { Id = 7, Author = "Matt Wynne and Aslak Hellesoy", Title = "The Cucumber Book", Price = 18.00M },
                new Book { Id = 8, Author = "David Chelimsky", Title = "The RSpec Book", Price = 17.50M }
            };

            foreach (var book in books)
            {
                modelBuilder.Entity<Book>().HasData(book);
            }
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }
    }
}