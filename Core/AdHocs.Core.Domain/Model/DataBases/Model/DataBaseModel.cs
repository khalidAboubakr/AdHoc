using AdHoc.Core.Domain.Model.Base;
using AdHoc.Core.Domain.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdHocs.Core.Domain.Model.DataBases
{
    [Serializable]
    public class DataBaseModel : BaseEntity<int>
    {
        public string Name { get; set; }
        public SchemaModel Schema { get; set; }

    }
}
