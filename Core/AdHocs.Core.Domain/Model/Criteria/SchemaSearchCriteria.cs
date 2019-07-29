using AdHoc.Core.Domain.Model.Base;
using AdHoc.Core.Domain.Model.Employee;
using System;
using System.Collections.Generic;

namespace AdHoc.Core.Domain.Model.Criteria
{
    public class DataBaseSearchCriteria : SearchCriteria
    {
        #region Enums
        public enum OrderByExepression3
        {
            DataBaseName = 0,
            CreatedDate = 1
        }
        #endregion
        #region Props.

        public string Name { get; set; }
        public SchemaModel DataBases { get; set; }
        public OrderByExepression3? OrderBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        #endregion
    }
}