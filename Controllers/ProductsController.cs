using HomeInc.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeInc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        // Get Products
        [HttpGet("all")]
        public async Task<ActionResult<List<Products>>> GetAll() 
        {
            return Ok(await _productsService.GetAllProducts());
        }


        // Get Product By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetById(Guid id)
        {
            return Ok(await _productsService.GetProductById(id));
        }

        // Create Product
        [HttpPost]
        public async Task<ActionResult<List<Products>>> CreateProduct(Products product)
        {
            return Ok(await _productsService.CreateProduct(product));
        }

        // Update Product
        [HttpPut]
        public async Task<ActionResult<Products>> UpdateProdyuct(Products product)
        {
            return Ok(await _productsService.UpdateProduct(product));
        }

        // Delete Product
        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProduct(Guid id)
        {
            return Ok(await _productsService.DeleteProduct(id));
        }
    }
}
