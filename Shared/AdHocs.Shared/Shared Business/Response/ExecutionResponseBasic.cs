using System;
using System.Collections.Generic;
using AdHoc.Core.Domain.Model.Base;
using AdHoc.Shared.Enum;
using AdHoc.Shared.Shared_Business.Contract;

namespace AdHoc.Shared.Base
{
    
    public class ExecutionResponseBasic : IResponse
    {
        #region publics.

        public void Set(ResponseState state, List<MetaPair> detailedMessage, string code, Exception exception)
        {
            State = state;
            DetailedMessages = detailedMessage ?? new List<MetaPair>();
            Code = code;
            Exception = exception;
        }

        #endregion

        #region props.

        public virtual List<MetaPair> DetailedMessages { get; set; }
        public virtual string Code { get; set; }
        public virtual Exception Exception { get; set; }
        public virtual ResponseState State { get; set; }

        #endregion
    }
}