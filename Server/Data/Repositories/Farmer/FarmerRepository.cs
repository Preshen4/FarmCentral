using FarmCentral.Server.Data.Context;

namespace FarmCentral.Server.Data.Repositories.Farmer
{
    public class FarmerRepository : IFarmerRepository
    {
        private readonly FarmCentralDBContext _dbContext;
        public FarmerRepository(FarmCentralDBContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        // Adds a new Farmer to the database
        public async Task AddFarmer(Shared.Models.Farmer farmer)
        {
            try
            {
                _dbContext.Farmers.Add(farmer);
            }
            catch (Exception)
            {
                throw new Exception("Failed to create new Farmer");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }
        // Deletes a Farmer from the database
        public async Task DeleteFarmer(int farmerId)
        {
            try
            {
                var Farmer = _dbContext.Farmers.FirstOrDefault(f => f.FarmerId == farmerId);
                if (Farmer != null)
                {
                    _dbContext.Farmers.Remove(Farmer);
                }
                else
                {
                    throw new ArgumentNullException("Farmer not found");
                }

            }
            catch (Exception)
            {

                throw new Exception("Failed to delete Farmer");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }
        // Gets a Farmer from the database
        public async Task<Shared.Models.Farmer> GetFarmer(int farmerId)
        {
            try
            {
                var farmer = _dbContext.Farmers.Find(farmerId);
                if (farmer != null)
                {
                    return farmer;
                }
                else
                {
                    throw new ArgumentNullException("Farmer does not exist");
                }
            }
            catch (Exception)
            {

                throw new Exception("Failed to find Farmer");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }
        // Gets all Farmers from the database
        public async Task<List<Shared.Models.Farmer>> GetFarmers()
        {
            try
            {
                var farmers = _dbContext.Farmers.ToList();
                return farmers;
            }
            catch (Exception)
            {

                throw new Exception("Failed to get Farmers");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }
        // Logs a Farmer into the database
        public async Task<Shared.Models.Farmer> LoginFarmer(string username, string password)
        {
            try
            {
                var farmer = _dbContext.Farmers.FirstOrDefault(f => f.UserName == username && f.Password == password);
                if (farmer != null)
                {
                    return farmer;
                }
                else
                {
                    throw new ArgumentNullException("Farmer does not exist");
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
            finally
            {
                _dbContext.SaveChanges();
            }

        }
        // Updates a Farmer in the database
        public async Task UpdateFarmer(Shared.Models.Farmer farmer)
        {
            try
            {
                var farmerToEdt = _dbContext.Farmers.FirstOrDefault(f => f.FarmerId == farmer.FarmerId);
                if (farmerToEdt != null)
                {
                    farmerToEdt.FirstName = farmer.FirstName;
                    farmerToEdt.Surname = farmer.Surname;
                    farmerToEdt.UserName = farmer.UserName;
                    farmerToEdt.Password = farmer.Password;
                }
                else
                {
                    throw new ArgumentNullException("Farmer does not exist");
                }
            }
            catch (Exception)
            {

                throw new Exception("Failed to update Farmer");
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }
    }
}
