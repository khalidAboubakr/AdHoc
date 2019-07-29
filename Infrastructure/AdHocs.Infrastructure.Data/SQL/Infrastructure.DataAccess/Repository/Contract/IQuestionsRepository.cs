using AdHoc.Core.Component.Contract;
using AdHoc.Core.Domain.Model.Criteria;
using AdHoc.Shared.Base;
using QuestionDomain = AdHoc.Core.Domain.Model.Questions.Question;

namespace Infrastructure.DataAccess.Repository.Contract
{
    public interface IQuestionsRepository : ISQLRepository<QuestionDomain>
    {
        SearchResults<QuestionDomain> Get(QuestionsSearchCriteria filters, string includeProperties, bool detached = false);
    }
}
