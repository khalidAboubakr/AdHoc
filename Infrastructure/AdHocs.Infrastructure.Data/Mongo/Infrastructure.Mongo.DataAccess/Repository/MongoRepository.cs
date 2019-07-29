using CrossCutting.Contract;
using AdHocs.Core.Component.Contract.Mongo;
using Infrastructure.Mongo.Context;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CrossCutting.Extention;
using System.Linq;
using MongoDB.Bson;

namespace Infrastructure.Mongo.DataAccess.Repository
{
    public class MongoRepository<T> : IMongoRepository<T>
       where T : class, new()
    {
        protected TasteefContext Context = TasteefContext.GetTasteefContext();

        protected MongoRepository(TasteefContext Context) //TasteefContext context
        {
        }

        public IMongoCollection<T> Collection
        {
            get => Context.Database.GetCollection<T>(typeof(T).Name);
            set => Collection = value;
        }

        public IMongoQueryable<T> Query
        {
            get => Collection.AsQueryable();
            set => Query = value;
        }

        public T GetOne(Expression<Func<T, bool>> expression)
        {
            return Collection.Find(expression).FirstOrDefault();
        }

        public List<T> Get(Expression<Func<T, bool>> expression, string sortField = "_id", bool ascending = true)
        {
            return Collection.Find(expression).Sort(Sort(sortField, ascending)).ToList();
        }

        public IPagedList<T> Get(int pageNumber, int pageSize, string sort = "_id", bool ascending = true)
        {
            throw new NotImplementedException();
        }

        public IPagedList<T> Get(Expression<Func<T, bool>> expression, int pageNumber, int pageSize,
            string sort = "_id", bool ascending = true)
        {
            return Collection.Find(expression).Sort(Sort(sort, ascending)).ToPagedList(pageNumber, pageSize);
        }

        public T FindOneAndUpdate(Expression<Func<T, bool>> expression, UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T> option)
        {
            return Collection.FindOneAndUpdate(expression, update, option);
        }

        public UpdateResult UpdateOne(Expression<Func<T, bool>> expression, UpdateDefinition<T> update)
        {
            return Collection.UpdateOne(expression, update);
        }

        public UpdateResult Update(Expression<Func<T, bool>> expression, UpdateDefinition<T> update)
        {
            return Collection.UpdateMany(expression, update);
        }

        public DeleteResult DeleteOne(Expression<Func<T, bool>> expression)
        {
            return Collection.DeleteOne(expression);
        }

        public DeleteResult Delete(Expression<Func<T, bool>> expression)
        {
            return Collection.DeleteMany(expression);
        }

        public void InsertMany(IEnumerable<T> items)
        {
            Collection.InsertMany(items);
        }

        public void InsertOne(T item)
        {
            Collection.InsertOne(item);
        }

        public void CreateIndexAscending(params string[] fieldNames)
        {
            foreach (var field in fieldNames)
            {
                var index = Builders<T>.IndexKeys.Ascending(field);

                Collection.Indexes.CreateOne(new CreateIndexModel<T>(index));
            }
        }

        public void DropIndexAscending(params string[] fieldNames)
        {
            foreach (var field in fieldNames)
            {
                var Indexes = Collection.Indexes.List().ToList();
                if (Indexes.Count > 0 && Indexes.Any(x => x["name"] == field + "_1"))
                    Collection.Indexes.DropOne(field + "_1");
            }
        }

        public void DropIndexText(params string[] fieldNames)
        {
            foreach (var field in fieldNames)
            {
                var Indexes = Collection.Indexes.List().ToList();
                if (Indexes.Count > 0 && Indexes.Any(x => x["name"] == field + "_text"))
                    Collection.Indexes.DropOne(field + "_text");
            }
        }

        public void CreateIndexText(params string[] fieldNames)
        {
            foreach (var field in fieldNames)
            {
                var index = Builders<T>.IndexKeys.Text(field);

                Collection.Indexes.CreateOne(new CreateIndexModel<T>(index));
            }
        }

        public UpdateResult Update(Dictionary<FilterTypes, KeyValuePair<string, string>> filters,
            UpdateDefinition<T> update)
        {
            return Collection.UpdateMany(Filter(filters), update);
            var s = new BsonDocument
            {
                {"", 22},
                {"ss", DateTime.Now}
            };
        }

        private SortDefinition<T> Sort(string sort = "_id", bool ascending = true)
        {
            if (ascending)
                return Builders<T>.Sort.Ascending(sort);
            return Builders<T>.Sort.Descending(sort);
        }

        private FilterDefinition<T> Filter(Dictionary<FilterTypes, KeyValuePair<string, string>> filters)
        {
            var filter = Builders<T>.Filter.Empty;
            foreach (var item in filters) filter = filter & FilterType(item.Key, item.Value.Key, item.Value.Value);

            return Builders<T>.Filter.Eq("", ""); //.Eq(filters.First().Key, filters.First().Value.Value);
        }

        private FilterDefinition<T> FilterType(FilterTypes type, string key, string value)
        {
            switch (type)
            {
                case FilterTypes.Eq:
                    return Builders<T>.Filter.Eq(key, value);
                case FilterTypes.GTE:
                    return Builders<T>.Filter.Gte(key, value);
                case FilterTypes.LTE:
                    return Builders<T>.Filter.Lte(key, value);
                case FilterTypes.Lt:
                    return Builders<T>.Filter.Lt(key, value);
                case FilterTypes.GT:
                    return Builders<T>.Filter.Gt(key, value);
                default:
                    return Builders<T>.Filter.Empty;
            }
        }
    }

    public enum FilterTypes
    {
        Eq = 1,
        GTE = 2,
        LTE = 3,
        Lt = 4,
        GT = 5
    }
}
