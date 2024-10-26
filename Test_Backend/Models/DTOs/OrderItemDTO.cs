using System.ComponentModel.DataAnnotations;

namespace Test_Backend.Models.DTOs
{
    public class OrderItemDTO
    {
        [Required]
        public string ProductCode { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal SellingPrice { get; set; }
    }
}
