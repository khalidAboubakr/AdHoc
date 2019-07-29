using System.Collections.Generic;
using AdHoc.Shared.Base;
using System;

namespace AdHoc.Shared.Dto.Employees
{
    
    public class DepartmentDTO : BaseDto
    {
        public DepartmentDTO()
        {
            DeparmentManagerHistories = new List<DepartmentManagerHistoryDto>();
            Employees = new List<EmployeeDTO>();
        }

        public List<DepartmentManagerHistoryDto> DeparmentManagerHistories { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
    }
}