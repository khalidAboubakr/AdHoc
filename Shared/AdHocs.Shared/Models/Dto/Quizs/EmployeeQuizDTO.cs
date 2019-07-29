using System.Collections.Generic;
using AdHoc.Shared.Base;
using AdHoc.Shared.Dto.Employees;
using System;

namespace AdHoc.Shared.Dto.Quizs
{
    
    public class EmployeeQuizDTO : BaseDto
    {
        public EmployeeQuizDTO()
        {
            EmployeeQuizAtempts = new List<EmployeeQuizAtemptDTO>();
        }

        public int EmployeeId { get; set; }
        public int QuizId { get; set; }
        public EmployeeDTO Employee { get; set; }
        public QuizDTO Quiz { get; set; }
        public List<EmployeeQuizAtemptDTO> EmployeeQuizAtempts { get; set; }
    }
}