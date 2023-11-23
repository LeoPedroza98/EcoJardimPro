using EcoJardimProject.Data.Context;
using EcoJardimProject.Domain.Base;
using EcoJardimProject.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoJardimProject.Data.RepositoriesBase
{
    public class CrudRepository<TEntity> : QueryRepository<TEntity>, ICrudRepository<TEntity> where TEntity : class, IEntity
    {
        public CrudRepository(EcoJardimProjectContext context) : base(context)
        {

        }

        public async Task Insert(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task Remove(long id)
        {
            var entity = await GetByIdNoIncludeAsync(id);

            if (entity == null)
                throw new NotFoundException("Registro não encontrado");

            _context.Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void Detached(TEntity entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }

        public async Task SaveChangesAsync()
        {

            await _context.SaveChangesAsync();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
