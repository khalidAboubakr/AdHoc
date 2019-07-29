using System.Web.Routing;
using AdHoc.QuizUnity.Context.Services;
using AdHoc.Shared.Dto.Topics;
using AdHoc.Shared.Dto.Criteria;
using AdHoc.Shared.Base;
using System.Collections.Generic;
using AdHoc.Shared.Utilities;

namespace AdHoc.QuizUnity.Services.Topic.Contract
{
    public interface ITopicHandler
    {
        #region Topic

        #region Search

        ExecutionResponse<TopicDTO> GetTopic(int id, RequestContext requestContext);

        ExecutionResponse<SearchResults<TopicDTO>> GetTopics(TopicSearchCriteriaDto criteria,RequestContext requestContext);
        ExecutionResponse<int> GetTopicsCount(RequestContext requestContext);
        #endregion

        #region Actions

        ExecutionResponse<int?> CreateTopic(TopicDTO topicDto, RequestContext requestContext);
        ExecutionResponse<int?> UpdateTopic(TopicDTO topic, RequestContext requestContext);
        ExecutionResponse<bool?> DeleteTopic(int id, RequestContext requestContext);
        ExecutionResponse<List<SummaryReportResult>> GetSummaryReportData(TopicSearchCriteriaDto criteria, RequestContext requestContext);
        #endregion

        #endregion
    }
}