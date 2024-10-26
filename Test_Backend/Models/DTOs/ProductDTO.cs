using System.ComponentModel.DataAnnotations;

namespace Test_Backend.Models.DTOs
{
    public class ProductDTO
    {
        public string ProductCode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public decimal ImportPrice { get; set; }
        [Required]
        public decimal SellingPrice { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public decimal TaxRate { get; set; }
    }
}
