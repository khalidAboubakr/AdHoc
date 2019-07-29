using AdHoc.Core.Component.Contract;
using AdHoc.Core.Domain.Model.Criteria;
using AdHoc.Shared.Base;
using AdHoc.Shared.Utilities;
using System.Collections.Generic;
using TopicDomain = AdHoc.Core.Domain.Model.Topics.Topic;

namespace Infrastructure.DataAccess.Repository.Contract
{
    public interface ITopicsRepository : ISQLRepository<TopicDomain>
    {
        SearchResults<TopicDomain> Get(TopicSearchCriteria filters, string includeProperties, bool detached = false);
        List<SummaryReportResult> GetSumaryReport(TopicSearchCriteria criteria);
    }
}
