using System.Data;
using System.Data.SqlClient;

namespace Persistence.Context
{
    public class QuestionDbContextDapper 
    {
        private readonly string _connectionString;
        public QuestionDbContextDapper(string connectionString)
        {
            if(connectionString is null)
                throw new ArgumentNullException($"{nameof(connectionString)} can't be null");

            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
