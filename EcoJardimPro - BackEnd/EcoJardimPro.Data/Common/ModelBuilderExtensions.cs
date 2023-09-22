using EcoJardimPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoJardimPro.Data.Common
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region All
            modelBuilder.Entity<UserProfile>().HasData(UserProfile.ObterDados());
            #endregion
        }
    }
}
