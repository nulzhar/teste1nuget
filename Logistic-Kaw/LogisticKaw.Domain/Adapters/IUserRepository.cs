using LogisticKaw.Domain.Entities;
using System.Collections.Generic;

namespace LogisticKaw.Domain.Adapters
{
    /// <summary>
    /// Repository of User
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Find user on Database
        /// </summary>
        /// <returns></returns>
        User Find(string userName);

        /// <summary>
        /// Get the users from Database
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAll();

        /// <summary>
        /// Register new user on Database
        /// </summary>
        /// <param name="model"></param>
        void Save(User model);
    }
}
