using FarmCentral.Server.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace FarmCentral.Server.Data.Repositories.Stock
{
    public class StockRepository : IStockRepository
    {
        private readonly FarmCentralDBContext _dbContext;
        public StockRepository(FarmCentralDBContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddStock(Shared.Models.Stock stock)
        {
            try
            {
                _dbContext.Stocks.Add(stock);
            }
            catch (Exception)
            {
                throw new Exception("Failed to create new stock");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }

        public async Task DeleteStock(int stockId)
        {
            try
            {
                var stock = _dbContext.Stocks.Find(stockId);
                if (stock != null)
                {
                    _dbContext.Stocks.Remove(stock);
                }
                else
                {
                    throw new ArgumentNullException("Stock type not found");
                }

            }
            catch (Exception)
            {

                throw new Exception("Failed to delete stock");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }

        public async Task<Shared.Models.Stock> GetStock(int stockId)
        {
            try
            {
                var stock = _dbContext.Stocks.Find(stockId);
                if (stock != null)
                {
                    return stock;
                }
                else
                {
                    throw new ArgumentNullException("Stock does not exist");
                }
            }
            catch (Exception)
            {

                throw new Exception("Failed to find stock");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }

        public async Task<List<Shared.Models.Stock>> GetStocks()
        {
            // ChatGPT
            try
            {
                var stock = _dbContext.Stocks.ToList();
                var stockDetails = _dbContext.Stocks
                    .Include(stock => stock.Farmer)
                    .Include(stock => stock.Product)
                        .ThenInclude(product => product.ProductType)
                    .Select(stock => new
                    {
                        UserName = stock.Farmer.UserName,
                        Name = stock.Product.Name,
                        ProductTypeName = stock.Product.ProductType.Name,
                        Quantity = stock.Quantity,
                        Date = stock.Date,
                        Price = stock.Product.Price
                    })
                    .ToList()
                    .Select(stock => new Shared.Models.Stock
                    {
                        Farmer = new Shared.Models.Farmer
                        {
                            UserName = stock.UserName
                        },
                        Product = new Shared.Models.Product
                        {
                            Price = stock.Price,

                            Name = stock.Name,
                            ProductType = new Shared.Models.ProductType
                            {
                                Name = stock.ProductTypeName
                            }
                        },

                        Quantity = stock.Quantity,
                        Date = stock.Date
                    })
                    .ToList(); // Execute the query to retrieve the data

                return stockDetails;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Stocks do not exist");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get products by farmer", ex);
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }

        public async Task<List<Shared.Models.Stock>> GetStocksByFarmer(int farmerId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateStock(Shared.Models.Stock stock)
        {
            try
            {
                var stockToEdt = _dbContext.Stocks.FirstOrDefault(s => s.StockId == stock.StockId);
                if (stockToEdt != null)
                {
                    stockToEdt.Quantity = stock.Quantity;
                    stockToEdt.Date = stock.Date;
                    stockToEdt.FarmerId = stock.FarmerId;
                    stockToEdt.ProductId = stock.ProductId;
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
