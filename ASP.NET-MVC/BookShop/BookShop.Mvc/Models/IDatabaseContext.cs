using System;
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
}