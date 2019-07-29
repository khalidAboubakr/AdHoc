using CrossCutting.Contract;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EQuiz.Core.Component.Contract.Mongo
{
    /// <summary>
    ///     IRepository definition.
    /// </summary>
    /// <typeparam name="T">The type contained in the repository.</typeparam>
    /// <typeparam name="TKey">The type used for the entity's Id.</typeparam>
    public interface IMongoRepository<T> where T : class, new()
    {
        IMongoQueryable<T> Query { get; set; }
        IPagedList<T> Get(int pageNumber, int pageSize, string sort = "_id", bool ascending = true);

        IPagedList<T> Get(Expression<Func<T, bool>> expression, int pageNumber, int pageSize, string sort = "_id",
            bool ascending = true);

        T GetOne(Expression<Func<T, bool>> expression);
        List<T> Get(Expression<Func<T, bool>> expression, string sortField = "_id", bool ascending = true);

        T FindOneAndUpdate(Expression<Func<T, bool>> expression, UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> option);

        UpdateResult UpdateOne(Expression<Func<T, bool>> expression, UpdateDefinition<T> update);
        UpdateResult Update(Expression<Func<T, bool>> expression, UpdateDefinition<T> update);
        DeleteResult DeleteOne(Expression<Func<T, bool>> expression);
        DeleteResult Delete(Expression<Func<T, bool>> expression);
        void InsertMany(IEnumerable<T> items);
        void InsertOne(T item);
        void CreateIndexText(params string[] fieldNames);
        void CreateIndexAscending(params string[] fieldNames);
        void DropIndexAscending(params string[] fieldNames);
        void DropIndexText(params string[] fieldNames);
    }
}
