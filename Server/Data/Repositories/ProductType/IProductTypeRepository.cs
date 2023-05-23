namespace FarmCentral.Server.Data.Repositories.ProductType
{
    public interface IProductTypeRepository
    {

        Task<List<Shared.Models.ProductType>> GetProductTypes();
        Task<Shared.Models.ProductType> GetProductType(int productTypeId);
        Task AddProductType(Shared.Models.ProductType productType);
        Task UpdateProductType(Shared.Models.ProductType productType);
        Task DeleteProductType(int productTypeId);
    }
}
