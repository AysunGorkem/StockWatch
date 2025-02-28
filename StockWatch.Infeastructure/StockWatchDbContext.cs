using Microsoft.EntityFrameworkCore;
using StockWatch.Core.Models;

namespace StockWatch.Infrastructure
{
    public class StockWatchDbContext : DbContext
    {
        public StockWatchDbContext(DbContextOptions<StockWatchDbContext> options) : base(options) { }

        // Veritabanındaki tabloları temsil etmek için DbSet kullanılır.
        public DbSet<Product> Products { get; set; }
    }
}
