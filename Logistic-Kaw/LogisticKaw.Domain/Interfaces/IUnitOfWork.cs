using LogisticKaw.Domain.Adapters;
using System;

namespace LogisticKaw.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        IUserRepository Users { get; }
    }
}
