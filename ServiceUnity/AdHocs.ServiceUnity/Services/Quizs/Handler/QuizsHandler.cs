using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using AdHoc.Core.Domain.Model.Base;
using AdHoc.Core.Domain.Model.Enum;
using AdHoc.QuizUnity.Context.Services;
using AdHoc.QuizUnity.Services.Quiz.Contract;
using AdHoc.Shared.Dto.Quizs;
using AdHoc.Shared.Mapper;
using Infrastructure.DataAccess.DataUnity;
using AdHoc.Shared.Base;
using AdHoc.Shared.Enum;
using AdHoc.Shared.Utilities;
using AdHoc.Shared.Dto.Criteria;
using QuizDomain = AdHoc.Core.Domain.Model.Quiz.Quiz;

namespace AdHoc.QuizUnity.Services.Quizs.Handler
{
    public class QuizsHandler : IQuizsHandler
    {
        #region cst.

        public QuizsHandler()
        {
            Initialized = Initialize();
        }

        #endregion

        #region props.

        private bool Initialized { get; }
        private string QuizIncludesFull { get; set; }
        private string QuizIncludesBasic { get; set; }

        #endregion

        #region IQuizHandler

        #region Quiz

        #region Search

        public ExecutionResponse<QuizDTO> GetQuiz(int id, RequestContext requestContext)
        {
            var context = new ExecutionContext<QuizDTO>();
            context.Process(() =>
                {
                    #region Logic

                    #region DL

                    using (var dataHandler = new AdHocSQLDataUnity())
                    {
                        var Quiz = dataHandler.Quiz.GetById(id, true, QuizIncludesFull);
                        var QuizDto = VMapper.Map(Quiz);
                        return context.Response.Set(ResponseState.Success, QuizDto);
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
        public ExecutionResponse<SearchResults<QuizDTO>> GetQuizs(QuizSearchCriteriaDto criteriadto, RequestContext requestContext)
        {
            var context = new ExecutionContext<SearchResults<QuizDTO>>();
            context.Process(() =>
                {
                    #region Logic

                    if (criteriadto == null) return null;

                    #region DL
                    var criteria = VMapper.Map(criteriadto);

                    using (var dataHandler = new AdHocSQLDataUnity())
                    {
                        var result = dataHandler.Quiz.Get(criteria, QuizIncludesBasic);
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
        public ExecutionResponse<int> GetQuizsCount(RequestContext requestContext)
        {
            var context = new ExecutionContext<int>();
            context.Process(() =>
            {
                #region Logic

                #region DL

                using (var dataHandler = new AdHocSQLDataUnity())
                {
                    var result = dataHandler.Quiz.Count();
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

        public ExecutionResponse<int?> CreateQuiz(QuizDTO QuizDto, RequestContext requestContext)
        {
            var context = new ExecutionContext<int?>();
            context.Process(() =>
                {
                    #region Logic

                    #region Map

                    var Quiz = VMapper.Map(QuizDto);

                    #endregion

                    #region validate

                    //var validationResult = Validate(Quiz, ValidationMode.Create);
                    //if (!validationResult.IsValid)
                    //{
                    //    return context.Response.Set(ResponseState.ValidationError, null, validationResult.DetailsMeta);
                    //}

                    #endregion

                    #region data layer

                    using (var dataHandler = new AdHocSQLDataUnity())
                    {
                        // create new user ...
                        dataHandler.Quiz.Create(Quiz); // DB
                        dataHandler.Save(); // DB
                    }

                    #endregion

                    #region ...

                    return context.Response.Set(ResponseState.Success, Quiz.Id);

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
        public ExecutionResponse<int?> UpdateQuiz(QuizDTO QuizDto, RequestContext requestContext)
        {
            var context = new ExecutionContext<int?>();
            context.Process(() =>
                {
                    #region Logic

                    #region Map

                    var Quiz = VMapper.Map(QuizDto);

                    #endregion

                    #region validate

                    var validationResult = Validate(Quiz, ValidationMode.Edit);
                    if (!validationResult.IsValid)
                        return context.Response.Set(ResponseState.ValidationError, null, validationResult.DetailsMeta);

                    #endregion

                    #region data layer / authentication provider

                    using (var dataHandler = new AdHocSQLDataUnity())
                    {
                        #region existing.

                        var existingQuiz = dataHandler.Quiz
                            .Get(x => x.Id == Quiz.Id, null, QuizIncludesFull, null, null, true).FirstOrDefault();
                        if (existingQuiz == null) return null;

                        #endregion

                        #region update needed fields

                        existingQuiz = MapForEdit(Quiz, existingQuiz);

                        #endregion

                        dataHandler.Quiz.Update(existingQuiz);
                        dataHandler.Save();
                    }

                    #endregion

                    #region ...

                    return context.Response.Set(ResponseState.Success, Quiz.Id);

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
        public ExecutionResponse<bool?> DeleteQuiz(int id, RequestContext requestContext)
        {
            var context = new ExecutionContext<bool?>();
            context.Process(() =>
                {
                    #region Logic

                    #region data layer / authentication provider

                    using (var dataHandler = new AdHocSQLDataUnity())
                    {
                        #region existing.

                        var existingQuiz = dataHandler.Quiz.Get(x => x.Id == id, null, QuizIncludesFull, null, null, true).FirstOrDefault();
                        if (existingQuiz == null) return null;

                        #endregion
                        #region validate

                        var validationResult = Validate(existingQuiz, ValidationMode.Delete);
                        if (!validationResult.IsValid)
                            return context.Response.Set(ResponseState.ValidationError, null, validationResult.DetailsMeta);

                        #endregion
                        #region Trans
                        dataHandler.Quiz.Delete(id);
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

                #region Quizs

                QuizIncludesFull = string.Join(",", new List<string>()
                {
                    "Questions",
                    "Questions.Answers",
                    //"Questions.Quiz"
                });

                QuizIncludesBasic = string.Join(",", new List<string>());

                #endregion

                #endregion

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private ValidationResult Validate(QuizDomain Quiz, ValidationMode mode)
        {
            QuizDomain existingQuiz = null;
            var response = new ValidationResult();

            //#region existing ?

            //if (mode == ValidationMode.Edit)
            //{
            //    existingQuiz = this.GetQuizs(new QuizSearchCriteria() { Id = Quiz.Id }, SystemRequestContext.Instance).Result.Results.FirstOrDefault();
            //    if (existingQuiz == null)
            //    {
            //        response.IsValid = false;
            //        response.Details.Add("QuizCode", "QuizCode does not exist");
            //        return response;
            //    }
            //}

            //#endregion

            #region Name

            if (string.IsNullOrEmpty(Quiz.Name))
            {
                response.IsValid = false;
                response.Details.Add("Name", "Name can not be empty");
            }

            #endregion

            return response;
        }

        private QuizDomain MapForEdit(QuizDomain newModel, QuizDomain existingModel)
        {
            newModel.Id = existingModel.Id;
            existingModel.Name = newModel.Name;
            return existingModel;
        }

        #endregion
    }
}