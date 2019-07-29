using AdHoc.Core.Domain.Contract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdHocs.Core.Component.Contract
{
    public interface IRepository<TEntity> : IRepositoryRead<TEntity> where TEntity : class, IEntity
    {
        #region Data Flow
        #region Create
        void InsertMany(IEnumerable<TEntity> items, string createdBy = null);
        void InsertOne(TEntity item, string createdBy = null);
        #endregion
        #region Update
        void Update(TEntity entity, string modifiedBy = null);
        #endregion
        #region Delete
        void Delete(object id);
        void Delete(TEntity entity);
        #endregion
        #endregion
        #region Misc
        void CreateIndexText(params string[] fieldNames);
        void CreateIndexAscending(params string[] fieldNames);
        void DropIndexAscending(params string[] fieldNames);
        void DropIndexText(params string[] fieldNames);
        #endregion
    }
}
