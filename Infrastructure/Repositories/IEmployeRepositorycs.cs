using Employee_API.Models;
using Employee_API.Persistence.Entities;

namespace Employee_API.Infrastructure.Repositories
{
    public interface IEmployeRepositorycs
    {
        Task<IEnumerable<EmployeDtos>> GetAll();
        Task<Employe> GetById(string Matricule);
        Task AddEmploye(EmployeDtos employe);
        Task UpdateEmploe(EmployeDtos employe);

    }
}
