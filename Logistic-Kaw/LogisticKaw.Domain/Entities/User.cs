namespace LogisticKaw.Domain.Entities
{
    /// <summary>
    /// Class to map User entity
    /// </summary>
    public class User
    {
        /// <summary>
        /// Unique identification of User on database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Username of User
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password encrypted of User
        /// </summary>
        public string Password { get; set; }
    }
}
