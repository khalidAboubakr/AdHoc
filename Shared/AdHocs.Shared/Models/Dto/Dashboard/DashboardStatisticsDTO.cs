using AdHoc.Shared.Base;
using System;

namespace AdHoc.Shared.Models.Dto.Dashboard
{
    
    public class DashboardStatisticsDTO
    {
        public int TopicsCount { get; set; }

        public int QuestionsCount { get; set; }

        public int QuizsCount { get; set; }
    }
}