using LogisticKaw.Domain.Adapters;
using LogisticKaw.Domain.Interfaces;

namespace LogisticKaw.Infra.Dapper
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbSession _session;

        public IUserRepository Users { get; }

        public UnitOfWork(DbSession session,
            IUserRepository userRepository)
        {
            _session = session;
            Users = userRepository;
        }

        public void BeginTransaction()
        {
            _session.Transaction = _session.Connection.BeginTransaction();
        }

        public void Commit()
        {
            _session.Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _session.Transaction.Rollback();
            Dispose();
        }

        public void Dispose() => _session.Transaction?.Dispose();
    }
}
