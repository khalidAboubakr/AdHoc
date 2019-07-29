using System;
using System.Collections.Generic;
using AdHoc.Core.Domain.Model.Base;
using AdHoc.Shared.Enum;
using AdHoc.Shared.Shared_Business.Contract;

namespace AdHoc.Shared.Base
{

    
    public class ExecutionResponse<T> : ExecutionResponseBasic
    {
        #region props.

        public T Result { get; set; }

        #endregion

        #region publics.

        public virtual T Set(IResponse source)
        {
            return Set(source.State, default(T), source.DetailedMessages, source.Code, source.Exception);
        }

        public virtual T Set(ExecutionResponse<T> source)
        {
            return Set(source.State, source.Result, source.DetailedMessages, source.Code, source.Exception);
        }

        public bool Set(object responseStatus)
        {
            throw new NotImplementedException();
        }

        public virtual T Set<D>(ExecutionResponse<D> source, T result)
        {
            return Set(source.State, result, source.DetailedMessages, source.Code, source.Exception);
        }

        public virtual T Set(ResponseState state, T result)
        {
            return Set(state, result, new List<MetaPair>());
        }

        public virtual T Set(ResponseState state, T result, List<MetaPair> detailedMessage)
        {
            State = state;
            Result = result;
            DetailedMessages = detailedMessage ?? new List<MetaPair>();

            return Result;
        }

        public virtual T Set(ResponseState state, T result, List<MetaPair> detailedMessage, string code,
            Exception exception)
        {
            Set(state, result, detailedMessage);

            Code = code;
            Exception = exception;

            return Result;
        }

        public void Set(ResponseState state, List<MetaPair> detailedMessage, string code, Exception exception)
        {
            Set(state, default(T), detailedMessage, code, exception);
        }

        #endregion
    }

}