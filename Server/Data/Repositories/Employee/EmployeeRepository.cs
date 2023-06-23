using FarmCentral.Server.Data.Context;

namespace FarmCentral.Server.Data.Repositories.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly FarmCentralDBContext _dbContext;
        public EmployeeRepository(FarmCentralDBContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        // Adds a new employee to the database
        public async Task AddEmployee(Shared.Models.Employee employee)
        {
            try
            {
                _dbContext.Employees.Add(employee);
            }
            catch (Exception)
            {
                throw new Exception("Failed to create new Employee");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }
        // Deletes an employee from the database
        public async Task DeleteEmployee(int employeeId)
        {
            try
            {
                var employee = _dbContext.Employees.Find(employeeId);
                if (employee != null)
                {
                    _dbContext.Employees.Remove(employee);
                }
                else
                {
                    throw new ArgumentNullException("Employee not found");
                }

            }
            catch (Exception)
            {

                throw new Exception("Failed to delete employee");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }
        // Gets an employee from the database
        public async Task<Shared.Models.Employee> GetEmployee(int employeeId)
        {
            try
            {
                var employee = _dbContext.Employees.Find(employeeId);
                if (employee != null)
                {
                    return employee;
                }
                else
                {
                    throw new ArgumentNullException("Employee does not exist");
                }
            }
            catch (Exception)
            {

                throw new Exception("Failed to find employee");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }
        // Gets all employees from the database
        public async Task<List<Shared.Models.Employee>> GetEmployees()
        {
            try
            {
                var employees = _dbContext.Employees.ToList();
                return employees;
            }
            catch (Exception)
            {

                throw new Exception("Failed to get Employees");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }
        // Logs an employee into the system
        public async Task<Shared.Models.Employee> LoginEmployee(string username, string password)
        {
            try
            {
                var employee = _dbContext.Employees.FirstOrDefault(e => e.UserName == username && e.Password == password);
                if (employee != null)
                {
                    return employee;
                }
                else
                {
                    throw new ArgumentNullException("Employee does not exist");
                }
            }
            catch (Exception)
            {

                throw new Exception("Failed to find employee");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }
        // Updates an employee in the database
        public async Task UpdateEmployee(Shared.Models.Employee employee)
        {
            try
            {
                var employeeToEdt = _dbContext.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
                if (employeeToEdt != null)
                {
                    employeeToEdt.FirstName = employee.FirstName;
                    employeeToEdt.Surname = employee.Surname;
                    employeeToEdt.UserName = employee.UserName;
                    employeeToEdt.Password = employee.Password;
                }
                else
                {
                    throw new ArgumentNullException("Employee does not exist");
                }
            }
            catch (Exception)
            {

                throw new Exception("Failed to update employee");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }
    }
}
