﻿using EcoJardimProject.Data.Context;
using EcoJardimProject.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoJardimProject.Data.RepositoriesBase
{
    public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly EcoJardimProjectContext _context;
        protected IQueryable<TEntity> _query;

        public QueryRepository(EcoJardimProjectContext context)
        {
            _context = context;
            _query = _context.Set<TEntity>();
        }

        private IQueryable<TEntity> SetInclude(IQueryable<TEntity> query, string include)
        {
            if (string.IsNullOrEmpty(include))
                return query;

            var includes = include.Split(",");

            foreach (var item in includes)
                query = query.Include(item.Trim());

            return query;
        }

        public virtual IQueryable<TEntity> GetAll(string include = "")
        {
            var query = SetInclude(GetAllNoInclude(), include);

            return string.IsNullOrEmpty(include) ? _query : query;
        }

        public IQueryable<TEntity> GetAllNoInclude()
        {
            return _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetByIdAsync(long id)
        {
            return await _query.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<TEntity> GetByIdAsync(long id, string include)
        {
            var query = SetInclude(GetAllNoInclude(), include);

            return await query.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<TEntity> GetByIdNoIncludeAsync(long id)
        {
            return await _context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<TEntity> GetByIdTrackingAsync(long id)
        {
            return await _query.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<TEntity> GetByIdTrackingAsync(long id, string include)
        {
            var query = SetInclude(GetAllNoInclude(), include);

            return await query.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<TEntity> GetByIdTrackingNoFilterAsync(long id)
        {
            return await _query.IgnoreQueryFilters().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public Task<TEntity> GetByAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
