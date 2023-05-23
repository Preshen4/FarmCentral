namespace FarmCentral.Shared.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int? FarmerId { get; set; }

    public int? ProductTypeId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public virtual Farmer? Farmer { get; set; }

    public virtual ProductType? ProductType { get; set; }

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
