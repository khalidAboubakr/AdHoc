using System;
using AdHoc.Shared.Base;

namespace AdHoc.Shared.Dto.Quizs
{
    
    public class EmployeeQuizAtemptDTO : BaseDto
    {
        public int QuizId { get; set; }

        public int AttemptNumber { get; set; }

        public DateTime? AttemptDate { get; set; }

        public TimeSpan? AttemptTime { get; set; }

        public bool? IsNotificationRequired { get; set; }

        public AtemptScoreDTO AtemptScore { get; set; }

        public EmployeeQuizDTO EmployeeQuiz { get; set; }
    }
}