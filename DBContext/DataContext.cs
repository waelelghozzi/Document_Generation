using Generation_Documents.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;

namespace Generation_Documents.DBContext
{

    public class DataContext : DbContext
    {

        public DbSet<SalesInvoice> SalesInvoices { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                 new Client("STAR","TUNIS")
                 {
                     IdClient = 1,
                 }
               );
            base.OnModelCreating(modelBuilder);
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
    }
}

