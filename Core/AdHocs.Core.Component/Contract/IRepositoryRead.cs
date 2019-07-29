using AdHoc.Core.Component.Contract;
using AdHoc.Core.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdHocs.Core.Component.Contract
{
    public interface IRepositoryRead<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        #region  Search
        #region Get One
        TEntity GetOne(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null, bool detached = false);
        TEntity GetFirst(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, bool detached = false);
        TEntity GetById(object id, bool detached = false, string includeProperties = null);
        Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null, bool detached = false);
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, bool detached = false);
        Task<TEntity> GetByIdAsync(object id, bool detached = false);
        #endregion
        #region Get Many
        IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null, bool detached = false);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null, bool detached = false);
        Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null, bool detached = false);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null, bool detached = false);
        IQueryable<TEntity> GetQueryable(bool detached, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null);

        #endregion
        #endregion
        #region Mics
        int Count(Expression<Func<TEntity, bool>> filter = null);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null);
        bool Any(Expression<Func<TEntity, bool>> filter = null);
        #endregion
    }
}
