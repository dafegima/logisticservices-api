using System.Data.SqlClient;
using Dapper;

namespace LogisticService.Infrastructure.SQL.Repositories
{
    public class Base
    {
        private readonly string _connectionString;
        public Base(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<TResponse> Query<TResponse> (string query, object param = null) 
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var results = connection.Query<TResponse>(query, param).ToList();
                return results;
            }
        }

        public void Execute(string query, object param = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, param);
            }
        }
    }
}