using System.Collections.Generic;
using AdHoc.Shared.Base;
using AdHoc.Shared.Dto.Lookups;
using System;

namespace AdHoc.Shared.Dto.Quizs
{
    
    public class QuizDTO : BaseDto
    {
        public QuizDTO()
        {
            EmployeeQuizs = new List<EmployeeQuizDTO>();
            QuizQuestions = new List<QuizQuestionDTO>();
        }

        public string Description { get; set; }

        public int YearId { get; set; }

        public int QuarterId { get; set; }

        public int PassingScore { get; set; }

        public int NumberOfTrials { get; set; }


        public QuartersLookupDto QuartersLookup { get; set; }

        public YearLookupDTO YearLookup { get; set; }

        public QuizExpireMetaDataDTO QuizExpireMetaData { get; set; }

        public QuizTimeOutMetaDataDTO QuizTimeOutMetaData { get; set; }
        public QuizActivatationDTO QuizActivatation { get; set; }

        public List<QuizQuestionDTO> QuizQuestions { get; set; }
        public List<EmployeeQuizDTO> EmployeeQuizs { get; set; }

    }
}