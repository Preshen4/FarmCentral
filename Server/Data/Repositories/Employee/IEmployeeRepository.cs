namespace FarmCentral.Server.Data.Repositories.Employee

{
    public interface IEmployeeRepository
    {
        Task<List<Shared.Models.Employee>> GetEmployees();
        Task<Shared.Models.Employee> GetEmployee(int employeeId);
        Task AddEmployee(Shared.Models.Employee employee);
        Task UpdateEmployee(Shared.Models.Employee employee);
        Task DeleteEmployee(int employeeId);
        Task<Shared.Models.Employee> LoginEmployee(string username, string password);
    }
}
