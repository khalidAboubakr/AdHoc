using AdHoc.Shared.Base;
using AdHoc.Shared.Dto.Questions;
using System;
using System.Collections.Generic;

namespace AdHoc.Shared.Dto.Topics
{
    
    public class TopicDTO : BaseDto
    {
        public TopicDTO()
        {
            Questions = new List<QuestionDTO>();
        }
        public List<QuestionDTO> Questions { get; set; }
    }
}