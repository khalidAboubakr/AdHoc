using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Mvc;
using AdHoc.Shared.Base;
using AdHoc.Shared.Enum;
using AdHoc.Core.Domain.Model.Base;
using AdHoc.QuizUnity.Configuration;
using AdHoc.Shared.Mapper;
using AdHoc.Shared.Models.Dto.Dashboard;
using AdHoc.Shared.Dto.Criteria;

namespace AdHoc.SharedApi.Base
{
    public class BaseController : ApiController
    {
        #region Props
        protected RequestContext _ServiceRequestContext = new System.Web.Routing.RequestContext();

        #region Publics
        [System.Web.Http.Route("api/Base/GetStatistics")]
        public JsonResult GetStatistics()
        {
            try
            {
                #region BL
                var TopicsCount = QuizBusinessUnity.Topics.GetTopicsCount(_ServiceRequestContext).Result;
                var QuestionsCount = QuizBusinessUnity.Questions.GetQuestionsCount(_ServiceRequestContext).Result;
                var QuizsCount = QuizBusinessUnity.Quizs.GetQuizsCount(_ServiceRequestContext).Result;
                var response = VMapper.Map(TopicsCount, QuestionsCount, QuizsCount);

                #endregion
                #region reponse.
                return new JsonResponse<DashboardStatisticsDTO>()
                {
                    Data = response,
                    Success = true,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                #endregion

            }
            catch (Exception e)
            {
                return returnExeptionresponse(e);
            }
        }
        [System.Web.Http.Route("api/Base/GetLatestTopics")]
        public JsonResult GetLatestTopics()
        {
            try
            {
                #region Filters
                var filter = new TopicSearchCriteriaDto();
                filter.PageSize = 8;
                #endregion
                #region BL
                var response = QuizBusinessUnity.Topics.GetTopics(filter,_ServiceRequestContext);
                #endregion
                #region reponse.

                return HandleAjaxResponse(response);

                #endregion
            }
            catch (Exception e)
            {
                return returnExeptionresponse(e);
            }
        }
        
        #endregion
        #endregion
        #region   #region Response
        protected JsonResult HandleAjaxResponse<T>(ExecutionResponse<T> response)
        {
            string script = "";

            switch (response.State)
            {
                case ResponseState.Success:
                case ResponseState.Redirect:
                    {
                        return GetJsonResponse(true, response.Result);
                    }
                case ResponseState.AuthenticationError:
                case ResponseState.AccessDenied:
                    {
                        return GetJsonResponse(false, "Access Denied");
                    }
                default:
                    {
                        return GetJsonResponse(false, "System Error");
                    }
            }
        }
        protected JsonResult GetJsonResponse<T>(bool state, T message)
        {
            return new JsonResponse<T>
            {
                Data = message,
                Success = state,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            // return Json(new JsonResponse<T> { Success = state, data = message,JsonRequestBehavior = JsonRequestBehavior.AllowGet });
        }
        public JsonResult returnExeptionresponse(Exception e)
        {
            try
            {
                return new JsonResponse<string> { Data = e.Message, Success = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                return ReturnError();
            }
        }
        protected JsonResult ReturnError()
        {
            return GetJsonResponse(false, "System Error");
        }
        #endregion

    }
}
