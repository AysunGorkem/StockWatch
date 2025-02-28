using Microsoft.AspNetCore.Mvc;
using StockWatch.Application.Services; 
using StockWatch.Core.Models; 
using System.Threading.Tasks;

namespace StockWatch.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // GET api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProducts(); 
            return Ok(products);  // 200 OK ile döndürüyoruz
        }

        // POST api/products
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            await _productService.AddProduct(product);  
            return CreatedAtAction(nameof(GetAll), new { id = product.Id }, product); 
        }
    }
}
