using EcoJardimProject.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoJardimProject.Data.RepositoriesBase
{
    public interface IQueryRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> GetByAsync(long id);
        Task<TEntity> GetByIdAsync(long id, string include);
        Task<TEntity> GetByIdTrackingAsync(long id);
        Task<TEntity> GetByIdTrackingAsync(long id, string include);
        Task<TEntity> GetByIdNoIncludeAsync(long id);
        Task<TEntity> GetByIdTrackingNoFilterAsync(long id);
        IQueryable<TEntity> GetAll(string include = "");
        IQueryable<TEntity> GetAllNoInclude();
        Task<TEntity> GetByIdAsync(long id);
    }
}
