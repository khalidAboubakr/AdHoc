using System.Collections.Generic;
using Microsoft.Reporting.WebForms;

namespace AdHoc.Shared.Utilities
{
   public class ReportData
    {
        public List<ReportDataSource> reportDataSources { get; set; }
        public List<ReportParameter> reportParamaters { get; set; }
        public string displayName { get; set; }
    }
}
