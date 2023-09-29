using EcoJardimPro.DOMAIN.Entity.All;
using Microsoft.EntityFrameworkCore;

namespace EcoJardimPro.DATA.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region All
            modelBuilder.Entity<PerfilUsuario>().HasData(PerfilUsuario.ObterDados());
            #endregion
        }
    }
}
