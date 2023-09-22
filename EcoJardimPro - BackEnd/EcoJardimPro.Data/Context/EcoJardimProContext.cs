using EcoJardimPro.Data.Common;
using EcoJardimPro.Domain.Entities;
using EcoJardimPro.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EcoJardimPro.Data.Context
{
    public class EcoJardimProContext : DbContext
    {

        public SessionAppModel SessionApp { get; }
        public EcoJardimProContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();


            modelBuilder.Entity<User>().HasIndex(x => x.Login).IsUnique();
            modelBuilder.Entity<User>().Property(x => x.Senha).IsRequired();
        }

        public DbSet<User> Usuarios { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
