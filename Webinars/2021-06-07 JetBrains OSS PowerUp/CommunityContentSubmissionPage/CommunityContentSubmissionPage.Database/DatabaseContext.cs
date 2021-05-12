#nullable enable
using System;
using System.Threading.Tasks;
using CommunityContentSubmissionPage.Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CommunityContentSubmissionPage.Database
{
    public interface IDatabaseContext
    {
        DbSet<SubmissionEntry> SubmissionEntries { get; set; }

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default);
    }

    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public string? ConnectionString { get; internal set; }


        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (ConnectionString is null)
            {
                ConnectionString = Environment.GetEnvironmentVariable("CommunityContent_ConnectionString");
            }

            optionsBuilder.UseSqlServer(ConnectionString);
            //optionsBuilder.UseInMemoryDatabase("CommunitySubmissions");
        }

        public DbSet<SubmissionEntry> SubmissionEntries { get; set; }
    }
    
}
