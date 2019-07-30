using System;
using Infrastructure.DataAccess.Repository.Handlers;
using Infrastructure.DataAccess.Repository.Contract;
using Infrastructure.EntityFramework.Framework.Data.Context;

namespace Infrastructure.DataAccess.DataUnity
{
    #region UnitOfWork

    public class AdHocSQLDataUnity : IDisposable
    {
        #region publics.

        public void Save()
        {
            context.SaveChanges();
        }

        #endregion

        #region props.

        private readonly DataContext context = new DataContext();

        #region Topic

        private TopicsRepository topic;

        public ITopicsRepository Topic
        {
            get { return topic = topic ?? new TopicsRepository(context); }
        }

        #endregion

        #endregion

        #region IDisposable

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    context.Dispose();
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }

    #endregion
}