using EcoJardimPro.Domain.Common;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoJardimPro.Services.Common
{
    public interface ICrudService<TEntity> : IQueryService<TEntity> where TEntity : class, IEntity
    {
        Task Post(TEntity entity, bool saveChanges = true);
        Task Post(TEntity entity);
        Task Put(TEntity entity);
        Task Patch(TEntity entity);
        Task Patch(long id, JsonPatchDocument<TEntity> model, string include);
        Task Delete(long id);
        Task Delete(TEntity entity);
        Task SaveChangesAsync();
    }
}
