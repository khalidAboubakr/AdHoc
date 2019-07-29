using System.Collections.Generic;

namespace AdHoc.Core.Domain.Model.Base
{
    public class ValidationResult
    {
        #region cst.

        public ValidationResult()
        {
            IsValid = true;
            Details = new Dictionary<string, string>();
        }

        #endregion

        #region helpers.

        private List<MetaPair> ExtractDetailsMeta()
        {
            if (Details == null) return null;
            var result = new List<MetaPair>();

            foreach (var key in Details.Keys)
                result.Add(new MetaPair
                {
                    Property = key,
                    Meta = Details[key]
                });

            return result;
        }

        #endregion

        #region Props.

        public bool IsValid { get; set; }
        public Dictionary<string, string> Details { get; set; }
        public List<MetaPair> DetailsMeta => ExtractDetailsMeta();

        #endregion
    }
}