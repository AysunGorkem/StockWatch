using Microsoft.EntityFrameworkCore;         
using StockWatch.Infrastructure;             
using Microsoft.OpenApi.Models;            
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL bağlantısını ekleme
builder.Services.AddDbContext<StockWatchDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// OpenAPI ve Swagger yapılandırması ekleme
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "StockWatch API", Version = "v1" });
});

var app = builder.Build();

// Geliştirme ortamında Swagger'ı etkinleştir
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "StockWatch API v1");
    });

    // Swagger UI'yi tarayıcıda otomatik olarak açmak
    try
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "chrome",
            Arguments = "https://localhost:5000/swagger",
            UseShellExecute = true
        });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Tarayiciyi açarken bir hata oluştu: {ex.Message}");
    }
}

app.UseHttpsRedirection();

// API uç noktası: Veritabanındaki tüm ürünleri getirme
app.MapGet("/products", async (StockWatchDbContext db) =>
{
    return await db.Products.ToListAsync();
})
.WithName("GetAllProducts");

// API uç noktası: Veritabanına yeni ürün ekleme
app.MapPost("/products", async (StockWatchDbContext db, Product product) =>
{
    db.Products.Add(product);
    await db.SaveChangesAsync();
    return Results.Created($"/products/{product.Id}", product);
})
.WithName("CreateProduct");

app.Run();

// Product model sınıfı
public record Product(int Id, string Name, string Category, int Quantity, decimal Price);
