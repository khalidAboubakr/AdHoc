using AdHoc.Core.Domain.Model.Base;
using System;
using System.Collections.Generic;

namespace AdHoc.Core.Domain.Model.Criteria
{
    public class SchemaSearchCriteria : SearchCriteria
    {
        #region Enums
        public enum OrderByExepression3
        {
            SchemaName = 0,
            DataBaseName = 1
        }
        #endregion
        #region Props.

        public string Name { get; set; }
        public List<string> DataBases { get; set; }
        public OrderByExepression3? OrderBy { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        #endregion
    }
}