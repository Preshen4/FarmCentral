using FarmCentral.Server.Data.Repositories.Stock;
using FarmCentral.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FarmCentral.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {

        private readonly IStockRepository _stockRepository;

        public StockController(IStockRepository stockRepository)
        {
            this._stockRepository = stockRepository;
        }
        // GET: api/<StockController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> Get()
        {
            var stocks = await _stockRepository.GetStocks();
            return Ok(stocks);
        }

        // GET api/<StockController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> Get(int id)
        {
            var stock = await _stockRepository.GetStock(id);
            if (stock != null)
            {
                return Ok(stock);
            }
            return BadRequest();
        }

        // POST api/<StockController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Stock stock)
        {
            await _stockRepository.AddStock(stock);
            return Ok("Stock Created");
        }

        // PUT api/<StockController>/5
        [HttpPut]
        public async Task<ActionResult> Put(Stock stock)
        {
            await _stockRepository.UpdateStock(stock);
            return Ok("Stock Updated");
        }

        // DELETE api/<StockController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int stockId)
        {
            await _stockRepository.DeleteStock(stockId);
            return Ok("Stock has been deleted");
        }
    }
}
