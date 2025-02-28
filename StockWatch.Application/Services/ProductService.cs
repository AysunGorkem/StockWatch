using StockWatch.Core.Models;
using StockWatch.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockWatch.Application.Services
{
    public class ProductService
    {
        private readonly StockWatchDbContext _context;

        // DbContext'i dependency injection ile alıyoruz
        public ProductService(StockWatchDbContext context)
        {
            _context = context;
        }

        // Tüm ürünleri veritabanından almak
        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync(); 
        }

        // Yeni bir ürün eklemek
        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync(); 
        }
    }
}
