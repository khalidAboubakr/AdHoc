using System;
using System.Collections.Generic;

namespace AdHoc.Shared.Base
{
    
    public class SearchResults<T> where T : class
    {
        #region props.

        public List<T> Results { get; set; }
        public int PageIndex { get; set; }
        public int TotalCount { get; set; }

        #endregion

        #region cst.

        public SearchResults()
        {
        }

        public SearchResults(List<T> results) : this()
        {
            Results = results;
        }

        #endregion
    }
}