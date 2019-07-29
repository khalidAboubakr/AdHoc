using AdHoc.Core.Component.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdHoc.Core.Domain.Contract;

namespace Infrastructure.DataAccess.Repository.Handlers
{
    public class SQLRepositoryRead<TEntity> : SQLRepositoryBase<TEntity>, ISQLRepositoryRead<TEntity> where TEntity : class, IEntity
    {
        #region cst.

        public SQLRepositoryRead(DbContext context) : base(context)
        {
        }

        #endregion

        #region helpers.

        public virtual IQueryable<TEntity> GetQueryable(bool detached, Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null,
            int? skip = null, int? take = null)
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = context.Set<TEntity>();

            // detaching
            if (detached)
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;
                query = query.AsNoTracking();
            }

            if (filter != null) query = query.Where(filter); // filters

            // includes ...
            foreach (var includeProperty in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            // ordering ...
            if (orderBy != null) query = orderBy(query);

            // paging
            if (skip.HasValue && skip != 0) query = query.Skip(skip.Value);
            if (take.HasValue && take != 0) query = query.Take(take.Value);

            // ...
            return query;
        }

        #endregion

        #region publics.

        public virtual IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null, int? skip = null, int? take = null, bool detached = false)
        {
            return GetQueryable(detached, null, orderBy, includeProperties, skip, take).ToList();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null,
            int? skip = null, int? take = null, bool detached = false)
        {
            return GetQueryable(detached, filter, orderBy, includeProperties, skip, take).ToList();
        }

        public virtual TEntity GetOne(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "",
            bool detached = false)
        {
            return GetQueryable(detached, filter, null, includeProperties).SingleOrDefault();
        }

        public virtual TEntity GetFirst(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "",
            bool detached = false)
        {
            return GetQueryable(detached, filter, orderBy, includeProperties).FirstOrDefault();
        }

        public virtual TEntity GetById(object id, bool detached = false, string includeProperties = null)
        {
            return GetQueryable(detached, x => x.Id == id, null, includeProperties).SingleOrDefault();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            return GetQueryable(false, filter).Count();
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> filter = null)
        {
            return GetQueryable(false, filter).Any();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null,
            int? skip = null, int? take = null, bool detached = false)
        {
            return await GetQueryable(detached, null, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null,
            int? skip = null, int? take = null, bool detached = false)
        {
            return await GetQueryable(detached, filter, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public virtual async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null, bool detached = false)
        {
            return await GetQueryable(detached, filter, null, includeProperties).SingleOrDefaultAsync();
        }

        public virtual async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null,
            bool detached = false)
        {
            return await GetQueryable(detached, filter, orderBy, includeProperties).FirstOrDefaultAsync();
        }

        public virtual Task<TEntity> GetByIdAsync(object id, bool detached = false)
        {
            return context.Set<TEntity>().FindAsync(id);
        }

        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return GetQueryable(false, filter).CountAsync();
        }

        public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return GetQueryable(false, filter).AnyAsync();
        }

        #endregion
    }
}