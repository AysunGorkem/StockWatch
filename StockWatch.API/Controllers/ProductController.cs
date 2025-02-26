using Microsoft.AspNetCore.Mvc;
using StockWatch.Application.Services;

namespace StockWatch.API.Controllers{
    [ApiController]  
    [Route("api/[controller]")] 
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController()
        {
            _productService = new ProductService();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);  // 200 OK
        }
    }

}