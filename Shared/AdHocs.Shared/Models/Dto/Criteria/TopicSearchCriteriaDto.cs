using AdHoc.Shared.Base;
using System;

namespace AdHoc.Shared.Dto.Criteria
{
    
    public class TopicSearchCriteriaDto : SearchCriteriaDto
    {
        #region Enums
        public enum OrderByExepression1
        {
            Id = 0,
            Name = 1
        }
        #endregion
        #region Props.

        public string Name { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public OrderByExepression1? OrderBy { get; set; }

        #endregion
    }
}
