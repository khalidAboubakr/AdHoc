using System;
using System.Threading.Tasks;

namespace AdHocs.Core.Component.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
