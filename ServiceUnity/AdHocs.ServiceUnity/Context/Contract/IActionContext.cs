using System.Web.Routing;
using AdHoc.Shared.Base;
using AdHoc.Shared.Shared_Business.Contract;

namespace AdHoc.QuizUnity.Context.Contract
{
    public interface IActionContext
    {
        RequestContext Request { get; set; }
        IResponse Response { get; set; }
    }
}