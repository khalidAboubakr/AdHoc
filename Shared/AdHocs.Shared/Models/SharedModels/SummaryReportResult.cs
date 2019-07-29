using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdHoc.Shared.Utilities
{
    public class SummaryReportResult
    {
        public string Topic { get; set; }
        public string Question { get; set; }
        public int AnswersCount { get; set; }
        public int QuizsCount { get; set; }
        public DateTime? dateFromPar { get; set; }
        public DateTime? dateToPar { get; set; }
    }
}
