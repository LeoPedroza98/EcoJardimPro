using EcoJardimPro.DATA.Extensions;
using EcoJardimPro.DATA.Interface;
using EcoJardimPro.DOMAIN.Entity.All;
using EcoJardimPro.DOMAIN.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoJardimPro.DATA.Context
{
    public class EcoJardimProContext : DbContext
    {
        public SessionAppModel SessionApp { get; }
        
        public EcoJardimProContext( DbContextOptions<EcoJardimProContext> options, IEcoJardimProProvider filmeProvider) : base(options)
        {
            SessionApp = filmeProvider.SessionApp;
        }

        public EcoJardimProContext(DbContextOptions<EcoJardimProContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            modelBuilder.Entity<Usuario>().HasIndex(x => x.Login).IsUnique();
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).IsRequired();
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
