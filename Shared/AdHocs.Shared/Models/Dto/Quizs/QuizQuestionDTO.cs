using AdHoc.Shared.Base;
using AdHoc.Shared.Dto.Questions;
using System;

namespace AdHoc.Shared.Dto.Quizs
{
    
    public class QuizQuestionDTO : BaseDto
    {
        public int QuizId { get; set; }

        public int QuestionId { get; set; }

        public bool? IsMandatory { get; set; }

        public QuestionDTO Question { get; set; }

        public QuizDTO Quiz { get; set; }
    }
}