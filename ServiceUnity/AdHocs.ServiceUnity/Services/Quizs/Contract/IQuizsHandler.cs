using System.Web.Routing;
using AdHoc.Shared.Dto.Quizs;
using AdHoc.Shared.Dto.Criteria;
using AdHoc.Shared.Base;

namespace AdHoc.QuizUnity.Services.Quiz.Contract
{
    public interface IQuizsHandler
    {
        #region Quiz

        #region Search

        ExecutionResponse<QuizDTO> GetQuiz(int id, RequestContext requestContext);

        ExecutionResponse<SearchResults<QuizDTO>> GetQuizs(QuizSearchCriteriaDto criteria,RequestContext requestContext);
        ExecutionResponse<int> GetQuizsCount(RequestContext requestContext);

        #endregion

        #region Actions

        ExecutionResponse<int?> CreateQuiz(QuizDTO QuizDto, RequestContext requestContext);
        ExecutionResponse<int?> UpdateQuiz(QuizDTO Quiz, RequestContext requestContext);
        ExecutionResponse<bool?> DeleteQuiz(int id, RequestContext requestContext);

        #endregion

        #endregion
    }
}