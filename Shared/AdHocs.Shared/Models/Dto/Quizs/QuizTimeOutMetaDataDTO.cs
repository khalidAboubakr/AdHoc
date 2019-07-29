using AdHoc.Shared.Base;
using System;

namespace AdHoc.Shared.Dto.Quizs
{
    
    public class QuizTimeOutMetaDataDTO : BaseDto
    {
        public int QuizId { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public QuizDTO Quiz { get; set; }

    }
}