using EcoJardimProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoJardimProject.Data.ExtensionsData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Geral
            modelBuilder.Entity<Status>().HasData(Status.ObterDados());
            #endregion
        }
    }
}
