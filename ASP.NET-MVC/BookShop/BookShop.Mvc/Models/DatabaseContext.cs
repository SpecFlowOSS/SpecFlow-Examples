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
            var books = new List<string[]>();
            books.Add(new string[]{ "1", "Gojko Adzic", "Bridging the Communication Gap", "12.20" });
            books.Add(new string[] { "2", "Gojko Adzic", "Specification By Example", "15.30" });
            books.Add(new string[] { "3", "Lisa Crispin and Janet Gregory", "Agile Testing", "20.20" });
            books.Add(new string[] { "4", "Mitch Lacey", "The Scrum Field Guide", "15.31" });
            books.Add(new string[] { "5", "Martin Fowler","Refactoring", "29.55" });
            books.Add(new string[] { "6", "Esther Derby and Diana Larsen", "Agile Retrospectives", "16.99" });
            books.Add(new string[] { "7", "Matt Wynne and Aslak Hellesoy","The Cucumber Book","18.00" });
            books.Add(new string[] { "8", "David Chelimsky", "The RSpec Book", "17.50" });

            var nfi = new NumberFormatInfo()
            {
                NumberDecimalSeparator = "."
            };

            foreach (var book in books)
            {
                modelBuilder.Entity<Book>().HasData(new Book
                { 
                    Id = int.Parse(book[0]),
                    Author = book[1],
                    Title = book[2],
                    Price = decimal.Parse(book[3], nfi),
                    OrderLines = null
                });
            }
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }
    }
}