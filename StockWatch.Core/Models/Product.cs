using System.ComponentModel.DataAnnotations;

namespace StockWatch.Core.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public required string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Category cannot be longer than 100 characters")]
        public required string Category { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
    }
}