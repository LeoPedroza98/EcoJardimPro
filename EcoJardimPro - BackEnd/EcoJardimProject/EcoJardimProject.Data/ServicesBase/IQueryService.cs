using EcoJardimProject.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoJardimProject.Data.ServicesBase
{
    public interface IQueryService<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> Get(long id);
        Task<TEntity> Get(long id, string include);
        Task<TEntity> GetTracking(long id);
        Task<TEntity> GetTracking(long id, string include);
        Task<TEntity> GetTrackingNoFilter(long id);
        IQueryable<TEntity> Get(string include = "");
        IQueryable<TEntity> GetNoInclude();
        Task<TEntity> GetNoInclude(long id);
    }
}
