using System.Collections.Generic;
using System.Web.Routing;
using AdHoc.QuizUnity.Context.Services;
using AdHoc.Shared.Dto.Questions;
using AdHoc.Core.Domain.Model.Base;
using AdHoc.Shared.Base;
using AdHoc.Shared.Dto.Criteria;

namespace AdHoc.QuizUnity.Services.Questions.Contract
{
    public interface IQuestionHandler
    {
        #region Question

        #region Search

        ExecutionResponse<QuestionDTO> GetQuestion(int id, RequestContext requestContext);
        ExecutionResponse<SearchResults<QuestionDTO>> GetQuestions(QuestionsSearchCriteriaDto criteriadto, RequestContext requestContext);
        ExecutionResponse<int> GetQuestionsCount(RequestContext requestContext);

        #endregion
        #region Actions

        ExecutionResponse<int?> CreateQuestion(QuestionDTO QuestionDto, RequestContext requestContext);
        ExecutionResponse<int?> UpdateQuestion(QuestionDTO Question, RequestContext requestContext);
        ExecutionResponse<bool?> DeleteQuestion(int id, RequestContext requestContext);

        #endregion

        #endregion
        #region Answer

        #region Actions

        ExecutionResponse<int?> CreateAnswer(AnswerDTO AnswerDto, RequestContext requestContext);
        ExecutionResponse<int?> UpdateAnswer(AnswerDTO Answer, RequestContext requestContext);
        ExecutionResponse<bool?> DeleteAnswer(int id, RequestContext requestContext);

        #endregion

        #endregion
    }
}