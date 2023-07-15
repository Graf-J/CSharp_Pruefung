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
            CurrentBooks = Set<CurrentBook>();
            ArchivedBooks= Set<ArchivedBook>();
        }

        // Define DbSets which represent Tables in the MariaDB
        public DbSet<CurrentBook> CurrentBooks { get; set; }
        public DbSet<ArchivedBook> ArchivedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Use the Fluent API to specify the table names for the "CurrentBooks" and "ArchivedBooks" entities
            modelBuilder.Entity<CurrentBook>().ToTable("aktuelle_buecher");
            modelBuilder.Entity<ArchivedBook>().ToTable("archivierte_buecher");
        }
    }
}
