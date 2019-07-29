namespace AdHoc.Core.Domain.Model.Base
{
    public abstract class SearchCriteria
    {
        public int Id { get; set; }
        public bool PagingEnabled { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }

        public OrderDirection? OrderByDirection { get; set; }
        
        #region nested

        public enum OrderDirection
        {
            Ascending = 0,
            Descending = 1
        }

        #endregion
    }
}