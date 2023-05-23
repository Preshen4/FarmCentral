using FarmCentral.Server.Data.Repositories.Employee;
using FarmCentral.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FarmCentral.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            var employees = await _employeeRepository.GetEmployees();
            return Ok(employees);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var employee = await _employeeRepository.GetEmployee(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return BadRequest();
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Employee employee)
        {
            await _employeeRepository.AddEmployee(employee);
            return Ok("Employee Created");
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public async Task<ActionResult> Put(Employee employee)
        {
            await _employeeRepository.UpdateEmployee(employee);
            return Ok("Employee Updated");
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int employeeId)
        {
            await _employeeRepository.DeleteEmployee(employeeId);
            return Ok("Employee has been deleted");
        }
    }
}
