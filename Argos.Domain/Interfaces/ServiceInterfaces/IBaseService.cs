using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Argos.Domain.BaseRoot;

namespace Argos.Domain.Interfaces.ServiceInterfaces
{
    public interface  IBaseService<TEntity> where TEntity : Entity
    {
        /*
        Task AddAsync(TEntity obj);
        Task<TEntity> GetByIdAsync(long id);
        Task<List<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity obj);
        Task RemoveAsync(long id);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetOneByAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProperty>> navigationPropertyPath);
        */

        Task<IList<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false);

        Task<TEntity> GetOneByAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false);

        Task<TEntity> GetByIdAsync(
            long id,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void UpdateProperty(TEntity obj, Dictionary<string, dynamic> properties);
    }
}