using Employee_API.Models;
using Employee_API.Persistence.Entities;

namespace Employee_API.Infrastructure.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeDtos>> GetAllAsync();
        Task<EmployeDtos> GetByIdAsync(string Matricule);
        Task AddEmployeAsync(EmployeDtos employe);
        Task UpdateEmployeAsync(EmployeDtos employe);
        Task DeleteEmployeAsync (string Matricule);

    }
}
