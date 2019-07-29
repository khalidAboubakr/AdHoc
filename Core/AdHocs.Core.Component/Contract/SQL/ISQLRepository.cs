using System;
using System.Threading.Tasks;
using AdHoc.Core.Domain.Contract;

namespace AdHoc.Core.Component.Contract
{
    public interface ISQLRepository<TEntity> : ISQLRepositoryRead<TEntity> where TEntity : class, IEntity
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