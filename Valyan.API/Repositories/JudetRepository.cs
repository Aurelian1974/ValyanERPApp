using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Valyan.API.Interfaces;

namespace Valyan.API.Repositories
{ }
public class JudetRepository : IJudetRepository
{
    private readonly IDbConnection _connection;

    public JudetRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<Judet>> GetAllAsync()
    {
        var result = await _connection.QueryAsync<Judet>("Judet_GetAll", commandType: CommandType.StoredProcedure);
        return result.AsList();
    }

    public async Task<bool> ExistsAsync(string codJudet, string nume, int siruta)
    {
        var count = await _connection.ExecuteScalarAsync<int>(
            "Judet_Exists",
            new { CodJudet = codJudet, Nume = nume, Siruta = siruta },
            commandType: CommandType.StoredProcedure);
        return count > 0;
    }

    public async Task AddAsync(Judet judet)
    {
        await _connection.ExecuteAsync(
            "Judet_Insert",
            new { CodJudet = judet.CodJudet, Nume = judet.Nume, Siruta = judet.Siruta },
            commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateAsync(Judet judet)
    {
        await _connection.ExecuteAsync(
            "Judet_Update",
            new { IdJudet = judet.IdJudet, CodJudet = judet.CodJudet, Nume = judet.Nume, Siruta = judet.Siruta },
            commandType: CommandType.StoredProcedure);
    }

    public async Task DeleteAsync(int idJudet)
    {
        await _connection.ExecuteAsync(
            "Judet_Delete",
            new { IdJudet = idJudet },
            commandType: CommandType.StoredProcedure);
    }
}
