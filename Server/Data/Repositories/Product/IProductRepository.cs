namespace FarmCentral.Server.Data.Repositories.Product
{
    public interface IProductRepository
    {
        Task<List<Shared.Models.Product>> GetProducts();
        Task<Shared.Models.Product> GetProduct(int productId);
        Task AddProduct(Shared.Models.Product product);
        Task UpdateProduct(Shared.Models.Product product);
        Task DeleteProduct(int productId);
        Task<List<Shared.Models.Product>> GetProductsByFarmer(int farmerId);
    }
}
