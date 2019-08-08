using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Mvc.Models
{
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


            //Seed Data
            var books = new List<Book>
            {
                new Book { Id = 1, Author = "Gojko Adzic", Title = "Bridging the Communication Gap", Price = (decimal)12.20 },
                new Book { Id = 2, Author = "Gojko Adzic", Title = "Specification By Example", Price = (decimal)15.30 },
                new Book { Id = 3, Author = "Lisa Crispin and Janet Gregory", Title = "Agile Testing", Price = (decimal)20.20 },
                new Book { Id = 4, Author = "Mitch Lacey", Title = "The Scrum Field Guide", Price = (decimal)15.31 },
                new Book { Id = 5, Author = "Martin Fowler", Title = "Refactoring", Price = (decimal)29.55 },
                new Book { Id = 6, Author = "Esther Derby and Diana Larsen", Title = "Agile Retrospectives", Price = (decimal)16.99 },
                new Book { Id = 7, Author = "Matt Wynne and Aslak Hellesoy", Title = "The Cucumber Book", Price = (decimal)18.00 },
                new Book { Id = 8, Author = "David Chelimsky", Title = "The RSpec Book", Price = (decimal)17.50 }
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