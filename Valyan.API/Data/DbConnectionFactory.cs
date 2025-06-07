using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient; // Update the namespace to use Microsoft.Data.SqlClient instead of System.Data.SqlClientdotnet add package Microsoft.Data.SqlClient

namespace Valyan.API.Data
{
    public class DbConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connectionString);
        }
    }
}