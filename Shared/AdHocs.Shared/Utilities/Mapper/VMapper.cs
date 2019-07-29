using System;
using System.Collections.Generic;
using AdHoc.Core.Domain.Model.Base;
using AdHoc.Core.Domain.Model.Employee;
using AdHoc.Core.Domain.Model.Lookups;
using AdHoc.Core.Domain.Model.Questions;
using AdHoc.Core.Domain.Model.Quiz;
using AdHoc.Core.Domain.Model.Topics;
using AdHoc.Shared.Dto;
using AdHoc.Shared.Dto.Employees;
using AdHoc.Shared.Dto.Lookups;
using AdHoc.Shared.Dto.Questions;
using AdHoc.Shared.Dto.Quizs;
using AdHoc.Shared.Dto.Topics;
using AdHoc.Shared.Dto.Criteria;
using AdHoc.Core.Domain.Model.Criteria;
using AdHoc.Shared.Base;
using AdHoc.Shared.Models.Dto.Dashboard;

namespace AdHoc.Shared.Mapper
{
    public static class VMapper
    {
        #region Filters

        public static TopicSearchCriteria Map(TopicSearchCriteriaDto from)
        {
            try
            {
                if (from == null) return null;
                var topic = new TopicSearchCriteria();

                topic.Id = from.Id;
                topic.Name = from.Name;
                topic.PagingEnabled = from.PagingEnabled;
                topic.PageSize = from.PageSize;
                topic.PageNumber = from.PageNumber;
                topic.DateFrom = from.DateFrom;
                topic.DateTo = from.DateTo;
                if (from.OrderBy != null)
                {
                    topic.OrderBy = (TopicSearchCriteria.OrderByExepression3)from.OrderBy;
                }
                if (from.OrderByDirection != null)
                {
                    topic.OrderByDirection = (TopicSearchCriteria.OrderDirection)from.OrderByDirection;
                }

                return topic;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DashboardStatisticsDTO Map(int topicsCount, int questionsCount, int quizsCount)
        {
            try
            {
              
                var statistics = new DashboardStatisticsDTO();

                statistics.TopicsCount = topicsCount;
                statistics.QuestionsCount = questionsCount;
                statistics.QuizsCount = quizsCount;
               
                return statistics;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static QuestionsSearchCriteria Map(QuestionsSearchCriteriaDto from)
        {
            try
            {
                if (from == null) return null;
                var topic = new QuestionsSearchCriteria();

                topic.Id = from.Id;
                topic.Name = from.Name;
                topic.TopicId = from.TopicId;
                topic.PagingEnabled = from.PagingEnabled;
                topic.PageSize = from.PageSize;
                topic.PageNumber = from.PageNumber;

                if (from.OrderBy != null)
                {
                    topic.OrderBy = (QuestionsSearchCriteria.OrderByExepression5)from.OrderBy;
                }
                if (from.OrderByDirection != null)
                {
                    topic.OrderByDirection = (QuestionsSearchCriteria.OrderDirection)from.OrderByDirection;
                }

                return topic;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static QuizSearchCriteria Map(QuizSearchCriteriaDto from)
        {
            try
            {
                if (from == null) return null;
                var topic = new QuizSearchCriteria();

                topic.Id = from.Id;
                topic.Name = from.Name;
                topic.PagingEnabled = from.PagingEnabled;
                topic.PageSize = from.PageSize;
                topic.PageNumber = from.PageNumber;
                topic.DateFrom = from.DateFrom;
                topic.DateTo = from.DateTo;
                if (from.OrderBy != null)
                {
                    topic.OrderBy = (QuizSearchCriteria.OrderByExepression4)from.OrderBy;
                }
                if (from.OrderByDirection != null)
                {
                    topic.OrderByDirection = (QuizSearchCriteria.OrderDirection)from.OrderByDirection;
                }
                return topic;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public static AnswersSearchCriteria Map(AnswersSearchCriteriaDto from)
        {
            try
            {
                if (from == null) return null;
                var topic = new AnswersSearchCriteria();

                topic.Id = from.Id;
                topic.Name = from.Name;
                topic.TopicId = from.TopicId;
                topic.QuestionId = from.QuestionId;
                topic.PagingEnabled = from.PagingEnabled;
                topic.PageSize = from.PageSize;
                topic.PageNumber = from.PageNumber;

                if (topic.OrderBy != null)
                {
                    topic.OrderBy = (AnswersSearchCriteria.OrderByExepression6)from.OrderBy;
                }
                if (topic.OrderByDirection != null)
                {
                    topic.OrderByDirection = (AnswersSearchCriteria.OrderDirection)from.OrderByDirection;
                }

                return topic;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region Topic

        public static Topic Map(TopicDTO from)
        {
            try
            {
                if (from == null) return null;
                var topic = new Topic
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    Questions = Map(from.Questions)
                };

                return topic;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static TopicDTO Map(Topic from)
        {
            try
            {
                if (from == null) return null;

                var topic = new TopicDTO();
                topic.Id = from.Id;
                topic.Name = from.Name;
                topic.IsActive = from.IsActive;
                topic.CreatedDate = from.CreatedDate;
                topic.ModifiedDate = from.ModifiedDate;
                topic.CreatedBy = from.CreatedBy;
                topic.ModifiedBy = from.ModifiedBy;
                topic.Questions = Map(from.Questions);

                return topic;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        #endregion

        #region Department

        public static Department Map(DepartmentDTO from)
        {
            try
            {
                if (from == null) return null;
                var to = new Department
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    DeparmentManagerHistories = Map(from.DeparmentManagerHistories),
                    Employees = Map(from.Employees)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DepartmentDTO Map(Department from)
        {
            try
            {
                if (from == null) return null;
                var to = new DepartmentDTO
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    DeparmentManagerHistories = Map(from.DeparmentManagerHistories),
                    Employees = Map(from.Employees)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region Employee

        public static Employee Map(EmployeeDTO from)
        {
            try
            {
                if (from == null) return null;
                var to = new Employee
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    DeparmentManagerHistories = Map(from.DeparmentManagerHistories),
                    DepartmentId = from.DepartmentId,
                    Department = Map(from.Department),
                    EmployeeQuizs = Map(from.EmployeeQuizs)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static EmployeeDTO Map(Employee from)
        {
            try
            {
                if (from == null) return null;
                var to = new EmployeeDTO
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    DeparmentManagerHistories = Map(from.DeparmentManagerHistories),
                    DepartmentId = from.DepartmentId,
                    Department = Map(from.Department),
                    EmployeeQuizs = Map(from.EmployeeQuizs)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region EmployeeQuiz

        public static EmployeeQuiz Map(EmployeeQuizDTO from)
        {
            try
            {
                if (from == null) return null;
                var to = new EmployeeQuiz
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    EmployeeId = from.EmployeeId,
                    QuizId = from.QuizId,
                    Employee = Map(from.Employee),
                    Quiz = Map(from.Quiz),
                    EmployeeQuizAtempts = Map(from.EmployeeQuizAtempts)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static EmployeeQuizDTO Map(EmployeeQuiz from)
        {
            try
            {
                if (from == null) return null;
                var to = new EmployeeQuizDTO
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    EmployeeId = from.EmployeeId,
                    QuizId = from.QuizId,
                    Employee = Map(from.Employee),
                    Quiz = Map(from.Quiz),
                    EmployeeQuizAtempts = Map(from.EmployeeQuizAtempts)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region Quiz

        public static Quiz Map(QuizDTO from)
        {
            try
            {
                if (from == null) return null;
                var to = new Quiz
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    Description = from.ModifiedBy,
                    YearId = from.YearId,
                    QuarterId = from.QuarterId,
                    PassingScore = from.PassingScore,
                    NumberOfTrials = from.NumberOfTrials,
                    EmployeeQuizs = Map(from.EmployeeQuizs),
                    QuartersLookup = Map(from.QuartersLookup),
                    YearLookup = Map(from.YearLookup),
                    QuizActivatation = Map(from.QuizActivatation),
                    QuizExpireMetaData = Map(from.QuizExpireMetaData),
                    QuizTimeOutMetaData = Map(from.QuizTimeOutMetaData),
                    QuizQuestions = Map(from.QuizQuestions)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static QuizDTO Map(Quiz from)
        {
            try
            {
                if (from == null) return null;
                var to = new QuizDTO
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    Description = from.ModifiedBy,
                    YearId = from.YearId,
                    QuarterId = from.QuarterId,
                    PassingScore = from.PassingScore,
                    NumberOfTrials = from.NumberOfTrials,
                    EmployeeQuizs = Map(from.EmployeeQuizs),
                    QuartersLookup = Map(from.QuartersLookup),
                    YearLookup = Map(from.YearLookup),
                    QuizActivatation = Map(from.QuizActivatation),
                    QuizExpireMetaData = Map(from.QuizExpireMetaData),
                    QuizTimeOutMetaData = Map(from.QuizTimeOutMetaData),
                    QuizQuestions = Map(from.QuizQuestions)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }



        #endregion

        #region LookUp

        public static YearLookup Map(YearLookupDTO from)
        {
            try
            {
                if (from == null) return null;
                var to = new YearLookup
                {
                    Id = from.Id,
                    Value = from.Value,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    Quizs = Map(from.Quizs)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static YearLookupDTO Map(YearLookup from)
        {
            try
            {
                if (from == null) return null;
                var to = new YearLookupDTO
                {
                    Id = from.Id,
                    Value = from.Value,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    Quizs = Map(from.Quizs)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static QuartersLookup Map(QuartersLookupDto from)
        {
            try
            {
                if (from == null) return null;
                var to = new QuartersLookup
                {
                    Id = from.Id,
                    Value = from.Value,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    Quizs = Map(from.Quizs)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static QuartersLookupDto Map(QuartersLookup from)
        {
            try
            {
                if (from == null) return null;
                var to = new QuartersLookupDto
                {
                    Id = from.Id,
                    Value = from.Value,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    Quizs = Map(from.Quizs)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region QuizExpireMetaData

        public static QuizExpireMetaData Map(QuizExpireMetaDataDTO from)
        {
            try
            {
                if (from == null) return null;
                var to = new QuizExpireMetaData
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    QuizId = from.QuizId,
                    Date = from.Date,
                    Time = from.Time,
                    TimeSet = from.TimeSet,
                    Quiz = Map(from.Quiz)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static QuizExpireMetaDataDTO Map(QuizExpireMetaData from)
        {
            try
            {
                if (from == null) return null;
                var to = new QuizExpireMetaDataDTO
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    QuizId = from.QuizId,
                    Date = from.Date,
                    Time = from.Time,
                    TimeSet = from.TimeSet,
                    Quiz = Map(from.Quiz)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region QuizTimeOutMetaData

        public static QuizTimeOutMetaData Map(QuizTimeOutMetaDataDTO from)
        {
            try
            {
                if (from == null) return null;
                var to = new QuizTimeOutMetaData
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    QuizId = from.QuizId,
                    Days = from.Days,
                    Hours = from.Hours,
                    Minutes = from.Minutes,
                    Quiz = Map(from.Quiz)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static QuizTimeOutMetaDataDTO Map(QuizTimeOutMetaData from)
        {
            try
            {
                if (from == null) return null;
                var to = new QuizTimeOutMetaDataDTO
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    QuizId = from.QuizId,
                    Days = from.Days,
                    Hours = from.Hours,
                    Minutes = from.Minutes,
                    Quiz = Map(from.Quiz)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region QuizActivatation

        public static QuizActivatation Map(QuizActivatationDTO from)
        {
            try
            {
                if (from == null) return null;
                var to = new QuizActivatation
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    QuizId = from.QuizId,
                    Date = from.Date,
                    Time = from.Time,
                    TimeSet = from.TimeSet,
                    Quiz = Map(from.Quiz)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static QuizActivatationDTO Map(QuizActivatation from)
        {
            try
            {
                if (from == null) return null;
                var to = new QuizActivatationDTO
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    QuizId = from.QuizId,
                    Date = from.Date,
                    Time = from.Time,
                    TimeSet = from.TimeSet,
                    Quiz = Map(from.Quiz)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region DepartmentManagerHistory

        public static DepartmentManagerHistory Map(DepartmentManagerHistoryDto from)
        {
            try
            {
                if (from == null) return null;
                var to = new DepartmentManagerHistory
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    DeptartmentId = from.DeptartmentId,
                    ManagerId = from.ManagerId,
                    IsCurrentlyManager = from.IsCurentlyManager,
                    Department = Map(from.Department),
                    Employee = Map(from.Employee)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DepartmentManagerHistoryDto Map(DepartmentManagerHistory from)
        {
            try
            {
                if (from == null) return null;
                var to = new DepartmentManagerHistoryDto
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    DeptartmentId = from.DeptartmentId,
                    ManagerId = from.ManagerId,
                    IsCurentlyManager = from.IsCurrentlyManager,
                    Department = Map(from.Department),
                    Employee = Map(from.Employee)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region QuizQuestion

        public static QuizQuestion Map(QuizQuestionDTO from)
        {
            try
            {
                if (from == null) return null;
                var to = new QuizQuestion
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    QuizId = from.QuizId,
                    QuestionId = from.QuestionId,
                    IsMandatory = from.IsMandatory,
                    Question = Map(from.Question),
                    // Quiz = Map(from.Quiz)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static QuizQuestionDTO Map(QuizQuestion from)
        {
            try
            {
                if (from == null) return null;
                var to = new QuizQuestionDTO
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    QuizId = from.QuizId,
                    QuestionId = from.QuestionId,
                    IsMandatory = from.IsMandatory,
                    Question = Map(from.Question),
                    // Quiz = Map(from.Quiz)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region Question

        public static Question Map(QuestionDTO from)
        {
            try
            {
                if (from == null) return null;
                var to = new Question
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    TopicId = from.TopicId,
                    QuestionString = from.QuestionString,
                    Hint = from.Hint,
                    Answers = Map(from.Answers),
                    QuizQuestions = Map(from.QuizQuestions)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static QuestionDTO Map(Question from)
        {
            try
            {
                if (from == null) return null;
                var to = new QuestionDTO
                {
                    Id = from.Id,
                    Name = from.QuestionString,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    TopicId = from.TopicId,
                    QuestionString = from.QuestionString,
                    Hint = from.Hint,
                    Answers = Map(from.Answers),
                    QuizQuestions = Map(from.QuizQuestions)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region EmployeeQuizAtempt

        public static EmployeeQuizAtempt Map(EmployeeQuizAtemptDTO from)
        {
            try
            {
                if (from == null) return null;
                var to = new EmployeeQuizAtempt
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    QuizId = from.QuizId,
                    AttemptNumber = from.AttemptNumber,
                    AttemptDate = from.AttemptDate,
                    AttemptTime = from.AttemptTime,
                    IsNotificationRequired = from.IsNotificationRequired,
                    AtemptScore = Map(from.AtemptScore),
                    EmployeeQuiz = Map(from.EmployeeQuiz)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static EmployeeQuizAtemptDTO Map(EmployeeQuizAtempt from)
        {
            try
            {
                if (from == null) return null;
                var to = new EmployeeQuizAtemptDTO
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    QuizId = from.QuizId,
                    AttemptNumber = from.AttemptNumber,
                    AttemptDate = from.AttemptDate,
                    AttemptTime = from.AttemptTime,
                    IsNotificationRequired = from.IsNotificationRequired,
                    AtemptScore = Map(from.AtemptScore),
                    EmployeeQuiz = Map(from.EmployeeQuiz)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region AtemptScore

        public static AtemptScore Map(AtemptScoreDTO from)
        {
            try
            {
                if (from == null) return null;
                var to = new AtemptScore
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    AttemptId = from.AttemptId,
                    Score = from.Score,
                    QuizScore = from.QuizScore,
                    SuccessScore = from.SuccessScore,
                    EmployeeQuizAtempt = Map(from.EmployeeQuizAtempt),
                    QuizAtemptAnswer = Map(from.QuizAtemptAnswer)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static AtemptScoreDTO Map(AtemptScore from)
        {
            try
            {
                if (from == null) return null;
                var to = new AtemptScoreDTO
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    AttemptId = from.AttemptId,
                    Score = from.Score,
                    QuizScore = from.QuizScore,
                    SuccessScore = from.SuccessScore,
                    EmployeeQuizAtempt = Map(from.EmployeeQuizAtempt),
                    QuizAtemptAnswer = Map(from.QuizAtemptAnswer)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region QuizAtemptAnswer

        public static QuizAtemptAnswer Map(QuizAtemptAnswerDTO from)
        {
            try
            {
                if (from == null) return null;
                var to = new QuizAtemptAnswer
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    AttemptId = from.AttemptId,
                    EmployeeAnswer = from.EmployeeAnswer,
                    ExpectedAnswer = from.ExpectedAnswer,
                    Answer = Map(from.Answer),
                    AtemptScore = Map(from.AtemptScore)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static QuizAtemptAnswerDTO Map(QuizAtemptAnswer from)
        {
            try
            {
                if (from == null) return null;
                var to = new QuizAtemptAnswerDTO
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    AttemptId = from.AttemptId,
                    EmployeeAnswer = from.EmployeeAnswer,
                    ExpectedAnswer = from.ExpectedAnswer,
                    Answer = Map(from.Answer),
                    AtemptScore = Map(from.AtemptScore)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region Answer

        public static Answer Map(AnswerDTO from)
        {
            try
            {
                if (from == null) return null;
                var to = new Answer
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    QuestionId = from.QuestionId,
                    AnswerValue = from.AnswerValue,
                    IsCorrect = from.IsCorrect,
                    //  Question = Map(from.Question),
                    QuizAtemptAnswers = Map(from.QuizAtemptAnswers)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static AnswerDTO Map(Answer from)
        {
            try
            {
                if (from == null) return null;
                var to = new AnswerDTO
                {
                    Id = from.Id,
                    Name = from.Name,
                    IsActive = from.IsActive,
                    CreatedDate = from.CreatedDate,
                    ModifiedDate = from.ModifiedDate,
                    CreatedBy = from.CreatedBy,
                    ModifiedBy = from.ModifiedBy,
                    QuestionId = from.QuestionId,
                    AnswerValue = from.AnswerValue,
                    IsCorrect = from.IsCorrect,
                    //  Question = Map(from.Question),
                    QuizAtemptAnswers = Map(from.QuizAtemptAnswers)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region Collection

        public static List<Employee> Map(List<EmployeeDTO> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<Employee>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<EmployeeDTO> Map(List<Employee> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<EmployeeDTO>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<EmployeeQuizDTO> Map(List<EmployeeQuiz> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<EmployeeQuizDTO>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<EmployeeQuiz> Map(List<EmployeeQuizDTO> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<EmployeeQuiz>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<DepartmentManagerHistory> Map(List<DepartmentManagerHistoryDto> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<DepartmentManagerHistory>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<DepartmentManagerHistoryDto> Map(List<DepartmentManagerHistory> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<DepartmentManagerHistoryDto>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<QuizQuestionDTO> Map(List<QuizQuestion> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<QuizQuestionDTO>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<QuizQuestion> Map(List<QuizQuestionDTO> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<QuizQuestion>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<EmployeeQuizAtemptDTO> Map(List<EmployeeQuizAtempt> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<EmployeeQuizAtemptDTO>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<EmployeeQuizAtempt> Map(List<EmployeeQuizAtemptDTO> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<EmployeeQuizAtempt>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Answer> Map(List<AnswerDTO> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<Answer>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<AnswerDTO> Map(List<Answer> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<AnswerDTO>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Quiz> Map(List<QuizDTO> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<Quiz>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<QuizDTO> Map(List<Quiz> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<QuizDTO>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<QuizAtemptAnswer> Map(List<QuizAtemptAnswerDTO> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<QuizAtemptAnswer>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<QuizAtemptAnswerDTO> Map(List<QuizAtemptAnswer> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<QuizAtemptAnswerDTO>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<TopicDTO> Map(List<Topic> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<TopicDTO>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static List<QuestionDTO> Map(ICollection<Question> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<QuestionDTO>();
                foreach (var fromDto in from)
                {
                    to.Add(Map(fromDto));

                }
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static List<Question> Map(List<QuestionDTO> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<Question>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<QuestionDTO> Map(List<Question> from)
        {
            try
            {
                if (from == null) return null;
                var to = new List<QuestionDTO>();
                foreach (var fromDto in from) to.Add(Map(fromDto));
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region SearchResult

        public static SearchResults<TopicDTO> Map(SearchResults<Topic> from)
        {
            try
            {
                if (from.Results == null) return null;
                var to = new SearchResults<TopicDTO>();
                to.Results = Map(from.Results);
                to.PageIndex = from.PageIndex;
                to.TotalCount = from.TotalCount;
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static SearchResults<QuestionDTO> Map(SearchResults<Question> from)
        {
            try
            {
                if (from.Results == null) return null;
                var to = new SearchResults<QuestionDTO>();
                to.Results = Map(from.Results);
                to.PageIndex = from.PageIndex;
                to.TotalCount = from.TotalCount;
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static SearchResults<AnswerDTO> Map(SearchResults<Answer> from)
        {
            try
            {
                if (from.Results == null) return null;
                var to = new SearchResults<AnswerDTO>();
                to.Results = Map(from.Results);
                to.PageIndex = from.PageIndex;
                to.TotalCount = from.TotalCount;
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static SearchResults<QuizDTO> Map(SearchResults<Quiz> from)
        {
            try
            {
                if (from.Results == null) return null;
                var to = new SearchResults<QuizDTO>();
                to.Results = Map(from.Results);
                to.PageIndex = from.PageIndex;
                to.TotalCount = from.TotalCount;
                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}