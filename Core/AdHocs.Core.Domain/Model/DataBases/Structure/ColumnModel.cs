using Equiz.Core.Domain.Model.DataBases.Enums;
using Equiz.Core.Domain.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equiz.Core.Domain.Model.DataBases.Structure
{
    [Serializable]
    public class ColumnModel
    {
        #region Ctor

        public ColumnModel(DataTypeModel type, String name, int length)
        {
            Type = type;
            Name = name;
            if (type == DataTypeModel.Int)
                Length = Constants.IntStringLen;
            else if (type == DataTypeModel.Double)
                Length = Constants.DoubleStringLen;
            else if (type == DataTypeModel.Char)
                Length = length;
        }

        public ColumnModel(String type, String name, String length)
        {
            Name = name;
            if (int.TryParse(length, out Length) == false)
                Length = Constants.DefaultLen;

            if (type == "char")
                Type = DataTypeModel.Char;
            else if (type == "int")
                Type = DataTypeModel.Int;
            else if (type == "double")
                Type = DataTypeModel.Double;
            else
                throw new Exception("Data Type not supported");
        }

        #endregion
        #region Props
        public DataTypeModel Type;
        public String Name;
        public int Length;
        #endregion
        #region Helpers
        public override bool Equals(object obj)
        {
            ColumnModel col = (ColumnModel)obj;
            if (Type != col.Type)
                return false;
            if (!Name.Equals(col.Name))
                return false;
            if (Length != col.Length)
                return false;
            return true;
        } 
        #endregion
    }
}
