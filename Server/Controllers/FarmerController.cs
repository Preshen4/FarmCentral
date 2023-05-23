using FarmCentral.Server.Data.Repositories.Farmer;
using FarmCentral.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FarmCentral.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerController : ControllerBase
    {
        private readonly IFarmerRepository _farmerRepository;

        public FarmerController(IFarmerRepository farmerRepository)
        {
            this._farmerRepository = farmerRepository;
        }
        // GET: api/<FarmerController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Farmer>>> Get()
        {
            var farmers = await _farmerRepository.GetFarmers();
            if (farmers == null)
            {
                return BadRequest("Nothing found");
            }
            return Ok(farmers);
        }

        // GET api/<FarmerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Farmer>> Get(int id)
        {
            var farmer = await _farmerRepository.GetFarmer(id);
            if (farmer != null)
            {
                return Ok(farmer);
            }
            return BadRequest();
        }

        // POST api/<FarmerController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Farmer farmer)
        {
            await _farmerRepository.AddFarmer(farmer);
            return Ok("Farmer Created");
        }

        // PUT api/<FarmerController>/5
        [HttpPut]
        public async Task<ActionResult> Put(Farmer farmer)
        {
            await _farmerRepository.UpdateFarmer(farmer);
            return Ok("Farmer Updated");
        }

        // DELETE api/<FarmerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int farmerId)
        {
            await _farmerRepository.DeleteFarmer(farmerId);
            return Ok("Farmer has been deleted");
        }
    }
}
