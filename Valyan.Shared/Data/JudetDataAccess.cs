using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Valyan.Shared.Data
{
    public static class JudetDataAccess
    {
        public static List<Judet> GetAllJudete(string connectionString)
        {
            using var conn = new SqlConnection(connectionString);
            return conn.Query<Judet>(
                "dbo.GetAllJudete",
                commandType: CommandType.StoredProcedure
            ).AsList();
        }
    }
}