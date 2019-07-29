using System.Collections.Generic;
using AdHoc.Shared.Base;
using AdHoc.Shared.Dto.Quizs;
using System;

namespace AdHoc.Shared.Dto.Questions
{
    public class QuestionDTO : BaseDto
    {
        public QuestionDTO()
        {
            Answers = new List<AnswerDTO>();
            QuizQuestions = new List<QuizQuestionDTO>();
        }

        public int TopicId { get; set; }
        public string QuestionString { get; set; }
        public string Hint { get; set; }
        public List<AnswerDTO> Answers { get; set; }
        public List<QuizQuestionDTO> QuizQuestions { get; set; }
    }
}