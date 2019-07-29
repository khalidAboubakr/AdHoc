using AdHoc.QuizUnity.Context.Contract;
using System;
using System.Web.Routing;
using AdHoc.Core.Component.Contract;
using AdHoc.Shared.Shared_Business.Contract;

namespace AdHoc.QuizUnity.Context.Services
{
    
    public class ActionContext : IActionContext
    {
        #region cst ...

        #endregion

        #region props.

        public RequestContext Request { get; set; }
        public IResponse Response { get; set; }

        #endregion
    }
}