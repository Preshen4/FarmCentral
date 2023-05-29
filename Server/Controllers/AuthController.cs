using FarmCentral.Server.Data.Repositories.Employee;
using FarmCentral.Server.Data.Repositories.Farmer;
using FarmCentral.Shared;
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

        [HttpGet("{role}")]
        public async Task<ActionResult<string>> Login(string role)
        {
            UserLoginDto _userLoginDto = UserLoginDto.Instance;

            if (role == "Farmer")
            {
                var user = await _farmerRepository.LoginFarmer(_userLoginDto.Username, _userLoginDto.Password);
                if (user.FarmerId <= 0)
                {
                    return NotFound("Wrong Details");
                }
                _userLoginDto.Role = "Farmer";
                _userLoginDto.ID = user.FarmerId;
                return Ok();
            }
            else if (role == "Employee")
            {
                var user = await _employeeRepository.LoginEmployee(_userLoginDto.Username, _userLoginDto.Password);
                if (user.EmployeeId <= 0)
                {
                    return NotFound("Wrong Details");
                }
                _userLoginDto.Role = "Employee";
                _userLoginDto.ID = user.EmployeeId;
                return Ok();
            }
            else
            {
                return BadRequest("Invalid Role");
            }
        }
    }
}
