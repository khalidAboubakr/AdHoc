using System.Collections.Generic;
using AdHoc.Shared.Base;
using AdHoc.Shared.Dto.Quizs;
using System;

namespace AdHoc.Shared.Dto.Questions
{
    
    public class AnswerDTO : BaseDto
    {
        public AnswerDTO()
        {
            QuizAtemptAnswers = new List<QuizAtemptAnswerDTO>();
        }

        public int QuestionId { get; set; }
        public string AnswerValue { get; set; }
        public bool IsCorrect { get; set; }
        public QuestionDTO Question { get; set; }
        public List<QuizAtemptAnswerDTO> QuizAtemptAnswers { get; set; }
    }
}