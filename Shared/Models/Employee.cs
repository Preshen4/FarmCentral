namespace FarmCentral.Shared.Models;

public partial class Employee
{
    [System.ComponentModel.DataAnnotations.Key]
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? Surname { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }
}
