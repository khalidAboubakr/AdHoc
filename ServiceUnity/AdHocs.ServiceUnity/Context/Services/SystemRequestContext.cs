using System;
using System.Web.Routing;
namespace AdHoc.QuizUnity.Context.Services
{
    
    public class SystemRequestContext : RequestContext
    {
        #region cst ...

        private SystemRequestContext()
        {
        }

        #endregion

        #region props ...

        private static readonly object syncRoot = new object();

        private static volatile SystemRequestContext instance;

        public static SystemRequestContext Instance
        {
            get
            {
                if (instance == null)
                    lock (syncRoot)
                    {
                        if (instance == null) instance = new SystemRequestContext();
                    }

                return instance;
            }
        }

        #endregion
    }
}