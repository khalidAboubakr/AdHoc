using System;
using AdHoc.Shared.Base;

namespace AdHoc.Shared.Dto.Employees
{
    
    public class DepartmentManagerHistoryDto : BaseDto
    {
        public int DeptartmentId { get; set; }

        public int ManagerId { get; set; }

        public DateTime? ModefiedDate { get; set; }

        public int? ModefiedBy { get; set; }

        public bool IsCurentlyManager { get; set; }

        public DepartmentDTO Department { get; set; }

        public EmployeeDTO Employee { get; set; }
    }
}