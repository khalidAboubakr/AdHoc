using System;
using AdHoc.Core.Component.Contract;
using AdHoc.QuizUnity.Context.Contract;
using AdHoc.Shared.Shared_Business.Contract;

namespace AdHoc.QuizUnity.Context.Services
{
    
    public class LogicContext<T> : IContextStep
    {
        #region props.

        public Func<T> Func { get; set; }

        #endregion

        #region IContextStep

        public IResponse Process(IActionContext context)
        {
            Func();
            return null;
        }

        #endregion

        #region cst.

        public LogicContext()
        {
        }

        public LogicContext(Func<T> func) : this()
        {
            Func = func;
        }

        #endregion
    }
}