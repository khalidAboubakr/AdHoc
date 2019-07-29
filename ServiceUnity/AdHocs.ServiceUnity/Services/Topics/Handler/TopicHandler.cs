using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using AdHoc.Core.Domain.Model.Base;
using AdHoc.Core.Domain.Model.Enum;
using AdHoc.QuizUnity.Context.Services;
using AdHoc.QuizUnity.Services.Topic.Contract;
using AdHoc.Shared.Dto.Topics;
using AdHoc.Shared.Mapper;
using Infrastructure.DataAccess.DataUnity;
using TopicDomain = AdHoc.Core.Domain.Model.Topics.Topic;
using AdHoc.Shared.Dto.Criteria;
using AdHoc.Shared.Base;
using AdHoc.Shared.Enum;
using AdHoc.Shared.Utilities;

namespace AdHoc.QuizUnity.Services.Topics.Handler
{
    public class TopicHandler : ITopicHandler
    {
        #region cst.

        public TopicHandler()
        {
            Initialized = Initialize();
        }

        #endregion

        #region props.

        private bool Initialized { get; }
        private string TopicIncludesFull { get; set; }
        private string TopicIncludesBasic { get; set; }

        #endregion

        #region ITopicHandler

        #region Topic

        #region Search

        public ExecutionResponse<TopicDTO> GetTopic(int id, RequestContext requestContext)
        {
            var context = new ExecutionContext<TopicDTO>();
            context.Process(() =>
                {
                    #region Logic

                    #region DL

                    using (var dataHandler = new AdHocSQLDataUnity())
                    {
                        var topic = dataHandler.Topic.GetById(id, true, TopicIncludesFull);
                        var topicDto = VMapper.Map(topic);
                        return context.Response.Set(ResponseState.Success, topicDto);
                    }

                    #endregion

                    #endregion
                }
                #region context

                , new ActionContext
                {
                    Request = requestContext
                    //Validation
                    //Authorization
                    //Auditing
                });
            return context.Response;

            #endregion
        }
        public ExecutionResponse<SearchResults<TopicDTO>> GetTopics(TopicSearchCriteriaDto criteriadto, RequestContext requestContext)
        {
            var context = new ExecutionContext<SearchResults<TopicDTO>>();
            context.Process(() =>
                {
                    #region Logic

                    if (criteriadto == null) return null;

                    #region DL
                    var criteria = VMapper.Map(criteriadto);

                    using (var dataHandler = new AdHocSQLDataUnity())
                    {
                        var result = dataHandler.Topic.Get(criteria, TopicIncludesBasic);
                        return context.Response.Set(ResponseState.Success, VMapper.Map(result));
                    }

                    #endregion

                    #endregion
                }

                #region context

                , new ActionContext
                {
                    Request = requestContext
                    //Validation
                    //Authorization
                    //Auditing
                });
            return context.Response;

            #endregion
        }
        public ExecutionResponse<int> GetTopicsCount(RequestContext requestContext)
        {
            var context = new ExecutionContext<int>();
            context.Process(() =>
            {
                #region Logic

                #region DL
               
                using (var dataHandler = new AdHocSQLDataUnity())
                {
                    var result = dataHandler.Topic.Count();
                    return context.Response.Set(ResponseState.Success,result);
                }

                #endregion

                #endregion
            }

            #region context

                , new ActionContext
                {
                    Request = requestContext
                    //Validation
                    //Authorization
                    //Auditing
                });
            return context.Response;

            #endregion
        }
        public ExecutionResponse<List<SummaryReportResult>> GetSummaryReportData(TopicSearchCriteriaDto criteriadto, RequestContext requestContext)
        {
            var context = new ExecutionContext<List<SummaryReportResult>>();
            context.Process(() =>
            {
                #region Logic

                if (criteriadto == null) return null;

                #region DL
                var criteria = VMapper.Map(criteriadto);

                using (var dataHandler = new AdHocSQLDataUnity())
                {
                    var result = dataHandler.Topic.GetSumaryReport(criteria);
                    return context.Response.Set(ResponseState.Success, result);
                }

                #endregion

                #endregion
            }

            #region context

                , new ActionContext
                {
                    Request = requestContext
                    //Validation
                    //Authorization
                    //Auditing
                });
            return context.Response;

            #endregion
        }

        #endregion

        #region Action

        public ExecutionResponse<int?> CreateTopic(TopicDTO topicDto, RequestContext requestContext)
        {
            var context = new ExecutionContext<int?>();
            context.Process(() =>
                {
                    #region Logic

                    #region Map

                    var topic = VMapper.Map(topicDto);

                    #endregion

                    #region validate

                    //var validationResult = Validate(topic, ValidationMode.Create);
                    //if (!validationResult.IsValid)
                    //{
                    //    return context.Response.Set(ResponseState.ValidationError, null, validationResult.DetailsMeta);
                    //}

                    #endregion

                    #region data layer

                    using (var dataHandler = new AdHocSQLDataUnity())
                    {
                        // create new user ...
                        dataHandler.Topic.Create(topic); // DB
                        dataHandler.Save(); // DB
                    }

                    #endregion

                    #region ...

                    return context.Response.Set(ResponseState.Success, topic.Id);

                    #endregion

                    #endregion
                }
                #region context

                , new ActionContext
                {
                    Request = requestContext
                    //Validation
                    //Authorization
                    //Auditing
                });
            return context.Response;

            #endregion
        }
        public ExecutionResponse<int?> UpdateTopic(TopicDTO topicDto, RequestContext requestContext)
        {
            var context = new ExecutionContext<int?>();
            context.Process(() =>
                {
                    #region Logic

                    #region Map

                    var topic = VMapper.Map(topicDto);

                    #endregion

                    #region validate

                    var validationResult = Validate(topic, ValidationMode.Edit);
                    if (!validationResult.IsValid)
                        return context.Response.Set(ResponseState.ValidationError, null, validationResult.DetailsMeta);

                    #endregion

                    #region data layer / authentication provider

                    using (var dataHandler = new AdHocSQLDataUnity())
                    {
                        #region existing.

                        var existingTopic = dataHandler.Topic
                            .Get(x => x.Id == topic.Id, null, TopicIncludesFull, null, null, true).FirstOrDefault();
                        if (existingTopic == null) return null;

                        #endregion

                        #region update needed fields

                        existingTopic = MapForEdit(topic, existingTopic);

                        #endregion

                        dataHandler.Topic.Update(existingTopic);
                        dataHandler.Save();
                    }

                    #endregion

                    #region ...

                    return context.Response.Set(ResponseState.Success, topic.Id);

                    #endregion

                    #endregion
                }

                #region context

                , new ActionContext
                {
                    Request = requestContext
                    //Validation
                    //Authorization
                    //Auditing
                });
            return context.Response;

            #endregion
        }
        public ExecutionResponse<bool?> DeleteTopic(int id, RequestContext requestContext)
        {
            var context = new ExecutionContext<bool?>();
            context.Process(() =>
                {
                    #region Logic

                    #region data layer / authentication provider

                    using (var dataHandler = new AdHocSQLDataUnity())
                    {
                        #region existing.

                        var existingTopic = dataHandler.Topic.Get(x => x.Id == id, null, TopicIncludesFull, null, null, true).FirstOrDefault();
                        if (existingTopic == null) return null;

                        #endregion
                        #region validate

                        var validationResult = Validate(existingTopic, ValidationMode.Delete);
                        if (!validationResult.IsValid)
                            return context.Response.Set(ResponseState.ValidationError, null, validationResult.DetailsMeta);

                        #endregion
                        #region Trans
                        dataHandler.Topic.Delete(id);
                        dataHandler.Save();
                        #endregion
                    }

                    #endregion

                    #region ...

                    return context.Response.Set(ResponseState.Success, true);

                    #endregion

                    #endregion
                }

                #region context

                , new ActionContext
                {
                    Request = requestContext
                    //Validation
                    //Authorization
                    //Auditing
                });
            return context.Response;

            #endregion
        }


        #endregion

        #endregion

        #endregion

        #region helpers.

        private bool Initialize()
        {
            try
            {
                #region ModelDataIncludes

                #region Topics

                TopicIncludesFull = string.Join(",", new List<string>()
                {
                    "Questions",
                    "Questions.Answers",
                    //"Questions.Topic"
                });

                TopicIncludesBasic = string.Join(",", new List<string>());

                #endregion

                #endregion

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private ValidationResult Validate(TopicDomain Topic, ValidationMode mode)
        {
            TopicDomain existingTopic = null;
            var response = new ValidationResult();

            //#region existing ?

            //if (mode == ValidationMode.Edit)
            //{
            //    existingTopic = this.GetTopics(new TopicSearchCriteria() { Id = Topic.Id }, SystemRequestContext.Instance).Result.Results.FirstOrDefault();
            //    if (existingTopic == null)
            //    {
            //        response.IsValid = false;
            //        response.Details.Add("TopicCode", "TopicCode does not exist");
            //        return response;
            //    }
            //}

            //#endregion

            #region Name

            if (string.IsNullOrEmpty(Topic.Name))
            {
                response.IsValid = false;
                response.Details.Add("Name", "Name can not be empty");
            }

            #endregion

            return response;
        }

        private TopicDomain MapForEdit(TopicDomain newModel, TopicDomain existingModel)
        {
            newModel.Id = existingModel.Id;
            existingModel.Name = newModel.Name;
            return existingModel;
        }

        #endregion
    }
}