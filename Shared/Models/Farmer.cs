namespace FarmCentral.Shared.Models;

public partial class Farmer
{
    [System.ComponentModel.DataAnnotations.Key]
    public int FarmerId { get; set; }

    public string? FirstName { get; set; }

    public string? Surname { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
