using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test_Backend.Models.Entities
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OrderCode { get; set; }

        [Required]
        public string ProductCode { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal SellingPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal TaxRate { get; set; }

        [Required]
        public decimal TaxAmount { get; set; }

        [Required]
        public decimal LineAmount { get; set; }

        [ForeignKey("OrderCode")]
        public Order Order { get; set; }

        [ForeignKey("ProductCode")]
        public Product Product { get; set; }
    }
}
