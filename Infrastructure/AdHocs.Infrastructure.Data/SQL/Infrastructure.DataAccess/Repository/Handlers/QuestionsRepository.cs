using AdHoc.Core.Domain.Model.Criteria;
using AdHoc.Core.Domain.Model.Topics;
using AdHoc.Shared.Base;
using AdHoc.Shared.Dto.Criteria;
using AdHoc.Shared.Dto.Topics;
using Infrastructure.DataAccess.Repository.Contract;
using System;
using System.Data.Entity;
using System.Linq;
using LinqKit;
using AdHoc.Core.Domain.Model.Base;
using QuestionDomain = AdHoc.Core.Domain.Model.Questions.Question;

namespace Infrastructure.DataAccess.Repository.Handlers
{
    public class QuestionsRepository : SQLRepository<QuestionDomain>, IQuestionsRepository
    {
        #region cst.

        public QuestionsRepository(DbContext context) : base( context )
        {
        }

        #endregion
        #region publics.
        public SearchResults<QuestionDomain> Get(QuestionsSearchCriteria filters, string includeProperties, bool detached = false)
        {
            #region conditions

            var predicate = PredicateBuilder.New<QuestionDomain>(true);
            
            #region Name
            if (filters.Name != null)
            {
                predicate = predicate.And(x => x.QuestionString.Contains(filters.Name));
            }
            #endregion
            #region Id
            if (filters.Id != default(int))
            {
                predicate = predicate.And(x => x.Id == filters.Id);
            }
            #endregion
            #region TopicId
            if (filters.TopicId != default(int))
            {
                predicate = predicate.And(x => x.TopicId == filters.TopicId);
            }
            #endregion


            #endregion

            var query = base.GetQueryable(true, predicate);
            //string sqlQuery = query.ToString();

            #region sorting

            Func<IQueryable<QuestionDomain>, IOrderedQueryable<QuestionDomain>> orderBy = null;
            bool isDesc = filters.OrderByDirection == SearchCriteria.OrderDirection.Descending;

            if (filters.OrderBy != null)
            {
                switch (filters.OrderBy.Value)
                {
                    case QuestionsSearchCriteria.OrderByExepression5.Name:
                        {
                            #region order

                            if (isDesc)
                            {
                                orderBy = x => x.OrderByDescending(y => y.QuestionString);
                            }
                            else
                            {
                                orderBy = x => x.OrderBy(y => y.QuestionString);
                            }
                            #endregion
                        }
                        break;
                    case QuestionsSearchCriteria.OrderByExepression5.Id:
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
                    case QuestionsSearchCriteria.OrderByExepression5.TopicId:
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


            var QuestionsSearchResult = new SearchResults<QuestionDomain>();

            QuestionsSearchResult.Results = queryPaged.ToList();
            QuestionsSearchResult.TotalCount = query.Count();

            return QuestionsSearchResult;
        }

        #endregion
    }
}
