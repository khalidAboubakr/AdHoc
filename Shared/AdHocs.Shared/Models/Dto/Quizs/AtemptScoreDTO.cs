using AdHoc.Shared.Base;
using System;

namespace AdHoc.Shared.Dto.Quizs
{
    
    public class AtemptScoreDTO : BaseDto
    {
        public int AttemptId { get; set; }

        public int Score { get; set; }

        public int QuizScore { get; set; }

        public int SuccessScore { get; set; }

        public EmployeeQuizAtemptDTO EmployeeQuizAtempt { get; set; }

        public QuizAtemptAnswerDTO QuizAtemptAnswer { get; set; }
    }
}