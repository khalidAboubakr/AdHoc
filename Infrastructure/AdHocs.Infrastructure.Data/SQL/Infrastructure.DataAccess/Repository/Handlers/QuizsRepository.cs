using AdHoc.Shared.Base;
using System;
using System.Data.Entity;
using System.Linq;
using QuizDomain = AdHoc.Core.Domain.Model.Quiz.Quiz;
using LinqKit;
using AdHoc.Core.Domain.Model.Base;
using AdHoc.Core.Domain.Model.Criteria;
using Infrastructure.DataAccess.Repository.Contract;

namespace Infrastructure.DataAccess.Repository.Handlers
{
    public class QuizsRepository : SQLRepository<QuizDomain>, IQuizsRepository
    {
        #region cst.

        public QuizsRepository(DbContext context) : base( context )
        {
        }

        #endregion
        #region publics.
        #region EF
        public SearchResults<QuizDomain> Get(QuizSearchCriteria filters, string includeProperties, bool detached = false)
        {
            #region conditions

            var predicate = PredicateBuilder.New<QuizDomain>(true);

            #region Name
            if (!string.IsNullOrEmpty(filters.Name))
            {
                predicate = predicate.And(x => x.Name.Contains(filters.Name));
            }
            #endregion
            #region Description
            if (!string.IsNullOrEmpty(filters.Description))
            {
                predicate = predicate.And(x => x.Description.Contains(filters.Description));
            }
            #endregion
            #region YearId
            if (filters.YearId != default(int))
            {
                predicate = predicate.And(x => filters.YearId == x.QuarterId);
            }
            #endregion
            #region QuarterId
            if (filters.QuarterId != default(int))
            {
                predicate = predicate.And(x => filters.QuarterId == x.QuarterId);
            }
            #endregion
            #region PassingScore
            if (filters.PassingScore != default(int))
            {
                predicate = predicate.And(x => filters.PassingScore == x.PassingScore);
            }
            #endregion
            #region NumberOfTrials
            if (filters.NumberOfTrials != default(int))
            {
                predicate = predicate.And(x => filters.NumberOfTrials == x.NumberOfTrials);
            }
            #endregion
            #region TopicIds
            if (filters.TopicIds != null && filters.TopicIds.Count() > 0)
            {
                predicate = predicate.And(x => x.QuizQuestions.Any(y=> filters.TopicIds.Contains(y.Question.TopicId)));
            }
            #endregion
            #region QuestionsIds
            if (filters.QuestionsIds != null && filters.QuestionsIds.Count() > 0)
            {
                predicate = predicate.And(x => x.QuizQuestions.Any(y => filters.QuestionsIds.Contains(y.Question.Id)));
            }
            #endregion
            #region DateFrom
            if (filters.DateFrom.HasValue)
            {
                predicate = predicate.And(x => x.CreatedDate == filters.DateFrom);
            }
            #endregion
            #region DateTo
            if (filters.DateTo.HasValue)
            {
                predicate = predicate.And(x => x.CreatedDate == filters.DateTo);
            }
            #endregion
            #endregion

            var query = base.GetQueryable(true, predicate);
            //string sqlQuery = query.ToString();

            #region sorting

            Func<IQueryable<QuizDomain>, IOrderedQueryable<QuizDomain>> orderBy = null;
            bool isDesc = filters.OrderByDirection == SearchCriteria.OrderDirection.Descending;

            if (filters.OrderBy != null)
            {
                switch (filters.OrderBy.Value)
                {
                    case QuizSearchCriteria.OrderByExepression4.Name:
                        {
                            #region order

                            if (isDesc)
                            {
                                orderBy = x => x.OrderByDescending(y => y.Name);
                            }
                            else
                            {
                                orderBy = x => x.OrderBy(y => y.Name);
                            }
                            #endregion
                        }
                        break;
                    case QuizSearchCriteria.OrderByExepression4.Id:
                        {
                            #region order

                            if (isDesc)
                            {
                                orderBy = x => x.OrderByDescending(y => y.Id);
                            }
                            else
                            {
                                orderBy = x => x.OrderBy(y => y.Id);
                            }
                            #endregion
                        }
                        break;
                    case QuizSearchCriteria.OrderByExepression4.YearId:
                        {
                            #region order

                            if (isDesc)
                            {
                                orderBy = x => x.OrderByDescending(y => y.YearId);
                            }
                            else
                            {
                                orderBy = x => x.OrderBy(y => y.YearId);
                            }
                            #endregion
                        }
                        break;
                    case QuizSearchCriteria.OrderByExepression4.QuarterId:
                        {
                            #region order

                            if (isDesc)
                            {
                                orderBy = x => x.OrderByDescending(y => y.QuarterId);
                            }
                            else
                            {
                                orderBy = x => x.OrderBy(y => y.QuarterId);
                            }
                            #endregion
                        }
                        break;
                    case QuizSearchCriteria.OrderByExepression4.PassingScore:
                        {
                            #region order

                            if (isDesc)
                            {
                                orderBy = x => x.OrderByDescending(y => y.PassingScore);
                            }
                            else
                            {
                                orderBy = x => x.OrderBy(y => y.PassingScore);
                            }
                            #endregion
                        }
                        break;
                    case QuizSearchCriteria.OrderByExepression4.NumberOfTrials:
                        {
                            #region order

                            if (isDesc)
                            {
                                orderBy = x => x.OrderByDescending(y => y.NumberOfTrials);
                            }
                            else
                            {
                                orderBy = x => x.OrderBy(y => y.NumberOfTrials);
                            }
                            #endregion
                        }
                        break;
                    default:

                        break;
                }
            }
            else
            {
                orderBy = x => x.OrderByDescending(y => y.CreatedDate);
            }

            #endregion

            #region paging

            var skip = (filters.PageNumber == null ? 0 : (int)filters.PageNumber - 1) * (filters.PageSize == null ? 0 : (int)filters.PageSize);
            var take = filters.PageSize == null ? null : filters.PageSize;

            #endregion

            var queryPaged = base.GetQueryable(true, predicate, orderBy, includeProperties, skip, take);


            var QuizsearchResult = new SearchResults<QuizDomain>();

            QuizsearchResult.Results = queryPaged.ToList();
            QuizsearchResult.TotalCount = query.Count();

            return QuizsearchResult;
        } 
        #endregion
        #endregion
    }
}
