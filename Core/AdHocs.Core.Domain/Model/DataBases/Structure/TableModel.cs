using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equiz.Core.Domain.Model.DataBases.Structure
{
    [Serializable]
    public class TableModel
    {
        #region Ctor
        public TableModel(String dbName, String name, List<ColumnModel> columns, List<ColumnModel> indexColumns)
        {
            DbName = dbName;
            Name = name;
            Columns = columns;
            IndexColumns = indexColumns;
            PrimaryKey = null;
        }

        public TableModel(String dbName, String name, List<ColumnModel> columns, List<ColumnModel> indexColumns, ColumnModel primaryKey)
        {
            DbName = dbName;
            Name = name;
            Columns = columns;
            IndexColumns = indexColumns;
            PrimaryKey = primaryKey;
        }

        #endregion
        #region Props
        public String DbName;
        public String Name;
        public List<ColumnModel> Columns;
        public List<ColumnModel> IndexColumns;
        public ColumnModel PrimaryKey;
        #endregion
    }
}
