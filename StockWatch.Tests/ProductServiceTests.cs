using Moq;
using Xunit;
using StockWatch.Application.Services;
using StockWatch.Core.Models;
using StockWatch.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockWatch.Tests
{
    public class ProductServiceTests
    {
        private readonly ProductService _productService;
        private readonly Mock<StockWatchDbContext> _mockContext;
        public ProductServiceTests()
        {
            var options = new DbContextOptionsBuilder<StockWatchDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _mockContext = new Mock<StockWatchDbContext>(options);
            _productService = new ProductService(_mockContext.Object);
        }

        [Fact]
        public async Task GetAllProducts_ShouldReturnProducts()
        {
            var productList = new List<Product>
            {
                new Product(1, "Product 1", "Category 1", 100, 19.99M), 
                new Product(2, "Product 2", "Category 2", 50, 29.99M)
            };

            _mockContext.Setup(db => db.Products.ToListAsync(It.IsAny<CancellationToken>())).ReturnsAsync(productList);

            // Act: Servis metodunu çağırıma
            var result = await _productService.GetAllProducts();

            // Assert: Sonuçları doğrulama
            Assert.Equal(2, result.Count);
            Assert.Equal("Product 1", result[0].Name);
        }

        // POST: Yeni ürün eklerken doğru şekilde işlediğini test etme
        [Fact]
        public async Task AddProduct_ShouldAddProduct()
        {
            var newProduct = new Product(3, "Product 3", "Category 3", 150, 39.99M);

            await _productService.AddProduct(newProduct);

            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
