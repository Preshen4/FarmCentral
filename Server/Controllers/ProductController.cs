using FarmCentral.Server.Data.Repositories.Product;
using FarmCentral.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FarmCentral.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var Products = await _productRepository.GetProducts();
            return Ok(Products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product != null)
            {
                return Ok(product);
            }
            return BadRequest();
        }
        [HttpGet("farmer/{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByFarmer(int id)
        {
            var Products = await _productRepository.GetProductsByFarmer(id);
            return Ok(Products);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            await _productRepository.AddProduct(product);
            return Ok("Product Created");
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<ActionResult> Put(Product product)
        {
            await _productRepository.UpdateProduct(product);
            return Ok("Product Updated");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int productId)
        {
            await _productRepository.DeleteProduct(productId);
            return Ok("Product has been deleted");
        }
    }
}
