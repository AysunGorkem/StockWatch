using StockWatch.Core.Models;
using System.Collections.Generic;

namespace StockWatch.Application.Services
{
    public class ProductService
    {
        public List<Product> GetAllProducts()
        {
            return new List<Product>
            {
                new Product(1, "Product 1", "Category 1", 100, 19.99M),
                new Product(2, "Product 2", "Category 2", 50, 29.99M)
            };
        }
    }
}

