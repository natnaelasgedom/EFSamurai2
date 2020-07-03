using EFSamurai.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFSamurai.Data
{
    public class SamraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
            @"Server = (localdb)\MSSQLLocalDB; " +
            @"Database = EFSamurai; " +
            @"Trusted_Connection = True; ");
        }

    }
}
