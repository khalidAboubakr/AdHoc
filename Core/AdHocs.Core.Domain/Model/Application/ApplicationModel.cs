using AdHoc.Core.Domain.Model.Base;
using Equiz.Core.Domain.Model.DataBases;
using System;
using System.Collections.Generic;

namespace Equiz.Core.Domain.Model.Application
{
    [Serializable]
    public class ApplicationModel : BaseEntity<int>
    {
        #region Ctor
        public ApplicationModel()
        {
            DataBases = new List<DataBaseModel>();
        }
        #endregion
        #region Props
        public string Portal { get; set; }
        public virtual List<DataBaseModel> DataBases { get; set; }
        #endregion

    }
}
