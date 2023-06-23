namespace FarmCentral.Server.Data.Repositories.Farmer
{
    public interface IFarmerRepository
    {
        // Farmer Repository Interface with methods to be implemented
        Task<Shared.Models.Farmer> GetFarmer(int farmerId);
        Task<List<Shared.Models.Farmer>> GetFarmers();
        Task AddFarmer(Shared.Models.Farmer farmer);
        Task UpdateFarmer(Shared.Models.Farmer farmer);
        Task DeleteFarmer(int farmerId);
        Task<Shared.Models.Farmer> LoginFarmer(string username, string password);
    }
}
