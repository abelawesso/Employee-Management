using Employee_API.Infrastructure.Repositories;
using Employee_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_API.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        ///   Retrieves all employees from the repository.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return Ok(employees);
        }

        /// <summary>
        ///    Creates a new employee based on the provided employee data.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeDtos employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is null.");
            }
            await _employeeRepository.AddEmployeAsync(employee);
            return CreatedAtAction(nameof(GetAll), new { matricule = employee.Matricule }, employee);
        }

        /// <summary>
        ///     Retrieves an employee based on the provided matricule.
        /// </summary>
        /// <param name="matricule"></param>
        /// <returns></returns>
        [HttpGet("{matricule}")]
        public async Task<IActionResult> GetByMatricule(string matricule)
        {
            var employee = await _employeeRepository.GetByIdAsync(matricule);
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }
            return Ok(employee);
        }

        /// <summary>
        /// Deletes an employee based on the provided matricule.
        /// </summary>
        /// <param name="matricule"></param>
        /// <returns></returns>

        [HttpDelete("{matricule}")]
        public async Task<IActionResult> Delete(string matricule)
        {            
            await _employeeRepository.DeleteEmployeAsync(matricule);
            return NoContent();
        }

        /// <summary>
        /// Updates an existing employee's information based on the provided matricule.
        /// </summary>
        /// <param name="matricule"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut("{matricule}")]
        public async Task<IActionResult> Update(string matricule, [FromBody] EmployeDtos employee)
        {            
           
            await _employeeRepository.UpdateEmployeAsync(employee);
            return NoContent();
        }
    }
}
