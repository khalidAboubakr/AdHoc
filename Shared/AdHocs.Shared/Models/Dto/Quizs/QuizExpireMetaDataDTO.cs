using System;
using AdHoc.Shared.Base;

namespace AdHoc.Shared.Dto.Quizs
{
    
    public class QuizExpireMetaDataDTO : BaseDto
    {
        public int QuizId { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public int TimeSet { get; set; }

        public QuizDTO Quiz { get; set; }

    }
}