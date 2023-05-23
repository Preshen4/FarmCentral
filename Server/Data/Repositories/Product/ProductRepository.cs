using FarmCentral.Server.Data.Context;

namespace FarmCentral.Server.Data.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly FarmCentralDBContext _dbContext;
        public ProductRepository(FarmCentralDBContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddProduct(Shared.Models.Product product)
        {
            try
            {
                _dbContext.Products.Add(product);
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

        public async Task DeleteProduct(int productId)
        {
            try
            {
                var product = _dbContext.Products.Find(productId);
                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                }
                else
                {
                    throw new ArgumentNullException("Product not found");
                }

            }
            catch (Exception)
            {

                throw new Exception("Failed to delete product");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }

        public async Task<Shared.Models.Product> GetProduct(int productId)
        {
            try
            {
                var product = _dbContext.Products.Find(productId);
                if (product != null)
                {
                    return product;
                }
                else
                {
                    throw new ArgumentNullException("Product does not exist");
                }
            }
            catch (Exception)
            {

                throw new Exception("Failed to find product");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }

        public async Task<List<Shared.Models.Product>> GetProducts()
        {
            try
            {
                var product = _dbContext.Products.ToList();
                return product;
            }
            catch (Exception)
            {

                throw new Exception("Failed to get products");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }

        public async Task<List<Shared.Models.Product>> GetProductsByFarmer(int farmerId)
        {

            try
            {
                var products = _dbContext.Products.Where(x => x.FarmerId == farmerId).ToList();

                var productList = new List<Shared.Models.Product>();

                foreach (var item in products)
                {
                    var productType = _dbContext.ProductTypes.FirstOrDefault(pt => pt.ProductTypeId == item.ProductTypeId);

                    var product = new Shared.Models.Product
                    {
                        ProductId = item.ProductId,
                        Name = item.Name,
                        FarmerId = item.FarmerId,
                        ProductTypeId = item.ProductTypeId,
                        Price = item.Price,
                        ProductType = new Shared.Models.ProductType
                        {
                            ProductTypeId = (int)(productType?.ProductTypeId),
                            Name = productType?.Name
                        }
                    };

                    productList.Add(product);
                }

                return productList;
            }
            catch (Exception)
            {

                throw new Exception("Failed to get products by farmer");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }

        public async Task UpdateProduct(Shared.Models.Product product)
        {
            try
            {
                var productToEdt = _dbContext.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                if (productToEdt != null)
                {
                    productToEdt.FarmerId = product.FarmerId;
                    productToEdt.ProductTypeId = product.ProductTypeId;
                    productToEdt.Name = product.Name;
                    productToEdt.Price = product.Price;
                }
                else
                {
                    throw new ArgumentNullException("Product does not exist");
                }
            }
            catch (Exception)
            {

                throw new Exception("Failed to update product");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }
    }
}
