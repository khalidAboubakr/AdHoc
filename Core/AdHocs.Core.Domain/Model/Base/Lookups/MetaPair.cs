namespace AdHoc.Core.Domain.Model.Base
{
    public class MetaPair
    {
        public string Property { get; set; }
        public string Meta { get; set; }

        #region cst.

        public MetaPair()
        {
        }

        public MetaPair(string property, string meta)
        {
            Property = property;
            Meta = meta;
        }

        #endregion
    }
}