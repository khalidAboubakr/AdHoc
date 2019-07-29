using System;
using System.Collections.Generic;
using AdHoc.Core.Domain.Model.Base;
using Equiz.Core.Domain.Model.DataBases;
using Equiz.Core.Domain.Model.DataBases.Structure;

namespace AdHoc.Core.Domain.Model.Employee
{
    [Serializable]
    public class SchemaModel
    {
        #region Ctor
        public SchemaModel()
        {
            Tables = new List<TableModel>();
        }
        #endregion
        #region Props
        public string Name { get; set; }
        public virtual List<TableModel> Tables { get; set; }
        #endregion

    }
}