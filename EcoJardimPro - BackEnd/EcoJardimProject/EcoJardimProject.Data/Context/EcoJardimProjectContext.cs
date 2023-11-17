using EcoJardimProject.Data.ExtensionsData;
using EcoJardimProject.Domain.Entities;
using EcoJardimProject.Domain.IdentityBase;
using Microsoft.EntityFrameworkCore;

namespace EcoJardimProject.Data.Context
{
    public class EcoJardimProjectContext : EcoJardimProjectContextBase<Usuario, Role, string>
    {
        private readonly ISessaoUsuario _sessaoUsuario;
        public EcoJardimProjectContext(DbContextOptions options, ISessaoUsuario sessaoUsuario) : base(options, sessaoUsuario)
        {
            _sessaoUsuario = sessaoUsuario;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }

        #region DbSets
        public DbSet<Usuario> Usuarios { get; set; }
        #endregion
    }
}
