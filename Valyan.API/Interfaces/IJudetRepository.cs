using System.Collections.Generic;
using System.Threading.Tasks;
namespace Valyan.API.Interfaces;
public interface IJudetRepository
{
    Task<List<Judet>> GetAllAsync();
    Task<bool> ExistsAsync(string codJudet, string nume, int siruta);
    Task AddAsync(Judet judet);
    Task UpdateAsync(Judet judet);
    Task DeleteAsync(int idJudet);
}