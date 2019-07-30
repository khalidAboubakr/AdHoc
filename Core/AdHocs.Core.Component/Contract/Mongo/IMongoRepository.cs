using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdHocs.Core.Component.Contract.Mongo
{
    public interface IMongoRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
    }
}
