﻿using EcoJardimPro.DATA.Interface;
using EcoJardimPro.DOMAIN.Interface;
using EcoJardimPro.DOMAIN.Models;
using EcoJardimPro.SERVICE.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace EcoJardimPro.SERVICE.Services
{
    public class QueryService<TEntity, TQueryRepository> : IQueryService<TEntity> where TEntity : class, IEntity where TQueryRepository : IQueryRepository<TEntity>
    {
        protected readonly TQueryRepository _repository;
        public SessionAppModel SessionApp { get; }

        public QueryService(TQueryRepository repository)
        {
            _repository = repository;
            SessionApp = repository.SessionApp;
        }

        public virtual async Task<TEntity> Get(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<TEntity> Get(long id, string include)
        {
            return await _repository.GetByIdAsync(id, include);
        }

        public virtual async Task<TEntity> GetTracking(long id)
        {
            return await _repository.GetByIdTrackingAsync(id);
        }

        public virtual async Task<TEntity> GetTracking(long id, string include)
        {
            return await _repository.GetByIdTrackingAsync(id, include);

        }
        public IQueryable<TEntity> Get(string include = "")
        {
            return _repository.GetAll(include);
        }
        public IQueryable<TEntity> GetNoInclude()
        {
            return _repository.GetAllNoInclude();
        }
        public async Task<TEntity> GetNoInclude(long id)
        {
            return await _repository.GetByIdNoIncludeAsync(id);
        }

        public async Task<TEntity> GetTrackingNoFilter(long id)
        {
            return await _repository.GetByIdTrackingNoFilterAsync(id);
        }
    }
}