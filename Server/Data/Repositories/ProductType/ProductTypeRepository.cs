using FarmCentral.Server.Data.Context;

namespace FarmCentral.Server.Data.Repositories.ProductType
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly FarmCentralDBContext _dbContext;
        public ProductTypeRepository(FarmCentralDBContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        // Adds a new product type to the database
        public async Task AddProductType(Shared.Models.ProductType productType)
        {
            try
            {
                _dbContext.ProductTypes.Add(productType);
            }
            catch (Exception)
            {
                throw new Exception("Failed to create new product type");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }
        // Deletes a product type from the database
        public async Task DeleteProductType(int productTypeId)
        {
            try
            {
                var productType = _dbContext.ProductTypes.Find(productTypeId);
                if (productType != null)
                {
                    _dbContext.ProductTypes.Remove(productType);
                }
                else
                {
                    throw new ArgumentNullException("Product type not found");
                }

            }
            catch (Exception)
            {

                throw new Exception("Failed to delete product type");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }
        // Gets a product type from the database
        public async Task<Shared.Models.ProductType> GetProductType(int productTypeId)
        {
            try
            {
                var productType = _dbContext.ProductTypes.Find(productTypeId);
                if (productType != null)
                {
                    return productType;
                }
                else
                {
                    throw new ArgumentNullException("Product type does not exist");
                }
            }
            catch (Exception)
            {

                throw new Exception("Failed to find product type");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }
        // Gets all product types from the database
        public async Task<List<Shared.Models.ProductType>> GetProductTypes()
        {
            try
            {
                var productType = _dbContext.ProductTypes.ToList();
                return productType;
            }
            catch (Exception)
            {

                throw new Exception("Failed to get product types");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }
        // Updates a product type in the database
        public async Task UpdateProductType(Shared.Models.ProductType productType)
        {
            try
            {
                var productTypeToEdt = _dbContext.ProductTypes.FirstOrDefault(pt => pt.ProductTypeId == productType.ProductTypeId);
                if (productTypeToEdt != null)
                {
                    productTypeToEdt.Name = productType.Name;
                }
                else
                {
                    throw new ArgumentNullException("Product type does not exist");
                }
            }
            catch (Exception)
            {

                throw new Exception("Failed to update product type");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }
    }
}
