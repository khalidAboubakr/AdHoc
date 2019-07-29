using System;
using AdHoc.Core.Domain.Contract;

namespace AdHoc.Core.Domain.Model.Base
{
    public abstract class BaseEntity<T> : IEntity<T>
    {
        #region cst.
        public BaseEntity()
        {
            IsActive = true;
        }
        #endregion

        #region props.

        public T Id { get; set; }

        object IEntity.Id
        {
            get { return Id; }
            set { Id = (T) Convert.ChangeType(value, typeof(T)); }
        }

        public string Name { get; set; }
        public bool IsActive { get; set; } = true;

        private DateTime? createdDate;

        public DateTime? CreatedDate
        {
            get { return createdDate ?? DateTime.UtcNow; }
            set { createdDate = value; }
        }

        public DateTime? ModifiedDate { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        #endregion
    }
}