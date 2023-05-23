
namespace FarmCentral.Shared.Models;

public partial class Stock
{
    public int StockId { get; set; }

    public int? ProductId { get; set; }

    public int? FarmerId { get; set; }

    public int? Quantity { get; set; }

    public DateTime? Date { get; set; }

    public virtual Farmer? Farmer { get; set; }

    public virtual Product? Product { get; set; }
}
