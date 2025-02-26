using StockWatch.Core.Models;
namespace StockWatch.Application.Services
{
    public class ProductService
    {
        public List<Product> GetAllProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Category = "Category 1", Quantity = 100, Price = 19.99M },
                new Product { Id = 2, Name = "Product 2", Category = "Category 2", Quantity = 50, Price = 29.99M }
            };
        }
    }
}
