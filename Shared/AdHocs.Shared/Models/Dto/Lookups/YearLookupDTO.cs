using System.Collections.Generic;
using AdHoc.Shared.Base;
using AdHoc.Shared.Dto.Quizs;
using System;

namespace AdHoc.Shared.Dto.Lookups
{
    
    public class YearLookupDTO : BaseDto
    {
        public YearLookupDTO()
        {
            Quizs = new List<QuizDTO>();
        }

        public int Value { get; set; }
        public List<QuizDTO> Quizs { get; set; }
    }
}