using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Argos.Domain.BaseRoot;
using Argos.Domain.Interfaces.RepositoryInterfaces;

namespace Argos.Service
{
    public abstract class BaseService<TEntity> where TEntity : Entity
    {
        private readonly IBaseRepository<TEntity> repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        /*
        public virtual async Task<List<TEntity>> GetAllAsync() => await repository.GetAllAsync();

        public virtual async Task AddAsync(TEntity obj)
        {
            try
            {
                await repository.AddAsync(obj);
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<TEntity> GetByIdAsync(long id) => await repository.GetByIdAsync(id);
        
        public virtual async Task UpdateAsync(TEntity obj)
        {
            try
            {
                await repository.UpdateAsync(obj);
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task RemoveAsync(long id)
        {
            try
            {
                await repository.RemoveAsync(id);
            }
            catch
            {
                throw;
            }
        }
        
        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate) => await repository.GetAllAsync(predicate);
        public virtual async Task<TEntity> GetOneByAsync(Expression<Func<TEntity, bool>> predicate) => await repository.GetOneByAsync(predicate);
        public virtual async Task<List<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TProperty>> navigationPropertyPath) => await repository.GetAllAsync(predicate, navigationPropertyPath);
        */

        public virtual async Task<IList<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false)
        {
            return await this.repository.GetAllAsync(predicate, orderBy, include, disableTracking);
        }

        public virtual async Task<TEntity> GetOneByAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false)
        {
            return await this.repository.GetOneByAsync(predicate, include, disableTracking);
        }

        public virtual async Task<TEntity> GetByIdAsync(
            long id,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false)
        {
            return await this.repository.GetByIdAsync(id, include, disableTracking);
        }

        public virtual void Add(TEntity entity)
        {
            entity.CriadoEm = DateTime.Now;
            this.repository.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this.repository.Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            this.repository.Remove(entity);
        }

        public virtual void UpdateProperty(TEntity obj, Dictionary<string, dynamic> properties)
        {
            this.repository.UpdateProperty(obj, properties);
        }
    }
}