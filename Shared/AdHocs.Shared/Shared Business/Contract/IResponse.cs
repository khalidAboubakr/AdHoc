using System;
using System.Collections.Generic;
using AdHoc.Core.Domain.Model.Base;
using AdHoc.Shared.Enum;

namespace AdHoc.Shared.Shared_Business.Contract
{
    public interface IResponse
    {
        void Set(ResponseState state, List<MetaPair> detailedMessage, string code, Exception exception);

        #region props.

        List<MetaPair> DetailedMessages { get; set; }
        string Code { get; set; }
        Exception Exception { get; set; }
        ResponseState State { get; set; }

        #endregion
    }
}