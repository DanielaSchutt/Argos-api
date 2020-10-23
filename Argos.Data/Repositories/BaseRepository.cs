using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using System.Reflection;
using Argos.Domain.BaseRoot;


namespace Argos.Data.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(DbContext context)
        {
            this.DbSet = context.Set<TEntity>();
            this.Context = context;
        }

        public virtual async Task<IList<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false)
        {
            return await this.Get(predicate, orderBy, include, disableTracking).ToListAsync();
        }

        public virtual async Task<TEntity> GetOneByAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false)
        {
            return await this.Get(predicate, null, include, disableTracking).FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(long id,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false)
        {
            return await GetOneByAsync(i => i.Id == id, include, disableTracking);
        }

        public virtual void Add(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("Não pode inserir uma entidade nulla");
            DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("Não pode atualizar uma entidade nulla");
            DbSet.Update(entity);
        }

        public virtual void UpdateProperty(TEntity entity, Dictionary<string, dynamic> properties)
        {
            foreach (KeyValuePair<string, dynamic> entry in properties)
            {
                PropertyInfo propertyInfo = entity.GetType().GetProperty(entry.Key);
                propertyInfo.SetValue(entity, entry.Value);
            }

            this.Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("Não pode remover uma entidade nulla");
            DbSet.Remove(entity);
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null,
                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                          bool disableTracking = false)
        {
            IQueryable<TEntity> query = DbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }

        /*

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task AddAsync(TEntity obj)
        {
            try
            {
                Context.Entry(obj).State = EntityState.Added;
                await SaveChangesAsync();
            }
            catch (Exception e)
            {
                //logar e.message
                System.Console.WriteLine(e.Message);
                throw new Exception("Ocorreu um erro interno. Tente novamente após alguns minutos.");
            }
        }

        public virtual async Task<TEntity> GetByIdAsync(long id)
        {
            return await DbSet.SingleOrDefaultAsync(i => i.Id == id);
        }

        public virtual async Task UpdateAsync(TEntity obj)
        {
            try
            {
                Context.Entry(obj).State = EntityState.Modified;
                await SaveChangesAsync();
            }
            catch (Exception e)
            {
                //logar e.message
                System.Console.WriteLine(e.Message);
                throw new Exception("Ocorreu um erro interno. Tente novamente após alguns minutos.");
            }
        }

        public virtual async Task RemoveAsync(long id)
        {
            try
            {
                var obj = await DbSet.SingleOrDefaultAsync(i => i.Id == id);

                if (obj == null)
                {
                    //logar e.message
                    throw new Exception("Id Inválido.");
                }

                DbSet.Remove(obj);
                await SaveChangesAsync();
            }
            catch (Exception e)
            {
                //logar e.message
                System.Console.WriteLine(e.Message);
                throw new Exception("Ocorreu um erro interno. Tente novamente após alguns minutos.");
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            var response = 0;
            using (var transaction = Context.Database.BeginTransaction())
            {
                response = await Context.SaveChangesAsync();
                transaction.Commit();
            }

            return response;
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        {
            return await DbSet.Where(predicate)
                            .Include(navigationPropertyPath)
                            .ToListAsync();
        }

        public virtual async Task<TEntity> GetOneByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.SingleOrDefaultAsync(predicate);
        }

        */
    }
}