using System;
using AdHoc.Core.Domain.Contract;

namespace AdHoc.Shared.Base
{
    
    public class BaseDto : IEntityDto<int>
    {
        #region Props
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;

        #region ...
        private DateTime? _createdDate;
        public DateTime? CreatedDate
        {
            get { return _createdDate ?? DateTime.UtcNow; }
            set { _createdDate = value; }
        }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        #endregion 
        #endregion
    }
}  