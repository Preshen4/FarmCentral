namespace FarmCentral.Server.Data.Repositories.Stock
{
    public interface IStockRepository
    {
        // Stock Repository Interface with methods to be implemented
        Task<List<Shared.Models.Stock>> GetStocks();
        Task<Shared.Models.Stock> GetStock(int stockId);
        Task AddStock(Shared.Models.Stock stock);
        Task UpdateStock(Shared.Models.Stock stock);
        Task DeleteStock(int stockId);
        Task<List<Shared.Models.Stock>> GetStocksByFarmer(int farmerId);
    }
}
