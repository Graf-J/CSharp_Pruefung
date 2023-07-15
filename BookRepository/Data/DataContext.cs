using BookRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRepository.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) 
        {
            CurrentBooks = Set<Book>();
            ArchivedBooks= Set<Book>();
        }

        // Define DbSets which represent Tables in the MariaDB
        public DbSet<Book> CurrentBooks { get; set; }
        public DbSet<Book> ArchivedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Use the Fluent API to specify the table names for the "CurrentBooks" and "ArchivedBooks" entities
            modelBuilder.Entity<Book>().ToTable("aktuelle_buecher");
            modelBuilder.Entity<Book>().ToTable("archivierte_buecher");
        }
    }
}
