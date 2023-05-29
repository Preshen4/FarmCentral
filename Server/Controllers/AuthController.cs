using FarmCentral.Server.Data.Repositories.Employee;
using FarmCentral.Server.Data.Repositories.Farmer;
using Microsoft.AspNetCore.Mvc;

namespace FarmCentral.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IFarmerRepository _farmerRepository;

        public AuthController(IEmployeeRepository employeeRepository, IFarmerRepository farmerRepository)
        {
            this._employeeRepository = employeeRepository;
            this._farmerRepository = farmerRepository;
        }

        [HttpGet("{role}" + "/" + "{username}" + "/" + "{password}")]
        public async Task<ActionResult<int>> Login(string role, string username, string password)
        {
            if (role == "Farmer")
            {
                var user = await _farmerRepository.LoginFarmer(username, password);
                if (user.FarmerId <= 0)
                {
                    return NotFound("Wrong Details");
                }
                return Ok(user.FarmerId);
            }
            else if (role == "Employee")
            {
                var user = await _employeeRepository.LoginEmployee(username, password);
                if (user.EmployeeId <= 0)
                {
                    return NotFound("Wrong Details");
                }
                return Ok(user.EmployeeId);
            }
            else
            {
                return BadRequest("Invalid Role");
            }
        }
    }
}
