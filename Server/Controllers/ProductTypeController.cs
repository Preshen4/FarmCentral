using FarmCentral.Server.Data.Repositories.ProductType;
using FarmCentral.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FarmCentral.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeController(IProductTypeRepository productTypeRepository)
        {
            this._productTypeRepository = productTypeRepository;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductType>>> Get()
        {
            var productType = await _productTypeRepository.GetProductTypes();
            return Ok(productType);
        }

        // GET api/<ProductTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> Get(int id)
        {
            var productType = await _productTypeRepository.GetProductType(id);
            if (productType != null)
            {
                return Ok(productType);
            }
            return BadRequest();
        }

        // POST api/<ProductTypeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductType productType)
        {
            await _productTypeRepository.AddProductType(productType);
            return Ok("Product Type Created");
        }

        // PUT api/<ProductTypeController>/5
        [HttpPut]
        public async Task<ActionResult> Put(ProductType productType)
        {
            await _productTypeRepository.UpdateProductType(productType);
            return Ok("Product Type Updated");
        }

        // DELETE api/<ProductTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int productTypeId)
        {
            await _productTypeRepository.DeleteProductType(productTypeId);
            return Ok("Product Type has been deleted");
        }
    }
}
