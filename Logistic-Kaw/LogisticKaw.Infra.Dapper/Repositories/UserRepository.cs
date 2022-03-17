using Dapper;
using LogisticKaw.Domain.Adapters;
using LogisticKaw.Domain.Entities;
using System.Collections.Generic;

namespace LogisticKaw.Infra.Dapper.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbSession _session;

        public UserRepository(DbSession session)
        {
            _session = session;
        }

        public User Find(string userName)
        {
            return _session.Connection.QueryFirst<User>($"Select Id, NomeUsuario as UserName, Senha as Password from [Usuario] (NOLOCK) Where NomeUsuario = '{userName}'", null, _session.Transaction);
        }

        public IEnumerable<User> GetAll()
        {
            return _session.Connection.Query<User>("Select Id, NomeUsuario as UserName, Senha as Password from [Usuario] (NOLOCK)", null, _session.Transaction);
        }

        public void Save(User model)
        {
            _session.Connection.Execute($"INSERT INTO [Usuario] VALUES({model.UserName}, {model.Password})", null, _session.Transaction);
        }
    }
}
