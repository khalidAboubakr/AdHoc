using AdHoc.Core.Component.Contract;
using AdHoc.Shared.Shared_Business.Contract;

namespace AdHoc.QuizUnity.Context.Contract
{
    public interface IContextStep
    {
        IResponse Process(IActionContext context);
    }
}