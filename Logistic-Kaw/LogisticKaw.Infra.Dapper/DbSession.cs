using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LogisticKaw.Infra.Dapper
{
    public class DbSession : IDisposable
    {
        private readonly IConfiguration _configuration;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession(IConfiguration configuration)
        {
            _configuration = configuration;
            Connection = new SqlConnection(_configuration["Settings:Parameters:ConnectionString"]);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
