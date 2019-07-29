using System.Collections.Generic;
using AdHoc.Shared.Base;
using AdHoc.Shared.Dto.Quizs;
using System;

namespace AdHoc.Shared.Dto.Employees
{
    
    public class EmployeeDTO : BaseDto
    {
        public EmployeeDTO()
        {
            DeparmentManagerHistories = new List<DepartmentManagerHistoryDto>();
            EmployeeQuizs = new List<EmployeeQuizDTO>();
        }

        public int DepartmentId { get; set; }
        public List<DepartmentManagerHistoryDto> DeparmentManagerHistories { get; set; }
        public DepartmentDTO Department { get; set; }
        public List<EmployeeQuizDTO> EmployeeQuizs { get; set; }
    }
}