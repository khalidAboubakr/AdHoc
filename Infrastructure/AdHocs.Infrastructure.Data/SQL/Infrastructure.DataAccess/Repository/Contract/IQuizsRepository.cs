using AdHoc.Core.Component.Contract;
using AdHoc.Core.Domain.Model.Criteria;
using AdHoc.Shared.Base;
using AdHoc.Shared.Utilities;
using System.Collections.Generic;
using QuizDomain = AdHoc.Core.Domain.Model.Quiz.Quiz;

namespace Infrastructure.DataAccess.Repository.Contract
{
    public interface IQuizsRepository : ISQLRepository<QuizDomain>
    {
        SearchResults<QuizDomain> Get(QuizSearchCriteria filters, string includeProperties, bool detached = false);
    }
}
