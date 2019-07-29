using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using AdHoc.Core.Domain.Model.Base;
using AdHoc.Core.Domain.Model.Enum;
using AdHoc.QuizUnity.Context.Services;
using AdHoc.Shared.Dto.Questions;
using AdHoc.Shared.Mapper;
using Infrastructure.DataAccess.DataUnity;
using AdHoc.QuizUnity.Services.Questions.Contract;
using AdHoc.Core.Domain.Model.Questions;
using AdHoc.Shared.Enum;
using AdHoc.Shared.Dto.Criteria;
using AdHoc.Shared.Base;
using AdHoc.Core.Domain.Model.Criteria;
using LinqKit;

namespace AdHoc.QuizUnity.Services.Questions.Handler
{
    public class QuestionHandler : IQuestionHandler
    {
        #region cst.

        public QuestionHandler()
        {
            Initialized = Initialize();
        }

        #endregion
        #region props.

        private bool Initialized { get; }
        private string QuestionIncludesFull { get; set; }
        private string QuestionIncludesBasic { get; set; }
        private string AnswerIncludesFull { get; set; }
        private string AnswerIncludesBasic { get; set; }

        #endregion
        #region IQuestionHandler

        #region Question

        #region Search

        public ExecutionResponse<QuestionDTO> GetQuestion(int id, RequestContext requestContext)
        {
            var context = new ExecutionContext<QuestionDTO>();
            context.Process(() =>
                {
                    #region Logic

                    #region DL

                    using (var dataHandler = new AdHocSQLDataUnity())
                    {
                        var Question = dataHandler.Question.GetById(id);
                        var Questionlist = dataHandler.Question.GetAll(null, null, null, null, true);
                        var QuestionDto = VMapper.Map(Question);
                        return context.Response.Set(ResponseState.Success, QuestionDto);
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

        public ExecutionResponse<SearchResults<QuestionDTO>> GetQuestions(QuestionsSearchCriteriaDto criteriadto, RequestContext requestContext)
        {
            var context = new ExecutionContext<SearchResults<QuestionDTO>>();
            context.Process(() =>
            {
                #region Logic

                if (criteriadto == null) return null;

                #region DL
                var criteria = VMapper.Map(criteriadto);
                using (var dataHandler = new AdHocSQLDataUnity())
                {
                    var result = dataHandler.Question.Get(criteria, QuestionIncludesBasic);
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
        public ExecutionResponse<int> GetQuestionsCount(RequestContext requestContext)
        {
            var context = new ExecutionContext<int>();
            context.Process(() =>
            {
                #region Logic

                #region DL

                using (var dataHandler = new AdHocSQLDataUnity())
                {
                    var result = dataHandler.Question.Count();
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

        public ExecutionResponse<int?> CreateQuestion(QuestionDTO QuestionDto, RequestContext requestContext)
        {
            var context = new ExecutionContext<int?>();
            context.Process(() =>
                {
                    #region Logic

                    #region Map

                    var Question = VMapper.Map(QuestionDto);

                    #endregion

                    #region validate

                    //var validationResult = Validate(Question, ValidationMode.Create);
                    //if (!validationResult.IsValid)
                    //{
                    //    return context.Response.Set(ResponseState.ValidationError, null, validationResult.DetailsMeta);
                    //}

                    #endregion

                    #region data layer

                    using (var dataHandler = new AdHocSQLDataUnity())
                    {
                        // create new user ...
                        dataHandler.Question.Create(Question); // DB
                        dataHandler.Save(); // DB
                    }

                    #endregion

                    #region ...

                    return context.Response.Set(ResponseState.Success, Question.Id);

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
        public ExecutionResponse<int?> UpdateQuestion(QuestionDTO QuestionDto, RequestContext requestContext)
        {
            var context = new ExecutionContext<int?>();
            context.Process(() =>
                {
                    #region Logic

                    #region Map

                    var Question = VMapper.Map(QuestionDto);

                    #endregion

                    #region validate

                    var validationResult = Validate(Question, ValidationMode.Edit);
                    if (!validationResult.IsValid)
                        return context.Response.Set(ResponseState.ValidationError, null, validationResult.DetailsMeta);

                    #endregion

                    #region data layer / authentication provider

                    using (var dataHandler = new AdHocSQLDataUnity())
                    {
                        #region existing.

                        var existingQuestion = dataHandler.Question
                            .Get(x => x.Id == Question.Id, null, QuestionIncludesFull, null, null, true).FirstOrDefault();
                        if (existingQuestion == null) return null;

                        #endregion

                        #region update needed fields

                        existingQuestion = MapForEdit(Question, existingQuestion);

                        #endregion

                        dataHandler.Question.Update(existingQuestion);
                        dataHandler.Save();
                    }

                    #endregion

                    #region ...

                    return context.Response.Set(ResponseState.Success, Question.Id);

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
        public ExecutionResponse<bool?> DeleteQuestion(int id, RequestContext requestContext)
        {
            var context = new ExecutionContext<bool?>();
            context.Process(() =>
            {
                #region Logic

                #region data layer / authentication provider

                using (var dataHandler = new AdHocSQLDataUnity())
                {
                    #region existing.

                    var existingQuestion = dataHandler.Question.Get(x => x.Id == id, null, QuestionIncludesFull, null, null, true).FirstOrDefault();
                    if (existingQuestion == null) return null;

                    #endregion
                    #region validate

                    var validationResult = Validate(existingQuestion, ValidationMode.Delete);
                    if (!validationResult.IsValid)
                        return context.Response.Set(ResponseState.ValidationError, null, validationResult.DetailsMeta);

                    #endregion
                    #region Trans
                    dataHandler.Question.Delete(id);
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
        #region Answer

        #region Action

        public ExecutionResponse<int?> CreateAnswer(AnswerDTO AnswerDto, RequestContext requestContext)
        {
            var context = new ExecutionContext<int?>();
            context.Process(() =>
            {
                #region Logic

                #region Map

                var Answer = VMapper.Map(AnswerDto);

                #endregion

                #region validate

                //var validationResult = Validate(Answer, ValidationMode.Create);
                //if (!validationResult.IsValid)
                //{
                //    return context.Response.Set(ResponseState.ValidationError, null, validationResult.DetailsMeta);
                //}

                #endregion

                #region data layer

                using (var dataHandler = new AdHocSQLDataUnity())
                {
                    // create new user ...
                    dataHandler.Answer.Create(Answer); // DB
                    dataHandler.Save(); // DB
                }

                #endregion

                #region ...

                return context.Response.Set(ResponseState.Success, Answer.Id);

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
        public ExecutionResponse<int?> UpdateAnswer(AnswerDTO AnswerDto, RequestContext requestContext)
        {
            var context = new ExecutionContext<int?>();
            context.Process(() =>
            {
                #region Logic

                #region Map

                var Answer = VMapper.Map(AnswerDto);

                #endregion

                #region validate

                var validationResult = Validate(Answer, ValidationMode.Edit);
                if (!validationResult.IsValid)
                    return context.Response.Set(ResponseState.ValidationError, null, validationResult.DetailsMeta);

                #endregion

                #region data layer / authentication provider

                using (var dataHandler = new AdHocSQLDataUnity())
                {
                    #region existing.

                    var existingAnswer = dataHandler.Answer
                        .Get(x => x.Id == Answer.Id, null, AnswerIncludesFull, null, null, true).FirstOrDefault();
                    if (existingAnswer == null) return null;

                    #endregion

                    #region update needed fields

                    existingAnswer = MapForEdit(Answer, existingAnswer);

                    #endregion

                    dataHandler.Answer.Update(existingAnswer);
                    dataHandler.Save();
                }

                #endregion

                #region ...

                return context.Response.Set(ResponseState.Success, Answer.Id);

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
        public ExecutionResponse<bool?> DeleteAnswer(int id, RequestContext requestContext)
        {
            var context = new ExecutionContext<bool?>();
            context.Process(() =>
            {
                #region Logic

                #region data layer / authentication provider

                using (var dataHandler = new AdHocSQLDataUnity())
                {
                    #region existing.

                    var existingAnswer = dataHandler.Answer.Get(x => x.Id == id, null, AnswerIncludesFull, null, null, true).FirstOrDefault();
                    if (existingAnswer == null) return null;

                    #endregion
                    #region validate

                    var validationResult = Validate(existingAnswer, ValidationMode.Delete);
                    if (!validationResult.IsValid)
                        return context.Response.Set(ResponseState.ValidationError, null, validationResult.DetailsMeta);

                    #endregion
                    #region Trans
                    dataHandler.Answer.Delete(id);
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

                #region Questions

                QuestionIncludesFull = string.Join(",", new List<string>());

                QuestionIncludesBasic = string.Join(",", new List<string>());

                #endregion
                #region Answers

                AnswerIncludesFull = string.Join(",", new List<string>());

                AnswerIncludesBasic = string.Join(",", new List<string>());

                #endregion

                #endregion

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private ValidationResult Validate(Core.Domain.Model.Questions.Question Question, ValidationMode mode)
        {
            Core.Domain.Model.Questions.Question existingQuestion = null;
            var response = new ValidationResult();

            //#region existing ?

            //if (mode == ValidationMode.Edit)
            //{
            //    existingQuestion = this.GetQuestions(new QuestionSearchCriteria() { Id = Question.Id }, SystemRequestContext.Instance).Result.Results.FirstOrDefault();
            //    if (existingQuestion == null)
            //    {
            //        response.IsValid = false;
            //        response.Details.Add("QuestionCode", "QuestionCode does not exist");
            //        return response;
            //    }
            //}

            //#endregion

            #region Name

            if (string.IsNullOrEmpty(Question.QuestionString))
            {
                response.IsValid = false;
                response.Details.Add("Name", "Name can not be empty");
            }

            #endregion

            return response;
        }
        private ValidationResult Validate(Answer answer, ValidationMode mode)
        {
            Answer existinganswer = null;
            var response = new ValidationResult();

            //#region existing ?

            //if (mode == ValidationMode.Edit)
            //{
            //    existingQuestion = this.GetQuestions(new QuestionSearchCriteria() { Id = Question.Id }, SystemRequestContext.Instance).Result.Results.FirstOrDefault();
            //    if (existingQuestion == null)
            //    {
            //        response.IsValid = false;
            //        response.Details.Add("QuestionCode", "QuestionCode does not exist");
            //        return response;
            //    }
            //}

            //#endregion

            #region Name

            if (string.IsNullOrEmpty(answer.Name))
            {
                response.IsValid = false;
                response.Details.Add("Name", "Name can not be empty");
            }

            #endregion

            return response;
        }
        private Question MapForEdit(Core.Domain.Model.Questions.Question newModel, Core.Domain.Model.Questions.Question existingModel)
        {
            newModel.Id = existingModel.Id;
            existingModel.QuestionString = newModel.QuestionString;
            return existingModel;
        }
        private Answer MapForEdit(Answer newModel, Answer existingModel)
        {
            newModel.Id = existingModel.Id;
            existingModel.Name = newModel.Name;
            existingModel.AnswerValue = newModel.AnswerValue;
            existingModel.IsCorrect = newModel.IsCorrect;
            existingModel.QuizAtemptAnswers = null;
            //existingModel.QuizAtemptAnswers = newModel.QuizAtemptAnswers;
            return existingModel;
        }
        private bool IsQuestionNameExists(string username)
        {
            #region DL

            return true;
            //using (var dataHandler = new QuizUnity())
            //{
            //    return dataHandler.Question.Any(x => x.Name == username);
            //}

            #endregion
        }
       
        #endregion
    }
}