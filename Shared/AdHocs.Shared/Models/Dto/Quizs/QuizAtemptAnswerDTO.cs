using AdHoc.Shared.Base;
using AdHoc.Shared.Dto.Questions;
using System;

namespace AdHoc.Shared.Dto.Quizs
{
    
    public class QuizAtemptAnswerDTO : BaseDto
    {
        public int AttemptId { get; set; }
        public int EmployeeAnswer { get; set; }
        public int ExpectedAnswer { get; set; }
        public AnswerDTO Answer { get; set; }
        public AtemptScoreDTO AtemptScore { get; set; }
    }
}