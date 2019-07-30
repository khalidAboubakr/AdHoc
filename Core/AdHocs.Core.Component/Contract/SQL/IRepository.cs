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
        void Create(TEntity entity, string createdBy = null);
        void Update(TEntity entity, string modifiedBy = null);

        void MarkAs(TEntity entity, string modifiedBy = null);

        void Delete(object id);
        void Delete(TEntity entity);
        void Save();
        Task SaveAsync();
    }
}
