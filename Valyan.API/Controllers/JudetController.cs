using System.Collections.Generic;
using System.Threading.Tasks;
using Valyan.API.Interfaces;
//using Valyan.Shared.Models;

namespace Valyan.API.Controllers
{
    public class JudetController
    {
        private readonly IJudetRepository _repo;

        public JudetController(IJudetRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Judet>> GetAllAsync() => _repo.GetAllAsync();
        public Task<bool> ExistsAsync(string cod, string nume, int siruta) => _repo.ExistsAsync(cod, nume, siruta);
        public Task AddAsync(Judet j) => _repo.AddAsync(j);
        public Task UpdateAsync(Judet j) => _repo.UpdateAsync(j);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}