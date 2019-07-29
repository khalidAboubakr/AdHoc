using AdHoc.Core.Component.Contract;
using System;
using System.Data.Entity;
using AdHoc.Core.Domain.Contract;

namespace Infrastructure.DataAccess.Repository.Handlers
{
    public abstract class SQLRepositoryBase<TEntity> : ISQLRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        #region cst.

        public SQLRepositoryBase(DbContext context)
        {
            this.context = context;
        }

        #endregion

        #region publics.

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region helpers.

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    context.Dispose();
            disposed = true;
        }

        #endregion

        #region props.

        protected readonly DbContext context;

        private bool disposed;

        #endregion
    }
}