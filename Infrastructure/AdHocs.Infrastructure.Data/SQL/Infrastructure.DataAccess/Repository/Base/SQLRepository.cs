using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using AdHoc.Core.Domain.Contract;
using AdHoc.Core.Component.Contract;

namespace Infrastructure.DataAccess.Repository.Handlers
{
    #region context / entity

    public class SQLRepository<TEntity> : SQLRepositoryRead<TEntity>, ISQLRepository<TEntity> where TEntity : class, IEntity
    {
        #region cst.

        public SQLRepository(DbContext context) : base(context)
        {
        }

        #endregion

        #region helpers.

        protected virtual void ThrowEnhancedValidationException(DbEntityValidationException e)
        {
            var errorMessages = e.EntityValidationErrors
                .SelectMany(x => x.ValidationErrors)
                .Select(x => x.ErrorMessage);

            var fullErrorMessage = string.Join("; ", errorMessages);
            var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);
            throw new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
        }

        #endregion

        #region publics.

        public virtual void Create(TEntity entity, string createdBy = null)
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.CreatedBy = createdBy;

            context.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity, string modifiedBy = null)
        {
            entity.ModifiedDate = DateTime.UtcNow;
            entity.ModifiedBy = modifiedBy;

            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void MarkAs(TEntity entity, string modifiedBy = null)
        {
            entity.ModifiedDate = DateTime.UtcNow;
            entity.ModifiedBy = modifiedBy;
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            var entity = context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            var dbSet = context.Set<TEntity>();
            if (context.Entry(entity).State == EntityState.Detached) dbSet.Attach(entity);

            dbSet.Remove(entity);
        }

        public virtual void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                ThrowEnhancedValidationException(e);
            }
        }

        public virtual Task SaveAsync()
        {
            try
            {
                return context.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                ThrowEnhancedValidationException(e);
            }

            return Task.FromResult(0);
        }

        #endregion
    }

    #endregion
}