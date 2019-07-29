using AdHoc.Core.Domain.Model.Criteria;
using AdHoc.Core.Domain.Model.Topics;
using AdHoc.Shared.Base;
using AdHoc.Shared.Dto.Criteria;
using AdHoc.Shared.Dto.Topics;
using Infrastructure.DataAccess.Repository.Contract;
using System;
using System.Data.Entity;
using System.Linq;
using TopicDomain = AdHoc.Core.Domain.Model.Topics.Topic;
using LinqKit;
using AdHoc.Core.Domain.Model.Base;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using AdHoc.Shared.Utilities;

namespace Infrastructure.DataAccess.Repository.Handlers
{
    public class TopicsRepository : SQLRepository<Topic>, ITopicsRepository
    {
        #region cst.

        public TopicsRepository(DbContext context) : base( context )
        {
        }

        #endregion
        #region publics.
        #region EF
        public SearchResults<TopicDomain> Get(TopicSearchCriteria filters, string includeProperties, bool detached = false)
        {
            #region conditions

            var predicate = PredicateBuilder.New<TopicDomain>(true);

            #region Name
            if (!string.IsNullOrEmpty(filters.Name))
            {
                predicate = predicate.And(x => x.Name.Contains(filters.Name));
            }
            #endregion
            #region TopicIds
            if (filters.TopicIds != null && filters.TopicIds.Count > 0)
            {
                predicate = predicate.And(x => filters.TopicIds.Contains(x.Id));
            }
            #endregion

            #endregion

            var query = base.GetQueryable(true, predicate);
            //string sqlQuery = query.ToString();

            #region sorting

            Func<IQueryable<TopicDomain>, IOrderedQueryable<TopicDomain>> orderBy = null;
            bool isDesc = filters.OrderByDirection == SearchCriteria.OrderDirection.Descending;

            if (filters.OrderBy != null)
            {
                switch (filters.OrderBy.Value)
                {
                    case TopicSearchCriteria.OrderByExepression3.Name:
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
                    case TopicSearchCriteria.OrderByExepression3.Id:
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


            var TopicSearchResult = new SearchResults<TopicDomain>();

            TopicSearchResult.Results = queryPaged.ToList();
            TopicSearchResult.TotalCount = query.Count();

            return TopicSearchResult;
        } 
        #endregion
        #region Reports_SP
        public List<SummaryReportResult> GetSumaryReport(TopicSearchCriteria criteria)
        {
            if (criteria == null)
            {
                criteria = new TopicSearchCriteria();
            }

            SqlParameter dateFrom, dateTo;

            #region DateFrom
            if (criteria.DateFrom == null)
            {
                dateFrom = new SqlParameter("@dateFrom", DBNull.Value);
                dateFrom.SqlDbType = SqlDbType.DateTime;
            }
            else
            {
                dateFrom = new SqlParameter("@dateFrom", criteria.DateFrom);
                dateFrom.SqlDbType = SqlDbType.DateTime;
            }
            #endregion
            #region Date To
            if (criteria.DateTo == null)
            {
                dateTo = new SqlParameter("@dateTo", DBNull.Value);
                dateTo.SqlDbType = SqlDbType.DateTime;
            }
            else
            {
                dateTo = new SqlParameter("@dateTo", criteria.DateTo);
                dateTo.SqlDbType = SqlDbType.DateTime;
            }
            #endregion
            
            var SummaryResults = context.Database.SqlQuery<SummaryReportResult>("exec SP_SummaryReport @dateFrom , @dateTo",
                dateFrom, dateTo).ToList();

            return SummaryResults;

        }

        #endregion
        #endregion
    }
}
