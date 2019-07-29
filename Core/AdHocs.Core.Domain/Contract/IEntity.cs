using System;

namespace AdHoc.Core.Domain.Contract
{
    public interface IEntity
    {
        object Id { get; set; }
        bool IsActive { get; set; }
        DateTime? CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
    }

    public interface IEntity<T> : IEntity
    {
        new T Id { get; set; }
    }
}