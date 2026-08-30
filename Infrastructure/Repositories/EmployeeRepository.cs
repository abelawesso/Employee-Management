using Employee_API.Models;
using Employee_API.Persistence;
using Employee_API.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee_API.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(AppDbContext dbContext, ILogger<EmployeeRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task AddEmployeAsync(EmployeDtos employe)
        {
            try
            {
                if (employe == null)
                {
                    throw new ArgumentNullException(nameof(employe), "Employe object cannot be null.");
                }
                if (string.IsNullOrWhiteSpace(employe.Matricule))
                {
                    throw new ArgumentException("Matricule cannot be null or empty.", nameof(employe.Matricule));
                }
                if (string.IsNullOrWhiteSpace(employe.Email))
                {
                    throw new ArgumentException("Email cannot be null or empty.", nameof(employe.Email));
                }

                _logger.LogInformation("Adding a new employee with Matricule: {Matricule}", employe.Matricule);

               
                    await _dbContext.Employes.AddAsync(new Employe
                    {
                        Matricule = employe.Matricule,
                        Name = employe.Name,
                        LastName = employe.LastName,
                        Email = employe.Email,
                        DateOfBirth = employe.DateOfBirth,
                        Position = employe.Position,
                        CreatedBy = "System", // You can replace this with the actual user if available
                        CreatedAt = DateTime.UtcNow

                    });
                    await _dbContext.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
             
                _logger.LogError(ex, "An error occurred while adding an employee. Matricule: {Matricule}", employe.Matricule);
                throw;
            }


        }

        public async Task DeleteEmployeAsync(string Matricule)
        {
            var employee = await _dbContext.Employes.FirstOrDefaultAsync(e => e.Matricule == Matricule);
            if (employee == null)
            {
                _logger.LogWarning("Attempted to delete employee with Matricule: {Matricule}, but it was not found.", Matricule);
                throw new KeyNotFoundException($"Employee with Matricule {Matricule} not found.");
            }
            _dbContext.Employes.Remove(employee);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation("Deleted employee with Matricule: {Matricule}", Matricule);
        }

        public async Task<IEnumerable<EmployeDtos>> GetAllAsync()
        {
            return await _dbContext.Employes
                  .Select(e => new EmployeDtos(e.Matricule, e.Name, e.LastName, e.Email, e.DateOfBirth, e.Position))
                  .ToListAsync();

        }

        public async Task<EmployeDtos> GetByIdAsync(string Matricule)
        {
           
            return await _dbContext.Employes.Where(_ => _.Matricule == Matricule)
                .Select(e => new EmployeDtos(e.Matricule, e.Name, e.LastName, e.Email, e.DateOfBirth, e.Position))
                .FirstOrDefaultAsync();
        }

        public async Task UpdateEmployeAsync(EmployeDtos employe)
        {
            var oldEmployee = await _dbContext.Employes.FirstOrDefaultAsync(e => e.Matricule == employe.Matricule);
            if (oldEmployee == null)
            {
                _logger.LogWarning("Attempted to update employee with Matricule: {Matricule}, but it was not found.", employe.Matricule);
                throw new KeyNotFoundException($"Employee with Matricule {employe.Matricule} not found.");
            }
           
                try
                {
                    oldEmployee.Name = employe.Name;
                    oldEmployee.LastName = employe.LastName;
                    oldEmployee.Email = employe.Email;
                    oldEmployee.DateOfBirth = employe.DateOfBirth;
                    oldEmployee.Position = employe.Position;
                    oldEmployee.UpdatedAt = DateTime.UtcNow;
                    oldEmployee.UpdatedBy = "System"; // You can replace this with the actual user if available
                await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
              
                    _logger.LogError(ex, "An error occurred while updating employee with Matricule: {Matricule}", employe.Matricule);
                    throw;
                }
            }   
        }
    }

