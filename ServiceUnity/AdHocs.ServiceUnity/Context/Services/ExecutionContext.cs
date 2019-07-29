using System;
using System.Collections.Generic;
using System.Web.Routing;
using AdHoc.Core.Domain.Model.Enum;
using AdHoc.QuizUnity.Context.Contract;
using AdHoc.Shared.Enum;
using AdHoc.Shared.Base;

namespace AdHoc.QuizUnity.Context.Services
{
    public class ExecutionContext<T>
    {
        #region cst.

        #endregion

        #region props.

        public List<IContextStep> Steps { get; set; }
        public RequestContext Request { get; set; }
        public ExecutionResponse<T> Response { get; private set; }
        public ActionContext Action { get; private set; }

        #endregion

        #region publics.

        private ExecutionResponse<T> Process()
        {
            try
            {
                foreach (var step in Steps)
                {
                    var response = step.Process(Action);

                    if (Response.State != ResponseState.Success) return Response;
                    if (response == null) continue;
                    if (response.State != ResponseState.Success)
                    {
                        Response.Set(response);
                        return Response;
                    }
                }

                return Response;
            }
            catch (Exception x)
            {
                Fail(x);
                return Response;
            }
        }

        public virtual ExecutionResponse<T> Process(Func<T> func)
        {
            try
            {
                Initialize(func);
                return Process();
            }
            catch (Exception x)
            {
                Fail(x);
                return Response;
            }
        }

        public virtual ExecutionResponse<T> Process(Func<T> func, ActionContext context)
        {
            try
            {
                Initialize(func, context);
                return Process();
            }
            catch (Exception x)
            {
                Fail(x);
                return Response;
            }
        }

        #endregion

        #region helpers

        private void Initialize(Func<T> func)
        {
            Response = new ExecutionResponse<T> {State = ResponseState.Success};
            Steps = new List<IContextStep>();

            Steps.Add(new LogicContext<T>(func)); // logic
        }

        private void Initialize(Func<T> func, ActionContext context)
        {
            Request = context.Request;
            Response = new ExecutionResponse<T> {State = ResponseState.Success};
            Action = context;
            Action.Response = Response;
            Steps = new List<IContextStep>();
            Steps.Add(new LogicContext<T>(func)); // logic
        }


        private void Fail(Exception x)
        {
            Response.Exception = x;
            Response.State = ResponseState.Error;
        }

        #region cache

        #endregion

        #region mappings

        #endregion

        #region transactions

        #endregion

        #endregion
    }
}